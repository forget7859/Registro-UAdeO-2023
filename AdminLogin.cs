using Registro_UAdeO_2023;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Registro_UAdeO_2003
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDAdmin;
        private DataSet TBAdmin;
        private DataRow RegAdmin;
        private SqlConnection connection;
        public string con;
        public int AccessType; // 0 para entrar a los registros de Usuario, 1 para entrar Registros de sesiónes
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d;
            //if ((txtAdminMatricula.Text == "") && (txtcontraseña.Text == ""))
            //{
                //dialog.showAlert("Alerta!", "No has llenado tu matricula y contraseña");
                //d = MessageBox.Show("Los campos estan vacios", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
            //}
            if (txtPassword.Text.Trim() == null)
            {
                d = MessageBox.Show("El campo de contraseña esta vacio", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtUsername.Text.Trim() == null)
            {
                d = MessageBox.Show("El campo de Matricula esta vacio", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string user = txtUsername.Text.Trim();
            MessageBox.Show(user);
            string StrQuery = "SELECT Username,Password FROM Admin WHERE Username = '"+ user + "'";
            SqlCommand cmd = new SqlCommand(StrQuery, connection);
            BDAdmin = new SqlDataAdapter(cmd);
            TBAdmin = new DataSet();
            BDAdmin.Fill(TBAdmin, "Admin");
            RegAdmin = TBAdmin.Tables["Admin"].Rows[0];
            if (txtUsername.Text.Trim() == Convert.ToString(RegAdmin["Username"]) && txtPassword.Text.Trim() == Convert.ToString(RegAdmin["Password"]))
            {
                if (AccessType == 0)
                {
                    AdminBusquedaAlumnos frm = new AdminBusquedaAlumnos();
                    frm.con = con;
                    frm.ShowDialog();
                }
                if (AccessType == 1)
                {
                    AdminListaRegistros frm = new AdminListaRegistros();
                    frm.con = con;
                    frm.ShowDialog();
                }
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection();
            connection.ConnectionString = con;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
