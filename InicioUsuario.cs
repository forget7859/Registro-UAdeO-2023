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
using Registro_UAdeO_2003;

namespace Registro_UAdeO_2023
{
    public partial class InicioUsuario : Form
    {
        public InicioUsuario()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDDocentes, BDAlumnos, BDCarrera;
        private DataSet TBDocentes, TBAlumnos, TBCarrera;
        private DataRow RegDocentes, RegAlumnos, RegCarrera;
        private int IDCarrera;
        protected string STRcon = " SERVER=.; DataBase=RegistroUAdeO; Integrated Security=SSPI";
        private SqlConnection cnn;
        public void InicioUsuario_Load(object sender, EventArgs e)
        {
            administradorToolStripMenuItem.Enabled = false;
            pnlRegistro.Visible = false;
            pnlMostrarDatos.Visible = false;
            RefrescarBD();
        }
        private void IngresarDatos() {
            DialogResult d;

            switch (txtMatricula.Text.Length)
            {
                case 8:
                    string STRsql = "SELECT * FROM Alumnos WHERE Matricula = " + txtMatricula.Text.Trim();
                    SqlCommand cmd = new SqlCommand(STRsql, cnn);
                    BDAlumnos = new SqlDataAdapter(cmd);
                    TBAlumnos = new DataSet();
                    BDAlumnos.Fill(TBAlumnos, "Alumnos");
                    try
                    {
                        RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];
                        if (txtMatricula.Text.Trim() == Convert.ToString(RegAlumnos["Matricula"]))
                        {
                            MostrarInfo();
                        }
                    }
                    catch (Exception)
                    {
                        d = MessageBox.Show("no esta registrado. Registrate!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        groupBox1.Enabled = false;
                        pnlRegistro.Visible = true;
                        SqlConnection cnn = new SqlConnection(STRcon);
                        string STRSql2 = "SELECT NomLargo FROM Carrera";
                        SqlCommand cmd1 = new SqlCommand(STRSql2, cnn);
                        BDCarrera = new SqlDataAdapter(cmd1);
                        TBCarrera = new DataSet();
                        BDCarrera.Fill(TBCarrera, "Carrera");
                        RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
                        for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
                        {
                            BindingContext[TBCarrera, "Carrera"].Position = i;
                            RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
                            cboCarrera.Items.Add(RegCarrera["NomLargo"]);
                        }
                    }
                    break;
                case 4:
                   STRsql = "SELECT * FROM Docentes WHERE Matricula = " + txtMatricula.Text.Trim();
                    cmd = new SqlCommand(STRsql, cnn);
                    BDDocentes = new SqlDataAdapter(cmd);
                    TBDocentes = new DataSet();
                    BDDocentes.Fill(TBDocentes, "Docentes");
                    try
                    {
                        RegDocentes = TBDocentes.Tables["Docentes"].Rows[0];
                        if (txtMatricula.Text.Trim() == Convert.ToString(RegDocentes["Matricula"]))
                        {
                            MostrarInfo();
                        }
                    }
                    catch (Exception)
                    {
                        d = MessageBox.Show("no esta registrado. Registrate!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        groupBox1.Enabled = false;
                        pnlRegistro.Visible = true;
                        SqlConnection cnn = new SqlConnection(STRcon);
                        string STRSql2 = "SELECT NomLargo FROM Carrera";
                        SqlCommand cmd1 = new SqlCommand(STRSql2, cnn);
                        BDCarrera = new SqlDataAdapter(cmd1);
                        TBCarrera = new DataSet();
                        BDCarrera.Fill(TBCarrera, "Carrera");
                        RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
                        for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
                        {
                            BindingContext[TBCarrera, "Carrera"].Position = i;
                            RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
                            cboCarrera.Items.Add(RegCarrera["NomLargo"]);
                        }
                    }
                    break;
                default:
                    d = MessageBox.Show("No has ingresado la matricula correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
            if (txtMatricula.Text.Length != 8)
            {
                
            }
            
            RefrescarBD();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IngresarDatos();
        }
        private void MostrarInfo()
        {
            groupBox1.Enabled = false;
            string STRSql = "SELECT * FROM Alumnos WHERE Matricula = " + txtMatricula.Text.Trim();
            SqlConnection cnn = new SqlConnection(STRcon);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            BDAlumnos = new SqlDataAdapter(cmd);
            TBAlumnos = new DataSet();
            BDAlumnos.Fill(TBAlumnos, "Alumnos");
            BindingContext[TBAlumnos, "Alumnos"].Position = 0;
            RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];

            string STRSql2 = "SELECT NomLargo FROM Carrera WHERE ID=" + RegAlumnos["Carrera"];
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
            lblNombres.Text = "" + Convert.ToString(RegAlumnos["Nombres"])+ " " + Convert.ToString(RegAlumnos["Apellido_Paterno"]) + " " + Convert.ToString(RegAlumnos["Apellido_Materno"]) + "";
            lblCarrera.Text = "" + Convert.ToString(RegCarrera["NomLargo"]) + "";
            lblSemestre.Text = "" + Convert.ToString(RegAlumnos["Semestre"]) + "";
            /*
            dataGridView1.Rows[0].Cells[0].Value = RegAlumnos["Nombres"];
            dataGridView1.Rows[0].Cells[1].Value = RegAlumnos["Apellido_Paterno"];
            dataGridView1.Rows[0].Cells[2].Value = RegAlumnos["Apellido_Materno"];
            dataGridView1.Rows[0].Cells[3].Value = RegCarrera["NomLargo"]; // Usar la tabla "Carrera"
            dataGridView1.Rows[0].Cells[4].Value = RegAlumnos["Grupo"];
            */
            pnlMostrarDatos.Visible = true;
            GuardarDatos();
            ReiniciarVentana();
        }
        private void cboCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(STRcon);
            string STRSql = "SELECT ID FROM Carrera WHERE NomLargo ='" + cboCarrera.Text + "'";
            SqlCommand cmd1 = new SqlCommand(STRSql, cnn);
            BDCarrera = new SqlDataAdapter(cmd1);
            TBCarrera = new DataSet();
            BDCarrera.Fill(TBCarrera, "Carrera");
            RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
            IDCarrera = Convert.ToInt32(RegCarrera["ID"]);
        }
        private void cboCarrera_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                txtSemestre.Focus();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarVentana();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult d;
            if (txtNombre.Text == null)
            {
                d = MessageBox.Show("El espacio Nombre está vacio");
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
            if (txtSemestre.Text.Length != 1)
            {
                d = MessageBox.Show("Falta llenar el espacio Semestre!");
                return;
            }
            if (txtMatricula.Text.Length != 8)
            {
                d = MessageBox.Show("La matricula no es valida! (Tiene que ser un numero de 8 digitos)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtGrupo.Text.Length != 1)
            {
              
                d = MessageBox.Show("El grupo debe ser de una unidad (1 caracter)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Esta Seguro que Desea crear un nuevo Registro?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection cnn = new SqlConnection(STRcon);
                string STRsql = " INSERT INTO Alumnos (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Grupo,Semestre,Fec_Registro)" +
                 "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@gpo,@sem,@f_reg)";
                SqlCommand cmd = new SqlCommand(STRsql, cnn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mat", Convert.ToString(txtMatricula.Text.Trim()));
                cmd.Parameters.AddWithValue("@nom", Convert.ToString(txtNombre.Text.Trim()));
                cmd.Parameters.AddWithValue("@a_p", Convert.ToString(txtApellidoPaterno.Text.Trim()));
                cmd.Parameters.AddWithValue("@a_m", Convert.ToString(txtApellidoMaterno.Text.Trim()));
                cmd.Parameters.AddWithValue("@carrera", IDCarrera);
                cmd.Parameters.AddWithValue("@gpo", Convert.ToInt32(txtGrupo.Text.Trim()));
                cmd.Parameters.AddWithValue("@sem", Convert.ToInt32(txtSemestre.Text.Trim()));
                cmd.Parameters.AddWithValue("@f_reg", DateTime.Now);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                MessageBox.Show("Alumno registrado! Favor de inscribirse a continuacion");
                ReiniciarVentana();
            }
        }
        private void txtMatricula_KeyDown_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IngresarDatos();
            }
        }
        private void RefrescarBD()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = STRcon;
        }
        private void listaUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminLogin frm = new AdminLogin();
            frm.AccessType = 1;
            frm.con = STRcon;
            frm.ShowDialog();
        }
        private void txtGrupo_TextChanged(object sender, EventArgs e)
        {}

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void listaRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminLogin frm = new AdminLogin();
            frm.AccessType = 0;
            frm.con = STRcon;
            frm.ShowDialog();
            

        }
        private void GuardarDatos()
        {
            MessageBox.Show("Ya puedes pasar. Disfruta tu estadia!");
            SqlConnection cnn = new SqlConnection(STRcon);
            string STRsql = " INSERT INTO Registros (Alumno_Matricula,Fec_InicioSesion)" +
             "VALUES (@mat,@fec_sesion)";
            SqlCommand cmd = new SqlCommand(STRsql, cnn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mat", RegAlumnos["Matricula"]);
            cmd.Parameters.AddWithValue("@fec_sesion", DateTime.Now);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }
        private void ReiniciarVentana()
        {
            pnlRegistro.Visible = false;
            pnlMostrarDatos.Visible = false;
            txtMatricula.Text = null;
            groupBox1.Enabled = true;
            IDCarrera = 0;
        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                txtApellidoPaterno.Focus();
            }
        }

        private void txtSemestre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                btnAceptar.Focus();
            }
        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSemestre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                txtGrupo.Focus();
            }
        }

        private void txtApellidoMaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                cboCarrera.Focus();
            }
        }

        private void txtApellidoPaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                txtApellidoMaterno.Focus();
            }
        }
    }
}
