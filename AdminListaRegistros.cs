using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Registro_UAdeO_2023
{
    public partial class AdminListaRegistros : Form
    {
        public AdminListaRegistros()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDRegistro, BDAlumnos, BDCarrera;
        private DataSet TBRegistro, TBAlumnos, TBCarrera;
        private DataRow Registro, RegAlumnos, RegCarrera;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string con;
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
            string STRSql = "SELECT * FROM Registro";
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            try
            {
                BDRegistro = new SqlDataAdapter(cmd);
                BDAlumnos = new SqlDataAdapter(cmd);
                TBAlumnos = new DataSet();
                BDAlumnos.Fill(TBAlumnos, "Alumnos");
                RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];
            }
            catch (Exception)
            {
                //
                STRSql = " INSERT INTO Alumnos (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Grupo,Fec_Registro)" +
                 "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@gpo,@f_reg)";
                cmd = new SqlCommand(STRSql, cnn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mat", Convert.ToString("00000000"));
                cmd.Parameters.AddWithValue("@nom", Convert.ToString("NOMBRE"));
                cmd.Parameters.AddWithValue("@a_p", Convert.ToString("APELLIDO PATERNO"));
                cmd.Parameters.AddWithValue("@a_m", Convert.ToString("APELLIDO MATERNO"));
                cmd.Parameters.AddWithValue("@carrera", 1);
                cmd.Parameters.AddWithValue("@gpo", 0);
                cmd.Parameters.AddWithValue("@f_reg", DateTime.Now);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                STRSql = "SELECT * FROM Alumnos";
                cmd = new SqlCommand(STRSql, cnn);
                BDAlumnos = new SqlDataAdapter(cmd);
                TBAlumnos = new DataSet();
                BDAlumnos.Fill(TBAlumnos, "Alumnos");
                RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];
            }

            string STRSql2 = "SELECT ID,NomLargo FROM Carrera WHERE ID=" + RegAlumnos["Carrera"];
            SqlCommand cmd1 = new SqlCommand(STRSql2, cnn);
            BDCarrera = new SqlDataAdapter(cmd1);
            TBCarrera = new DataSet();
            BDCarrera.Fill(TBCarrera, "Carrera");
            RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
            for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
            {
                BindingContext[TBCarrera, "Carrera"].Position = i;
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
            }

            for (int i = 0; i < BindingContext[TBAlumnos, "Alumnos"].Count; i++)
            {
                string STRSql3 = "SELECT ID,NomLargo FROM Carrera WHERE ID=" + RegAlumnos["Carrera"];
                SqlCommand cmd2 = new SqlCommand(STRSql3, cnn);
                BDCarrera = new SqlDataAdapter(cmd2);
                TBCarrera = new DataSet();
                BDCarrera.Fill(TBCarrera, "Carrera");
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
                RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[i];
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
