using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Registro_UAdeO_2023
{
    public partial class InicioUsuario : Form
    {
        public InicioUsuario()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDDocentes,BDAlumnos, BDCarrera;
        private DataSet TBDocentes,TBAlumnos, TBCarrera;
        private DataRow RegDocentes,RegAlumnos, RegCarrera;
        private int IDCarrera;
        protected string STRcon = " SERVER=.; DataBase=RegistroUAdeO; Integrated Security=SSPI";
        private SqlConnection cnn;
        public void InicioUsuario_Load(object sender, EventArgs e)
        {
            administradorToolStripMenuItem.Enabled = true;
            menuStrip1.Visible = true;
            pnlRegistro.Visible = false;
            pnlMostrarDatos.Visible = false;
            cboCarrera.Text = "-Elige una carrera-";
            RefrescarBD();
        }
        private void IngresarDatos()
        {
            DialogResult d;
            switch(txtMatricula.Text.Length)
            {
                case 8:
                    // Inicio de sesion para alumnos
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

                        txtNombre.Text = "";
                        txtApellidoPaterno.Text = "";
                        txtApellidoMaterno.Text = "";
                        cboCarrera.Text = "";
                        
                        txtSemestre.Text = "";
                        groupBox1.Enabled = false;
                        txtSemestre.Visible = true;
                        
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
                            if (Convert.ToString(RegCarrera["NomLargo"]) == "MAESTRO" && Convert.ToString(RegCarrera["NomLargo"]) == "DOCENTE")
                            {
                                continue;
                            }
                            cboCarrera.Items.Add(RegCarrera["NomLargo"]);
                            //
                        }
                    }
                    break;
                case 4:
                    // Inicio de sesion para maestros
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
                        d = MessageBox.Show("no esta registrado Docente. Registrate!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        groupBox1.Enabled = false;
                        pnlRegistro.Visible = true;
                        txtSemestre.Visible = false;
                        label10.Visible = false;
                        
                        
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
                            if (Convert.ToString(RegCarrera["NomLargo"]) == "MAESTRO" || Convert.ToString(RegCarrera["NomLargo"]) == "DOCENTE")
                            {
                                cboCarrera.Items.Add(RegCarrera["NomLargo"]);
                            }
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Debes escribir almenos 4 caracteres");
                    break;
            }
            RefrescarBD();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IngresarDatos();
        }
        private void MostrarInfo()
        {
            
            switch (txtMatricula.Text.Length)
            {
                
                case 8:
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
                    lblNombres.Text = "" + Convert.ToString(RegAlumnos["Nombres"]) + " " + Convert.ToString(RegAlumnos["Apellido_Paterno"]) + " " + Convert.ToString(RegAlumnos["Apellido_Materno"]) + "";
                    lblCarrera.Text = "" + Convert.ToString(RegCarrera["NomLargo"]) + "";
                    lblSemestre.Text = "" + Convert.ToString(RegAlumnos["Semestre"]) + "";
                    pnlMostrarDatos.Visible = true;
                    GuardarDatos();
                    ReiniciarVentana();
                 break;

                  case 4:
                    groupBox1.Enabled = false;
                    STRSql = "SELECT * FROM Docentes WHERE Matricula = " + txtMatricula.Text.Trim();
                    cnn = new SqlConnection(STRcon);
                    cmd = new SqlCommand(STRSql, cnn);
                    BDDocentes = new SqlDataAdapter(cmd);
                    TBDocentes = new DataSet();
                    BDDocentes.Fill(TBDocentes, "Docentes");
                    BindingContext[TBDocentes, "Docentes"].Position = 0;
                    RegDocentes = TBDocentes.Tables["Docentes"].Rows[0];

                    STRSql2 = "SELECT NomLargo FROM Carrera WHERE ID=" + RegDocentes["Carrera"];
                    cmd1 = new SqlCommand(STRSql2, cnn);
                    BDCarrera = new SqlDataAdapter(cmd1);
                    TBCarrera = new DataSet();
                    BDCarrera.Fill(TBCarrera, "Carrera");
                    RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
                    for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
                    {
                        BindingContext[TBCarrera, "Carrera"].Position = i;
                        RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
                    }
                    lblNombres.Text = "" + Convert.ToString(RegDocentes["Nombres"]) + " " + Convert.ToString(RegDocentes["Apellido_Paterno"]) + " " + Convert.ToString(RegDocentes["Apellido_Materno"]) + "";
                    lblCarrera.Text = "" + Convert.ToString(RegCarrera["NomLargo"]) + "";
                    label9.Visible = false;
                    lblSemestre.Visible = false;
                    pnlMostrarDatos.Visible = true;
                    GuardarDatos();
                    ReiniciarVentana();

                    break;

                default:
                    MessageBox.Show("Debes escribir almenos 8 caracteres");
                    break;
            }
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
            if (e.KeyValue == Convert.ToChar(Keys.Enter)){
                txtSemestre.Focus();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e){
            ReiniciarVentana();
        }

        private void btnAceptar_Click(object sender, EventArgs e){
            DialogResult d;
            switch (txtMatricula.Text.Length)
            {
                case 8:
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
                    if (cboCarrera.Text == "MAESTRO" || cboCarrera.Text == "DOCENTE")
                    {
                        d = MessageBox.Show("No puedes elegir Maestro o Docente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   
                    if (MessageBox.Show("¿Esta Seguro que Desea crear un nuevo Registro?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection cnn = new SqlConnection(STRcon);
                        string STRsql = " INSERT INTO Alumnos (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Semestre,Fec_Registro)" +
                         "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@sem,@f_reg)";
                        SqlCommand cmd = new SqlCommand(STRsql, cnn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@mat", Convert.ToString(txtMatricula.Text.Trim()));
                        cmd.Parameters.AddWithValue("@nom", Convert.ToString(txtNombre.Text.Trim()));
                        cmd.Parameters.AddWithValue("@a_p", Convert.ToString(txtApellidoPaterno.Text.Trim()));
                        cmd.Parameters.AddWithValue("@a_m", Convert.ToString(txtApellidoMaterno.Text.Trim()));
                        cmd.Parameters.AddWithValue("@carrera", IDCarrera);
                        cmd.Parameters.AddWithValue("@sem", Convert.ToInt32(txtSemestre.Text.Trim()));
                        cmd.Parameters.AddWithValue("@f_reg", DateTime.Now);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close(); 
                        MessageBox.Show("Alumno registrado! Favor de inscribirse a continuacion");
                    }
                        break;
                case 4:
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
                    if (cboCarrera.Text == null)
                    {
                        d = MessageBox.Show("Falta llenar el apellido materno!");
                        return;
                    }

                    if (MessageBox.Show("¿Esta Seguro que Desea crear un nuevo Registro?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection cnn = new SqlConnection(STRcon);
                        string STRsql = " INSERT INTO Docentes (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Fec_Registro)" +
                         "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@f_reg)";
                        SqlCommand cmd = new SqlCommand(STRsql, cnn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@mat", Convert.ToString(txtMatricula.Text.Trim()));
                        cmd.Parameters.AddWithValue("@nom", Convert.ToString(txtNombre.Text.Trim()));
                        cmd.Parameters.AddWithValue("@a_p", Convert.ToString(txtApellidoPaterno.Text.Trim()));
                        cmd.Parameters.AddWithValue("@a_m", Convert.ToString(txtApellidoMaterno.Text.Trim()));
                        cmd.Parameters.AddWithValue("@carrera", IDCarrera);
                      
                        cmd.Parameters.AddWithValue("@f_reg", DateTime.Now);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        
                    }
                    break;
                default:
                    break;
            }
            ReiniciarVentana();
        }
        private void txtMatricula_KeyDown_Enter(object sender, KeyEventArgs e)
        {
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
            frm.Show();
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
        private void listaRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminLogin frm = new AdminLogin();
            frm.AccessType = 0;
            frm.con = STRcon;
            frm.Show();


        }
        private void GuardarDatos()
        {
            SqlConnection cnn = new SqlConnection(STRcon);
            switch(txtMatricula.Text.Length){
                case 8:
                    string STRsql = "INSERT INTO Registros(Matricula, Nombres, Apellido_Paterno, Apellido_Materno, Carrera, Semestre, Fec_Registro, Fec_InicioSesion) " +
                        "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@sem,@fec_Registro,@fec_sesion)";
                    SqlCommand cmd = new SqlCommand(STRsql, cnn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mat", RegAlumnos["Matricula"]);
                    cmd.Parameters.AddWithValue("@nom", RegAlumnos["Nombres"]);
                    cmd.Parameters.AddWithValue("@a_p", RegAlumnos["Apellido_Paterno"]);
                    cmd.Parameters.AddWithValue("@a_m", RegAlumnos["Apellido_Materno"]);
                    cmd.Parameters.AddWithValue("@carrera", RegAlumnos["Carrera"]);
                    cmd.Parameters.AddWithValue("@sem", RegAlumnos["Semestre"]);
                    cmd.Parameters.AddWithValue("@fec_registro", RegAlumnos["Fec_Registro"]);
                    cmd.Parameters.AddWithValue("@fec_sesion", DateTime.Now);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    break;
                case 4:
                    STRsql = "INSERT INTO Registros (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Semestre,Fec_Registro,Fec_InicioSesion) " +
                        "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@sem,@fec_Registro,@fec_sesion)";
                    cmd = new SqlCommand(STRsql, cnn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mat", RegDocentes["Matricula"]);
                    cmd.Parameters.AddWithValue("@nom", RegDocentes["Nombres"]);
                    cmd.Parameters.AddWithValue("@a_p", RegDocentes["Apellido_Paterno"]);
                    cmd.Parameters.AddWithValue("@a_m", RegDocentes["Apellido_Materno"]);
                    cmd.Parameters.AddWithValue("@carrera", RegDocentes["Carrera"]);
                    cmd.Parameters.AddWithValue("@sem", 0);
                    cmd.Parameters.AddWithValue("@fec_registro", RegDocentes["Fec_Registro"]);
                    cmd.Parameters.AddWithValue("@fec_sesion", DateTime.Now);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    break;
            }
            MessageBox.Show("Ya puedes pasar. Disfruta tu estadia!");
        }
        private void ReiniciarVentana()
        {
            pnlRegistro.Visible = false;
            pnlMostrarDatos.Visible = false;
            txtMatricula.Text = null;
            groupBox1.Enabled = true;
            label10.Visible = true;
            
            IDCarrera = 0;
            label9.Visible = true;
            lblSemestre.Visible = true;
            txtNombre.Text = null;
            txtApellidoPaterno.Text = null;
            txtApellidoMaterno.Text = null;
            txtSemestre.Text = null;
            cboCarrera.Items.Clear();
            cboCarrera.Text = "-Elige una carrera-";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblSemestre_Click(object sender, EventArgs e)
        {

        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
        private void txtMatricula_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //VerificarMatricula();
                MostrarInfo();
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            if (!char.IsNumber((char)e.KeyChar))
            {
                e.Handled = true;
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
                
            }
        }
        private void InicioUsuario_KeyPress(object sender, KeyEventArgs e) {
            if (e.KeyValue == Convert.ToChar(Keys.Escape)) {
                ReiniciarVentana();
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
