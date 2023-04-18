using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Registro_UAdeO_2023
{
    public partial class AdminBusquedaAlumnos : Form
    {
        public AdminBusquedaAlumnos()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDAlumnos, BDCarrera;
        private DataSet TBAlumnos, TBCarrera;
        private DataRow RegAlumnos, RegCarrera;
        public string con;
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtMatricula.Text.Length == 0)
            {
                MostrarInfo();
                return;
            }
            BuscarMatricula(txtMatricula.Text.Trim());

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Tabla.CurrentRow.Index == 0) { return; }
            AdminModificarAlumno frm = new AdminModificarAlumno();
            frm.con = con;
            frm.Matricula = Convert.ToInt32(Tabla.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            MostrarInfo();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Tabla.RowCount != 0)
            {
                try
                {
                    string Matricula = Convert.ToString(Tabla.CurrentRow.Cells[0].Value);
                    SqlConnection cnn = new SqlConnection(con);
                    string STRsql = "DELETE FROM Alumnos WHERE Matricula = '" + Matricula + "'";
                    SqlCommand cmd = new SqlCommand(STRsql, cnn);
                    cmd.Parameters.Clear();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    MessageBox.Show("Borrado Exitosamente!");
                    Tabla.Rows.RemoveAt(Tabla.CurrentRow.Index);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede borrar las lineas seleccionadas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarInfo();
        }
        private void MostrarInfo()
        {
            Tabla.Rows.Clear();
            string STRSql = "SELECT * FROM Alumnos";
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            try
            {
                BDAlumnos = new SqlDataAdapter(cmd);
                TBAlumnos = new DataSet();
                BDAlumnos.Fill(TBAlumnos, "Alumnos");
                RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];
            }
            catch (Exception)
            {

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
                //RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
                RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[i];
                Tabla.Rows.Add();
                Tabla.Rows[i].Cells[0].Value = RegAlumnos["Matricula"];
                Tabla.Rows[i].Cells[1].Value = RegAlumnos["Nombres"];
                Tabla.Rows[i].Cells[2].Value = RegAlumnos["Apellido_Paterno"];
                Tabla.Rows[i].Cells[3].Value = RegAlumnos["Apellido_Materno"];
                Tabla.Rows[i].Cells[4].Value = RegCarrera["NomLargo"];
                //Tabla.Rows[i].Cells[5].Value = RegAlumnos["Grupo"];
                Tabla.Rows[i].Cells[5].Value = RegAlumnos["Fec_Registro"];
            }
        }
        private void BuscarMatricula(string Matricula)
        {
            Tabla.Rows.Clear();
            string STRSql = "SELECT * FROM Alumnos WHERE Matricula LIKE '%" + Matricula + "%'";
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            BDAlumnos = new SqlDataAdapter(cmd);
            TBAlumnos = new DataSet();
            BDAlumnos.Fill(TBAlumnos, "Alumnos");
            try
            {
                RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];
            }
            catch (Exception)
            {
                MessageBox.Show("");
                //return;
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
                //Tabla.Rows[i].Cells[5].Value = RegAlumnos["Grupo"];
                //Tabla.Rows[i].Cells[6].Value = RegAlumnos["Fec_Registro"];
            }
        }
    }
}
