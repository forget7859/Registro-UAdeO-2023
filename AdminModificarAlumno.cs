using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Registro_UAdeO_2023
{
    public partial class AdminModificarAlumno : Form
    {
        public AdminModificarAlumno()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDAlumnos, BDCarrera;
        private SqlConnection cnn;
        private DataSet TBAlumnos, TBCarrera;
        private DataRow RegAlumnos, RegCarrera;

        public int Matricula, grupo, semestre;
        public string con,NomCarrera;
        private int IDCarrera;

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult d;
            
            if (txtNombre.Text == null)
            {
                d = MessageBox.Show("El espacio Nombre está vacio!");
                return;
            }
            if (txtApellidoPaterno.Text == null)
            {
                d = MessageBox.Show("Falta llenar el apellido paterno!");
                return;
            }
            if (txtApellidoPaterno.Text == null)
            {
                d = MessageBox.Show("Falta llenar el apellido materno!");
                return;
            }
            if (cboCarrera.Text == "-Seleccione una Carrera-")
            {
                d = MessageBox.Show("Debes elegir una carrera para continuar!");
                return;
            }
            if (txtGrupo.Text.Length != 1)
            {
                d = MessageBox.Show("El grupo debe ser de una unidad (1 caracter)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Esta Seguro que Desea crear un nuevo Registro?", "Sí", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection cnn = new SqlConnection(con);
                string STRsql = " UPDATE Alumnos SET Nombres = '" + txtNombre.Text.Trim() + "',Apellido_Paterno = '" + txtApellidoPaterno.Text.Trim() + "',Apellido_Materno = '" + txtApellidoMaterno.Text.Trim() + "',Carrera = '" + IDCarrera + "',Grupo = '" + txtGrupo.Text.Trim() + "' WHERE Matricula ='"+Matricula+"'";
                SqlCommand cmd = new SqlCommand(STRsql, cnn);
                cmd.Parameters.Clear();
                cnn.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                MessageBox.Show("Alumno modificado exitosamente!");
                Close();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Matricula : " + Matricula;

            string STRsql = "SELECT * FROM Alumnos WHERE Matricula = " + Convert.ToString(Matricula);
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(STRsql, cnn);
            BDAlumnos = new SqlDataAdapter(cmd);
            TBAlumnos = new DataSet();
            BDAlumnos.Fill(TBAlumnos, "Alumnos");
            RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];
            STRsql = "SELECT NomLargo FROM Carrera";
            cmd = new SqlCommand(STRsql, cnn);
            BDCarrera = new SqlDataAdapter(cmd);
            TBCarrera = new DataSet();
            BDCarrera.Fill(TBCarrera, "Carrera");
            RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
            for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
            {
                BindingContext[TBCarrera, "Carrera"].Position = i;
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
                cboCarrera.Items.Add(RegCarrera["NomLargo"]);
                if (RegAlumnos["Carrera"] == RegCarrera["Id"])
                {
                    IDCarrera = Convert.ToInt32(RegCarrera["Id"]);
                }
            }
            txtNombre.Text = Convert.ToString(RegAlumnos["Nombres"]);
            txtApellidoPaterno.Text = Convert.ToString(RegAlumnos["Apellido_Paterno"]);
            txtApellidoMaterno.Text = Convert.ToString(RegAlumnos["Apellido_Materno"]);
            cboCarrera.Text = Convert.ToString(RegCarrera["NomLargo"]);
            txtGrupo.Text = Convert.ToString(RegAlumnos["Grupo"]);
        }
    }
}
