using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Registro_UAdeO_2023
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection();
            connection.ConnectionString = con;
            txtUsername.Focus();
        }

        private SqlDataAdapter BDAdmin;
        private DataSet TBAdmin;
        private DataRow RegAdmin;
        private SqlConnection connection;
        public string con;
        public int AccessType; // 0 para entrar a los registros de Usuario, 1 para entrar Registros de sesiónes
        private void btnLogin_Click(object sender, EventArgs e)
        {
            IngresarDatos();

        }
        private void IngresarDatos()
        {
            DialogResult d;
            if (txtUsername.Text.Trim() == "")
            {
                d = MessageBox.Show("El campo de Matricula esta vacio", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                d = MessageBox.Show("El campo de contraseña esta vacio", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string user = txtUsername.Text.Trim();
            string StrQuery = "SELECT Username,Password FROM Admin WHERE Username = '" + user + "'";
            SqlCommand cmd = new SqlCommand(StrQuery, connection);
            BDAdmin = new SqlDataAdapter(cmd);
            TBAdmin = new DataSet();
            BDAdmin.Fill(TBAdmin, "Admin");
            try
            {
                RegAdmin = TBAdmin.Tables["Admin"].Rows[0];
            }
            catch (Exception)
            {
                MessageBox.Show("EL Usuario / Contraseña es invalido");
            }
            if (txtUsername.Text.Trim() == Convert.ToString(RegAdmin["Username"]) && txtPassword.Text.Trim() == Convert.ToString(RegAdmin["Password"]))
                {
                    if (AccessType == 0)
                    {
                        AdminBusquedaAlumnos frm = new AdminBusquedaAlumnos();
                        frm.con = con;
                        Close();
                        frm.ShowDialog();
                    }
                    if (AccessType == 1)
                    {
                        AdminReportes frm = new AdminReportes();
                        frm.con = con;
                        Close();
                        frm.ShowDialog();
                    }
            }
            

        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                txtPassword.Focus();
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                IngresarDatos();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}