using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Registro_UAdeO_2023
{
    public partial class InicioUsuario : Form
    {
        public InicioUsuario()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDDocentes,BDAlumnos, BDCarrera, BDGenero;
        private DataSet TBDocentes,TBAlumnos, TBCarrera, TBGenero, TBFiltro;
        private DataRow RegDocentes,RegAlumnos, RegCarrera, RegGenero, RegFiltro;
        private int IDCarrera, IDGenero;
        protected string STRcon = " SERVER=.; DataBase=RegistroUAdeO; Integrated Security=SSPI";
        private SqlConnection cnn;
        public void InicioUsuario_Load(object sender, EventArgs e)
        {
            administradorToolStripMenuItem.Enabled = true;
            cboCarrera.Visible = false;
            menuStrip1.Visible = true;
            pnlRegistro.Visible = false;
            pnlMostrarDatos.Visible = false;
            cboCarrera.Text = "-Elige una carrera-";
            //cboCarrera.Items.Add("");
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
                    cnn = new SqlConnection(STRcon);
                    SqlCommand cmd = new SqlCommand(STRsql, cnn);
                    BDAlumnos = new SqlDataAdapter(cmd);
                    TBAlumnos = new DataSet();
                    try
                    {
                        BDAlumnos.Fill(TBAlumnos, "Alumnos");
                        RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];
                        if (txtMatricula.Text.Trim() == Convert.ToString(RegAlumnos["Matricula"]))
                        {
                            MostrarInfo();
                        }
                    }
                    catch (Exception)
                    {
                        d = MessageBox.Show("no esta registrado Alumno. Registrate!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboCarrera.Visible = true;
                        txtNombre.Text = "";
                        txtApellidoPaterno.Text = "";
                        txtApellidoMaterno.Text = "";
                        cboCarrera.Text = "";
                        txtSemestre.Text = "";
                        groupBox1.Enabled = false;
                        txtSemestre.Visible = true;
                        pnlRegistro.Visible = true;
                        SqlConnection cnn = new SqlConnection(STRcon);
                        /*
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
                        */
                        string STRSql2 = "SELECT NomGenero FROM Genero";
                        SqlCommand cmd1 = new SqlCommand(STRSql2, cnn);
                        BDGenero = new SqlDataAdapter(cmd1);
                        TBGenero = new DataSet();
                        BDGenero.Fill(TBGenero, "Genero");
                        RegGenero = TBGenero.Tables["Genero"].Rows[0];
                        for (int i = 0; i <= BindingContext[TBGenero, "Genero"].Count - 1; i++)
                        {
                            BindingContext[TBGenero, "Genero"].Position = i;
                            RegGenero = TBGenero.Tables["Genero"].Rows[i];
                            cboGenero.Items.Add(RegGenero["NomGenero"]);
                        }
                        txtNombre.Focus();
                    }
                    break;
                case 4:
                    // Inicio de sesion para maestros
                    STRsql = "SELECT * FROM Docentes WHERE Matricula = " + txtMatricula.Text.Trim();
                    cmd = new SqlCommand(STRsql, cnn);
                    BDDocentes = new SqlDataAdapter(cmd);
                    TBDocentes = new DataSet();
                    try
                    {
                        BDDocentes.Fill(TBDocentes, "Docentes");
                        RegDocentes = TBDocentes.Tables["Docentes"].Rows[0];
                        if (txtMatricula.Text.Trim() == Convert.ToString(RegDocentes["Matricula"]))
                        {
                            MostrarInfo();
                        }
                    }
                    catch (Exception)
                    {
                        d = MessageBox.Show("no esta registrado Docente. Registrate!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboCarrera.Visible = true;
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
                            cboCarrera.Items.Add(RegCarrera["NomLargo"]);
                            
                        }
                        txtNombre.Focus();
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
            VerificarMatricula();
        }
        private void MostrarInfo()
        {
            string STRSql;
            switch (txtMatricula.Text.Length)
            {
                
                case 8:
                    groupBox1.Enabled = false;
                    MessageBox.Show(txtMatricula.Text.Trim());
                    STRSql = "SELECT * FROM Alumnos WHERE Matricula = " + txtMatricula.Text.Trim();
                    SqlCommand cmd = new SqlCommand(STRSql, cnn);
                    BDAlumnos = new SqlDataAdapter(cmd);
                    TBAlumnos = new DataSet();
                    BDAlumnos.Fill(TBAlumnos, "Alumnos");
                    BindingContext[TBAlumnos, "Alumnos"].Position = 0;
                    RegAlumnos = TBAlumnos.Tables["Alumnos"].Rows[0];

                    STRSql = "SELECT NomLargo FROM Carrera WHERE Id=" + RegAlumnos["Carrera"];
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

                    STRSql = "SELECT NomLargo FROM Carrera WHERE ID=" + RegDocentes["Carrera"];
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
            string STRSql = "SELECT Id FROM Carrera WHERE NomLargo ='" + cboCarrera.Text + "'";
            SqlCommand cmd1 = new SqlCommand(STRSql, cnn);
            BDCarrera = new SqlDataAdapter(cmd1);
            TBCarrera = new DataSet();
            BDCarrera.Fill(TBCarrera, "Carrera");
            try
            {
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
                IDCarrera = Convert.ToInt32(RegCarrera["Id"]);
            }
            catch (Exception)
            {

            }
            
        }
        private void cboCarrera_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter)){
                cboGenero.Focus();
            }
            if ((e.KeyValue == Convert.ToChar(Keys.Down) && (cboCarrera.DroppedDown == false)))
            {
                cboCarrera.DroppedDown = true;
            }
            if ((e.KeyValue == Convert.ToChar(Keys.Up) && (cboCarrera.DroppedDown == true))) // Evita mover el indice para evitar fallos en el sistema
            {
                cboCarrera.DroppedDown = true;
            }
            if ((e.KeyValue == Convert.ToChar(Keys.Down) && (cboCarrera.DroppedDown == true))) // Evita mover el indice para evitar fallos en el sistema
            {
                cboCarrera.DroppedDown = true;
            }

        }
        private void cboGenero_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                txtSemestre.Focus();
            }
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
                    if (cboCarrera.Text.Trim() != Convert.ToString(RegCarrera["NomLargo"]))
                    {
                        d = MessageBox.Show("Falta elegir tu Carrera!");
                        return;
                    }

                    if (cboGenero.Text != Convert.ToString(RegGenero["NomGenero"]))
                    {
                        d = MessageBox.Show("Falta elegir tu Genero!");
                        return;
                    }
                    if (txtSemestre.Text.Length != 1)
                    {
                        d = MessageBox.Show("Falta llenar el espacio Semestre!");
                        return;
                    }
                   
                    SqlConnection cnn = new SqlConnection(STRcon);
                    string STRsql = " INSERT INTO Alumnos (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Semestre,Fec_Registro,Genero)" +
                    "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@sem,@f_reg,@Gen)";
                    SqlCommand cmd = new SqlCommand(STRsql, cnn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mat", Convert.ToString(txtMatricula.Text.Trim()));
                    cmd.Parameters.AddWithValue("@nom", Convert.ToString(txtNombre.Text.Trim()));
                    cmd.Parameters.AddWithValue("@a_p", Convert.ToString(txtApellidoPaterno.Text.Trim()));
                    cmd.Parameters.AddWithValue("@a_m", Convert.ToString(txtApellidoMaterno.Text.Trim()));
                    cmd.Parameters.AddWithValue("@carrera", IDCarrera);
                    cmd.Parameters.AddWithValue("@sem", Convert.ToInt32(txtSemestre.Text.Trim()));
                    cmd.Parameters.AddWithValue("@f_reg", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Gen", IDGenero);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close(); 
                    MessageBox.Show("Alumno registrado! Favor de inscribirse a continuacion");
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

                    cnn = new SqlConnection(STRcon);
                    STRsql = " INSERT INTO Docentes (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Fec_Registro)" +
                         "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@f_reg)";
                    cmd = new SqlCommand(STRsql, cnn);
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
                    string STRsql = "INSERT INTO Registros(Matricula, Nombres, Apellido_Paterno, Apellido_Materno, Carrera, Semestre, Fec_Registro, Fec_InicioSesion, Genero) " +
                        "VALUES (@mat,@nom,@a_p,@a_m,@carrera,@sem,@fec_Registro,@fec_sesion, @gen)";
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
                    cmd.Parameters.AddWithValue("@gen", RegAlumnos["Genero"]);
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
                    cmd.Parameters.AddWithValue("@gen", RegDocentes["Genero"]);
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
            cboCarrera.Visible = false;
         

            txtMatricula.Focus();
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

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(STRcon);
            string STRSql = "SELECT Id,NomGenero FROM Genero WHERE NomGenero = '" + cboGenero.Text.Trim() + "'";
            SqlCommand cmd1 = new SqlCommand(STRSql, cnn);
            BDGenero = new SqlDataAdapter(cmd1);
            TBGenero = new DataSet();
            BDGenero.Fill(TBGenero, "Genero");
            RegGenero = TBGenero.Tables["Genero"].Rows[0];
            IDGenero = Convert.ToInt32(RegGenero["Id"]);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboCarrera_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
        private void FiltrarDatos()
        {
            cboCarrera.Items.Clear();
            try
            {
                string STRsql = "SELECT NomLargo FROM Carrera WHERE NomLargo LIKE '%" + cboCarrera.Text.Trim() + "%' OR NomCorto LIKE '%" + cboCarrera.Text.Trim() + "%'";
                SqlConnection cnn = new SqlConnection(STRcon);
                SqlCommand cmd = new SqlCommand(STRsql, cnn);
                SqlDataAdapter BDFiltro = new SqlDataAdapter(cmd);
                TBFiltro = new DataSet();
                BDFiltro.Fill(TBFiltro, "Carrera");
            }
            catch (Exception) { return; }
            for (int i = 0; i <= BindingContext[TBFiltro, "Carrera"].Count - 1; i++)
            {
                RegFiltro = TBFiltro.Tables["Carrera"].Rows[i];
                cboCarrera.Items.Add(RegFiltro["NomLargo"]);
            }
            try
            {
                cboCarrera.DroppedDown = true;
                cboCarrera.Select(cboCarrera.Text.Length, cboCarrera.Text.Length);
            }
            catch (Exception) { }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                VerificarMatricula();
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
        
        private void txtSemestre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                btnAceptar.Focus();
            }
        }
        private void VerificarMatricula() {
            if (txtMatricula.Text.Length == 8)
            {
                string matricula = txtMatricula.Text.Trim();
                string generacionActual = Convert.ToString(DateTime.Now).Substring(8, 2);
                string UnidadRegional = "04";
                //MessageBox.Show(generacionActual + " + " + UnidadRegional + " + ");                     //debug
                //MessageBox.Show(matricula.Substring(2, 2),"Unidad regional verificacion" );             //debug
                if ((Convert.ToInt32(matricula.Substring(0, 2)) <= Convert.ToInt32(generacionActual)&& (Convert.ToInt32(matricula.Substring(0, 2))>=8))) { // Validacion de matricula
                    if(matricula.Substring(2, 2) == UnidadRegional) { // Validacion de Unidad regiomal
                        //MessageBox.Show("Tu matricula es valida");                                      //debug
                    }
                    else {
                        MessageBox.Show("Tu matricula es Invalida (Unidad Regional");
                        return;
                    }                   
                }
                else {
                    MessageBox.Show("Tu matricula es Invalida (Generacion)");
                    return; 
                }
            }
           IngresarDatos();
        }

        private void InicioUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
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
