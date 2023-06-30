using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_UAdeO_2023
{
    public partial class AdminReportes : Form
    {
        private SqlDataAdapter BDRegistros, BDCarrera, BDGenero;
        private DataSet TBRegistros, TBCarrera, TBGenero;
        private DataRow RegRegistros, RegCarrera, RegGenero;
        public string con;
        private string parametros;
        private void rBtnMujer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rBtnOtros_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            
            PrepararImpresion();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void cboxGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxGenero.Checked == true)
            {
                rBtnHombre.Enabled = true;
                rBtnMujer.Enabled = true;
                rBtnOtros.Enabled = true;
            }
            if (cboxGenero.Checked == false)
            {
                rBtnHombre.Enabled = false;
                rBtnMujer.Enabled = false;
                rBtnOtros.Enabled = false;
            }
        }

        private void cboxCarrera_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxCarrera.Checked == true) { cboCarrera.Enabled = true; }
            if (cboxCarrera.Checked == false) { cboCarrera.Enabled = false; }
        }

        private void rBtnGenero_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rBtnCarrera_CheckedChanged(object sender, EventArgs e)
        {

        }

        public AdminReportes()
        {
            InitializeComponent();
        }
        private void AdminReportes_Load(object sender, EventArgs e)
        {
            cboCarrera.Enabled = false;
            rBtnHombre.Enabled = false;
            rBtnMujer.Enabled = false;
            rBtnOtros.Enabled = false;

            string STRSql = "SELECT ID,NomCorto,NomLargo FROM Carrera";
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            BDCarrera = new SqlDataAdapter(cmd);
            TBCarrera = new DataSet();
            BDCarrera.Fill(TBCarrera, "Carrera");
            for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
            {
                BindingContext[TBCarrera, "Carrera"].Position = i;
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
                cboCarrera.Items.Add(RegCarrera["Nomlargo"]);
            }

            STRSql = "SELECT Id,NomGenero FROM Genero";
            cmd = new SqlCommand(STRSql, cnn);
            BDGenero = new SqlDataAdapter(cmd);
            TBGenero = new DataSet();
            BDGenero.Fill(TBGenero, "Generos");
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void PrepararImpresion()
        {
            string inicio = Convert.ToString(fec_inicio.Value);
            string dd = inicio.Substring(0, 2);
            string mm = inicio.Substring(3, 2);
            string yyyy = inicio.Substring(6, 4);
            inicio = yyyy + mm + dd;

            string fin = Convert.ToString(fec_final.Value);

            dd = fin.Substring(0, 2);
            mm = fin.Substring(3, 2);
            yyyy = fin.Substring(6, 4);
            fin = yyyy + mm + dd;
            string STRSql = "SELECT * FROM Registros WHERE fec_InicioSesion between '" + inicio + "' and '" + fin + "'";
            if(cboxCarrera.Checked == true){
                if(cboCarrera.Text != null) {
                    for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++){
                        RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
                        if (cboCarrera.Text.Trim() == RegCarrera["NomLargo"].ToString()){
                            STRSql += "AND Carrera = " + Convert.ToString(RegCarrera["Id"]);
                            parametros = parametros + " Carrera = " + Convert.ToString(RegCarrera["NomCorto"]);
                        }
                    }
                }
            }
            
            if (cboxGenero.Checked == true)
            {
                if (rBtnHombre.Checked.Equals(true))
                {
                    STRSql += " AND Genero = 1 ";
                    parametros = parametros + "Genero: H ";
                }
                if (rBtnMujer.Checked == true)
                {
                    STRSql = STRSql + " AND Genero = 2";
                    parametros = parametros + " Genero: M ";
                }
                if (rBtnOtros.Checked == true)
                {
                    STRSql = STRSql + " AND Genero = 3";
                    parametros = parametros + "Genero: O ";
                }
            }
            MessageBox.Show(STRSql);
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            try
            {
                BDRegistros = new SqlDataAdapter(cmd);
                TBRegistros = new DataSet();
                BDRegistros.Fill(TBRegistros, "Registros");
            }
            catch (Exception)
            {
                MessageBox.Show("No hay ningun Registro en la base de datos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            SLDocument sl = new SLDocument();
            SLPageSettings slSettings = new SLPageSettings();
            slSettings.Orientation = OrientationValues.Landscape;
            slSettings.OddFooterText = dd + " - " + mm + " - " + yyyy;
            sl.SetPageSettings(slSettings);
            Bitmap bmp = Properties.Resources.logo_UAdeO_retina;
            Image logo = bmp;
            SLPicture slLogo = new SLPicture("C:\\Users\\forgetMC\\source\\repos\\forget7859\\Registro-UAdeO-2023\\logo-UAdeO-retina.png");
            slLogo.SetPosition(0, 0);
            slLogo.ResizeInPixels(200, 80);
            string fecha = DateTime.Now.ToString();
            string hora = DateTime.Now.TimeOfDay.ToString();
            sl.InsertPicture(slLogo);

            /*
             * B    Matricula
             * C    Nombre(s)
             * D    Apellido Paterno
             * E    Apellido Materno
             * F    Carrera
             * G    Semestre
             * H    Fecha Ingreso (fecga de captura)
             */
            
            SLStyle slTitle = new SLStyle();
            slTitle.SetFontBold(true);
            slTitle.SetFont("Arial", 15);
            slTitle.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
            SLFont fontTitle = new SLFont();
            fontTitle.Bold = true;
            fontTitle.FontSize = 15;
            SLStyle slAligment = new SLStyle();
            slAligment.SetHorizontalAlignment(HorizontalAlignmentValues.Center);

            sl.SetCellValue("A1", "UNIVERSIDAD AUTONOMA DE OCCIDENTE");
            sl.MergeWorksheetCells("A1", "G1");
            sl.SetCellStyle("A1", slTitle);

            sl.SetCellValue("A2", "UNIDAD REGIONAL CULIACAN");
            sl.MergeWorksheetCells("A2", "G2");
            sl.SetCellStyle("A2", slAligment);

            sl.SetCellValue("A3", "REGISTRO DE ACCESO CENTRO DE COMPUTO");
            sl.MergeWorksheetCells("A3", "G3");
            sl.SetCellStyle("A3", slAligment);

            sl.SetCellValue("A4", "PARAMETROS: ["+parametros+"]");
            sl.MergeWorksheetCells("A4", "G4");
            sl.SetCellStyle("A4", slAligment);

            sl.SetCellValue("A6", "Matricula");
            sl.SetCellValue("B6", "Nombre(s)");
            sl.SetColumnWidth("B6", 20);
            sl.SetCellValue("C6", "Apellido Paterno");
            sl.SetColumnWidth("C6", 20);
            sl.SetCellValue("D6", "Apellido Materno");
            sl.SetColumnWidth("D6", 20);
            sl.SetCellValue("E6", "Carrera");
            //sl.SetColumnWidth("E5", 20);
            sl.SetCellValue("F6", "Semestre");
            //sl.SetColumnWidth("E6", 10);
            sl.SetCellValue("G6", "Fecha de Ingreso");
            sl.SetColumnWidth("G6", 23);
            
            int excColumna = 7,FinTabla=0;
            for (int i = 0; i < BindingContext[TBRegistros.Tables["Registros"]].Count - 1; i++)
            {
                BindingContext[TBRegistros, "Registros"].Position = i;
                RegRegistros = TBRegistros.Tables["Registros"].Rows[i];
                STRSql = "SELECT ID,NomCorto FROM Carrera WHERE ID=" + RegRegistros["Carrera"];
                cmd = new SqlCommand(STRSql, cnn);
                BDCarrera = new SqlDataAdapter(cmd);
                TBCarrera = new DataSet();
                BDCarrera.Fill(TBCarrera, "Carrera");
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
                /*
                STRSql = "SELECT NomGenero FROM Genero WHERE Id = "+RegRegistros["Genero"];
                cmd = new SqlCommand(STRSql, cnn);
                BDGenero = new SqlDataAdapter(cmd);
                TBGenero = new DataSet();
                BDGenero.Fill(TBGenero, "Genero");
                */
                sl.SetCellValue("A" + (excColumna + i), Convert.ToString(RegRegistros["Matricula"]));
                sl.SetCellValue("B" + (excColumna + i), Convert.ToString(RegRegistros["Nombres"]));
                sl.SetCellValue("C" + (excColumna + i), Convert.ToString(RegRegistros["Apellido_Paterno"]));
                sl.SetCellValue("D" + (excColumna + i), Convert.ToString(RegRegistros["Apellido_MAterno"]));
                sl.SetCellValue("E" + (excColumna + i), Convert.ToString(RegCarrera["NomCorto"]));
                sl.SetCellValue("F" + (excColumna + i), Convert.ToString(RegRegistros["Semestre"]));
                sl.SetCellValue("G" + (excColumna + i), Convert.ToString(RegRegistros["Fec_InicioSesion"]));
                FinTabla = excColumna + i;
            }

            SLStyle sl1 = sl.CreateStyle();
            sl1.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            sl1.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            sl1.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            sl1.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            sl1.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            sl1.SetHorizontalAlignment(HorizontalAlignmentValues.Left);
            sl.SetCellStyle("A" + (excColumna-1), "G"+FinTabla,sl1);

            saveFileDialog1.Title = "Gardar archivo en:";
            saveFileDialog1.InitialDirectory = Environment.UserName+ "\\Documents";
            saveFileDialog1.DefaultExt = ".xlsx";
            saveFileDialog1.FileName = "Reporte de Ingreso "+dd+"-"+mm+"-"+yyyy;
            saveFileDialog1.ShowDialog();

            string dir = Path.GetFullPath(saveFileDialog1.FileName);
            sl.SaveAs(dir);
            Close();
        } 
    }
}
