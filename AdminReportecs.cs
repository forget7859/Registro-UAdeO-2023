using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Registro_UAdeO_2023
{
    public partial class AdminReportes : Form
    {
        private SqlDataAdapter BDRegistros, BDCarrera, BDGenero;
        private DataSet TBRegistros, TBCarrera, TBGenero;
        private DataRow RegRegistros, RegCarrera, RegGenero;
        private string con;
        public AdminReportes()
        {
            InitializeComponent();
        }
        private void AdminReportes_Load(object sender, EventArgs e)
        {

            string STRSql = "SELECT ID,NomCorto FROM Carrera";
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            BDCarrera = new SqlDataAdapter(cmd);
            TBCarrera = new DataSet();
            BDCarrera.Fill(TBCarrera, "Carrera");
            RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
            for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
            {
                BindingContext[TBCarrera, "Carrera"].Position = i;
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
            }
            STRSql = "SELECT Id,NomGenero FROM Genero";
            cmd = new SqlCommand(STRSql, cnn);
            BDGenero = new SqlDataAdapter(cmd);
            TBGenero = new DataSet();
            BDGenero.Fill(TBGenero, "Genero");
            RegGenero = TBGenero.Tables["Genero"].Rows[0];
            for (int i = 0; i <= BindingContext[TBGenero, "Genero"].Count - 1; i++)
            {
                BindingContext[TBGenero, "Genero"].Position = i;
                RegGenero = TBGenero.Tables["Genero"].Rows[i];
            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void MostrarInfo()
        {
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
            }

            for (int i = 0; i < BindingContext[TBRegistros, "Registros"].Count; i++)
            {
                string STRSql3 = "SELECT ID,NomCorto FROM Carrera WHERE ID=" + RegRegistros["Carrera"];
                SqlCommand cmd2 = new SqlCommand(STRSql3, cnn);
                BDCarrera = new SqlDataAdapter(cmd2);
                TBCarrera = new DataSet();
                BDCarrera.Fill(TBCarrera, "Carrera");
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];

                RegRegistros = TBRegistros.Tables["Registros"].Rows[i];
                Tabla.Rows.Add();
                Tabla.Rows[i].Cells[0].Value = RegRegistros["Matricula"];
                Tabla.Rows[i].Cells[1].Value = RegRegistros["Nombres"];
                Tabla.Rows[i].Cells[2].Value = RegRegistros["Apellido_Paterno"];
                Tabla.Rows[i].Cells[3].Value = RegRegistros["Apellido_Materno"];
                Tabla.Rows[i].Cells[4].Value = RegCarrera["NomCorto"];
                if (Convert.ToInt32(RegRegistros["Semestre"]) == 0)
                {
                    Tabla.Rows[i].Cells[5].Value = "-";
                }
                else
                {
                    Tabla.Rows[i].Cells[5].Value = RegRegistros["Semestre"];
                }

                Tabla.Rows[i].Cells[6].Value = RegRegistros["Fec_InicioSesion"];
                Tabla.Rows[i].Cells[7].Value = RegRegistros["Fec_Registro"];
            }
        }
}
