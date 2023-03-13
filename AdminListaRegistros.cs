using Registro_UAdeO_2023.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Registro_UAdeO_2023
{
    public partial class AdminListaRegistros : Form
    {
        public AdminListaRegistros()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDRegistros, BDCarrera;
        private DataSet TBRegistros, TBCarrera;
        private DataRow RegRegistros, RegCarrera;
        public string con;
        private void printDocRegistros_PrintPage(object sender, PrintPageEventArgs e)
        {

            e.Graphics.DrawString("Reporte de Ingreso al Centro de Computo", new Font("Calibri", 18, FontStyle.Bold), Brushes.Black, new Point(200, 50));
            e.Graphics.DrawString(Convert.ToString("Fecha de Reporte: "+fecha), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(200, 80));
            e.Graphics.DrawString(Convert.ToString("Hora"+hora), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(450, 80));

            e.Graphics.DrawString("Matricula", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(T_l_corner, T_Top));
            e.Graphics.DrawString("Nombre(s)", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(T_l_corner+80, T_Top));
            e.Graphics.DrawString("Apellido(s)", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(T_l_corner+180, T_Top));
            e.Graphics.DrawString("Carrera", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(T_l_corner+310, T_Top));
            e.Graphics.DrawString("Fecha de Sesión", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(T_l_corner+400, T_Top));
            int row = T_Top+20;
            for(int i=0; i < Tabla.RowCount; i++)
            {
                e.Graphics.DrawString(Convert.ToString(Tabla.Rows[i].Cells[1].Value), new Font("Calibri", 10, FontStyle.Bold), Brushes.Black, new Point(T_l_corner, row));
                e.Graphics.DrawString(Convert.ToString(Tabla.Rows[i].Cells[2].Value), new Font("Calibri", 10, FontStyle.Bold), Brushes.Black, new Point(T_l_corner + 80, row));
                e.Graphics.DrawString(Convert.ToString(Tabla.Rows[i].Cells[3].Value)+" "+ Convert.ToString(Tabla.Rows[i].Cells[4].Value), new Font("Calibri", 10, FontStyle.Bold), Brushes.Black, new Point(T_l_corner + 180, row));
                e.Graphics.DrawString(Convert.ToString(Tabla.Rows[i].Cells[5].Value), new Font("Calibri", 10, FontStyle.Bold), Brushes.Black, new Point(T_l_corner + 310, row));
                e.Graphics.DrawString(Convert.ToString(Tabla.Rows[i].Cells[7].Value), new Font("Calibri", 10, FontStyle.Bold), Brushes.Black, new Point(T_l_corner + 400, row));
                row+= 25;
                /*
                Tabla.Rows[i].Cells[0].Value = RegRegistros["Id"];
                Tabla.Rows[i].Cells[1].Value = RegRegistros["Matricula"];
                Tabla.Rows[i].Cells[2].Value = RegRegistros["Nombres"];
                Tabla.Rows[i].Cells[3].Value = RegRegistros["Apellido_Paterno"];
                Tabla.Rows[i].Cells[4].Value = RegRegistros["Apellido_Materno"];
                Tabla.Rows[i].Cells[5].Value = RegCarrera["NomCorto"];
                Tabla.Rows[i].Cells[6].Value = RegRegistros["Semestre"];
                Tabla.Rows[i].Cells[7].Value = RegRegistros["Fec_InicioSesion"];
                Tabla.Rows[i].Cells[8].Value = RegRegistros["Fec_Registro"];
                 */
            }
        }



        private void btnImprimir_Click(object sender, EventArgs e)
        {
            AdminListaRegistros_Imprimir frm = new AdminListaRegistros_Imprimir();

        }

        private void AdminListaRegistros_Load(object sender, EventArgs e)
        {
            MostrarInfo();
        }
        private void MostrarInfo()
        {
            Tabla.Rows.Clear();
            string STRSql = "SELECT * FROM Registros";
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            try
            {
                BDRegistros = new SqlDataAdapter(cmd);
                BDRegistros = new SqlDataAdapter(cmd);
                TBRegistros = new DataSet();
                BDRegistros.Fill(TBRegistros, "Registros");
                RegRegistros = TBRegistros.Tables["Registros"].Rows[0];
            }
            catch (Exception)
            {
                MessageBox.Show("No hay ningun Registro en la base de datos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
                /*
                STRSql = " INSERT INTO Registros (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Semestre,Fec_Registro,Fec_InicioSesion)" +
                 "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@f_reg,f_ini)";
                cmd = new SqlCommand(STRSql, cnn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mat", Convert.ToString("00000000"));
                cmd.Parameters.AddWithValue("@nom", Convert.ToString("NOMBRE"));
                cmd.Parameters.AddWithValue("@a_p", Convert.ToString("APELLIDO PATERNO"));
                cmd.Parameters.AddWithValue("@a_m", Convert.ToString("APELLIDO MATERNO"));
                cmd.Parameters.AddWithValue("@carrera", 1);
                //cmd.Parameters.AddWithValue("@gpo", 0);
                cmd.Parameters.AddWithValue("@f_reg", DateTime.Now);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                STRSql = "SELECT * FROM Registros";
                cmd = new SqlCommand(STRSql, cnn);
                BDRegistros = new SqlDataAdapter(cmd);
                TBRegistros = new DataSet();
                BDRegistros.Fill(TBRegistros, "Registros");
                RegRegistros = TBRegistros.Tables["Registros"].Rows[0];
                */
            }

            STRSql = "SELECT ID,NomLargo FROM Carrera WHERE ID=" + Convert.ToString(RegRegistros["Carrera"]);
            cmd = new SqlCommand(STRSql, cnn);
            BDCarrera = new SqlDataAdapter(cmd);
            TBCarrera = new DataSet();
            BDCarrera.Fill(TBCarrera, "Carrera");
            RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
            for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
            {
                BindingContext[TBCarrera, "Carrera"].Position = i;
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
            }

            for (int i = 0; i < BindingContext[TBRegistros, "Registros"].Count; i++)
            {
                string STRSql3 = "SELECT ID,NomLargo FROM Carrera WHERE ID=" + RegAlumnos["Carrera"];
                SqlCommand cmd2 = new SqlCommand(STRSql3, cnn);
                BDCarrera = new SqlDataAdapter(cmd2);
                TBCarrera = new DataSet();
                BDCarrera.Fill(TBCarrera, "Carrera");
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
                RegRegistros = TBRegistros.Tables["Registros"].Rows[i];
                Tabla.Rows.Add();
                Tabla.Rows[i].Cells[0].Value = RegAlumnos["Matricula"];
                Tabla.Rows[i].Cells[1].Value = RegAlumnos["Nombres"];
                Tabla.Rows[i].Cells[2].Value = RegAlumnos["Apellido_Paterno"];
                Tabla.Rows[i].Cells[3].Value = RegAlumnos["Apellido_Materno"];
                Tabla.Rows[i].Cells[4].Value = RegCarrera["NomLargo"];
                Tabla.Rows[i].Cells[5].Value = RegAlumnos["Grupo"];
                Tabla.Rows[i].Cells[6].Value = RegAlumnos["Fec_Registro"];
            }
        }
    }
}
