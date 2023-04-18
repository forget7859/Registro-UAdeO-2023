using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Registro_UAdeO_2023
{
    public partial class InicioUsuario : Form
    {
        public InicioUsuario()
        {
            InitializeComponent();
        }
        private SqlDataAdapter BDDocentes, BDAlumnos, BDCarrera, BDGenero;
        private DataSet TBDocentes, TBAlumnos, TBCarrera, TBGenero, TBFiltro;
        private DataRow RegDocentes, RegAlumnos, RegCarrera, RegGenero, RegFiltro;
        private int IDCarrera, IDGenero;
        private bool UsuarioInvitado = false;
        protected string STRcon = "SERVER=.; DataBase=RegistroUAdeO; Integrated Security=SSPI";
        private SqlConnection cnn;
        public void InicioUsuario_Load(object sender, EventArgs e)
        {
            administradorToolStripMenuItem.Enabled = true;
            cboCarrera.Visible = false;
            menuStrip1.Visible = true;
            pnlRegistro.Visible = false;
            pnlMostrarDatos.Visible = false;


            string STRSql = "SELECT NomLargo FROM Carrera";
            SqlConnection cnn = new SqlConnection(STRcon);
            SqlCommand cmd = new SqlCommand(STRSql, cnn);
            BDCarrera = new SqlDataAdapter(cmd);
            TBCarrera = new DataSet();
            BDCarrera.Fill(TBCarrera, "Carrera");
            RegCarrera = TBCarrera.Tables["Carrera"].Rows[0];
            for (int i = 0; i <= BindingContext[TBCarrera, "Carrera"].Count - 1; i++)
            {
                BindingContext[TBCarrera, "Carrera"].Position = i;
                RegCarrera = TBCarrera.Tables["Carrera"].Rows[i];
                cboCarrera.Items.Add(RegCarrera["NomLargo"]);
            }
            //cboCarrera.Items.Add("");
            RefrescarBD();
        }
        private void IngresarDatos() // Funcion que solicita a la base de datos el alumno o docente o inicia el registro de nuevo alumno
        {
            DialogResult d;
            if (UsuarioInvitado == false)
            {
                switch (txtMatricula.Text.Length)
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
                            cboGenero.Text = "";
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
                            cboGenero.Items.Clear();
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
                            STRSql2 = "SELECT NomGenero FROM Genero";
                            cmd1 = new SqlCommand(STRSql2, cnn);
                            BDGenero = new SqlDataAdapter(cmd1);
                            TBGenero = new DataSet();
                            BDGenero.Fill(TBGenero, "Genero");
                            RegGenero = TBGenero.Tables["Genero"].Rows[0];
                            cboGenero.Items.Clear();
                            for (int i = 0; i <= BindingContext[TBGenero, "Genero"].Count - 1; i++)
                            {
                                BindingContext[TBGenero, "Genero"].Position = i;
                                RegGenero = TBGenero.Tables["Genero"].Rows[i];
                                cboGenero.Items.Add(RegGenero["NomGenero"]);
                            }
                            txtNombre.Focus();
                        }
                        break;
                    default:
                        MessageBox.Show("Debes escribir almenos 4 caracteres");
                        break;
                }
            }
            else
            {

            }
            RefrescarBD();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            VerificarMatricula();
        }
        private void MostrarInfo() // Metodo que se encarga de mostrar en un cuadro gris tu informacion al momento de ingresar tu matricula
        {
            string STRSql;
            if (UsuarioInvitado == false)
            {
                switch (txtMatricula.Text.Length)
                {
                    case 8:
                        groupBox1.Enabled = false;
                        //MessageBox.Show(txtMatricula.Text.Trim());
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

                        STRSql = "SELECT NomLargo FROM Carrera WHERE Id=" + RegDocentes["Carrera"];
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
                }

            }
            else {
                lblNombres.Text = "" + txtNombre.Text.Trim() + " " + txtApellidoPaterno.Text.Trim() + " "+ txtApellidoMaterno.Text.Trim()+"";
                lblCarrera.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                lblSemestre.Visible = false;
                pnlMostrarDatos.Visible = true;
                MessageBox.Show("Bienvenido! Ya puede pasar.");
                GuardarDatos();

                ReiniciarVentana();
            }
        } 
        private void cboCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(STRcon);
            string STRSql = "SELECT Id,NomLargo FROM Carrera WHERE NomLargo ='" + cboCarrera.Text + "'";
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
            if ((e.KeyValue == Convert.ToChar(Keys.Enter) && (cboCarrera.DroppedDown == false)))
            {
                if (!(cboCarrera.Text == "" || cboCarrera.Text == null))
                {
                    cboGenero.Focus();
                }
            }
            if(!(cboCarrera.DropDownHeight == 0))
            {
                cboCarrera.DropDownHeight = 1+(cboCarrera.Items.Count * cboCarrera.Height);
            }

            cboCarrera.DroppedDown = true;
            FiltrarDatos();
        }
        private void cboGenero_KeyDown(Object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == Convert.ToChar(Keys.Enter) && (cboGenero.DroppedDown == false)))
            {
                if (cboGenero.Text == "" || cboGenero.Text == null)
                {
                    FiltrarDatos();
                }
                else
                {
                    btnAceptar.Focus();
                }
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult d;
            if (UsuarioInvitado == false)
            {
                bool retorno = false;
                string mensaje = "Falta llenar los siguientes campos:\n";
                switch (txtMatricula.Text.Length)
                {
                    case 8:
                        if (txtNombre.Text == null || txtNombre.Text == "")
                        {
                            mensaje = mensaje + "- Nombre\n";

                            txtNombre.BackColor = Color.Yellow;
                            retorno = true;
                        }
                        else { txtNombre.BackColor = Color.White; }

                        if (txtApellidoPaterno.Text == null || txtApellidoPaterno.Text == "")
                        {
                            mensaje = mensaje + "- Apellido Paterno\n";
                            txtApellidoPaterno.BackColor = Color.Yellow;
                            retorno = true;
                        }
                        else { txtApellidoPaterno.BackColor = Color.White; }

                        if (cboCarrera.Text.Trim() != Convert.ToString(RegCarrera["NomLargo"]))
                        {
                            mensaje = mensaje + "- Carrera\n";
                            cboCarrera.BackColor = Color.Yellow;
                            retorno = true;
                        }
                        else { cboGenero.BackColor = Color.White; }

                        if (cboGenero.Text != Convert.ToString(RegGenero["NomGenero"]))
                        {
                            mensaje = mensaje + "- Genero\n";
                            cboGenero.BackColor = Color.Yellow;
                            retorno = true;
                        }
                        else { cboGenero.BackColor = Color.White; }

                        if (txtSemestre.Text.Length != 1)
                        {
                            mensaje = mensaje + "- Semestre\n";
                            txtSemestre.BackColor = Color.Yellow;
                            retorno = true;
                        }
                        else { txtSemestre.BackColor = Color.White; }

                        if (retorno == true)
                        {
                            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        break;
                    case 4:
                        if (txtNombre.Text == null || txtNombre.Text == "")
                        {
                            d = MessageBox.Show("El espacio Nombre está vacio");
                            return;
                        }
                        if (txtApellidoPaterno.Text == null || txtApellidoPaterno.Text == "")
                        {
                            d = MessageBox.Show("Falta llenar el apellido paterno!");
                            return;
                        }
                        if (cboCarrera.Text.Trim() != Convert.ToString(RegCarrera["NomLargo"]))
                        {
                            d = MessageBox.Show("Error en el cuadro carrera.n Por favor abre el cuadro y elige tu carrera.\nTambien puedes escribir la carrera y abrir el recuadro para filtrar las carreras.");
                            return;
                        }

                        if (cboGenero.Text != Convert.ToString(RegGenero["NomGenero"]))
                        {
                            d = MessageBox.Show("Error en el cuadro Genero.n Por favor abre el cuadro y elige tu carrera.");
                            return;
                        }

                        cnn = new SqlConnection(STRcon);
                        STRsql = "INSERT INTO Docentes (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Carrera,Fec_Registro)" +
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
                MostrarInfo();
            }
            else {
                if (txtNombre.Text == null || txtNombre.Text == "")
                {
                    d = MessageBox.Show("El espacio Nombre está vacio");
                    return;
                }
                if (txtApellidoPaterno.Text == null || txtApellidoPaterno.Text == "")
                {
                    d = MessageBox.Show("Falta llenar el apellido paterno!");
                    return;
                }
                
                if (cboGenero.Text != Convert.ToString(RegGenero["NomGenero"]))
                {
                    d = MessageBox.Show("Error en el cuadro Genero.n Por favor abre el cuadro y elige tu carrera.");
                    return;
                }

                SqlConnection cnn = new SqlConnection(STRcon);
                string STRsql = "INSERT INTO Registros (Matricula,Nombres,Apellido_Paterno,Apellido_Materno,Genero,Fec_Registro)" +
                     "VALUES (@mat,@nom,@a_p,@a_m,@gen,@f_reg)";
                SqlCommand cmd = new SqlCommand(STRsql, cnn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mat", "INVITADO");
                cmd.Parameters.AddWithValue("@nom", Convert.ToString(txtNombre.Text.Trim()));
                cmd.Parameters.AddWithValue("@a_p", Convert.ToString(txtApellidoPaterno.Text.Trim()));
                cmd.Parameters.AddWithValue("@a_m", Convert.ToString(txtApellidoMaterno.Text.Trim()));
                cmd.Parameters.AddWithValue("@gen", IDGenero);
                cmd.Parameters.AddWithValue("@f_reg", DateTime.Now);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            MostrarInfo();
            ReiniciarVentana();
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
        private void cboCarrera_TabIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void cboCarrera_Enter(object sender, EventArgs e)
        {
            cboCarrera.DroppedDown = true;
            cboGenero.Focus();
        }
        private void cboGenero_Enter(object sender, EventArgs e)
        {
            cboGenero.DroppedDown = true;
            if(!(UsuarioInvitado == true))
            {
                cboGenero.Focus();
            }
            else
            {
                btnAceptar.Focus();
            }

        }
        private void GuardarDatos()
        {
            SqlConnection cnn = new SqlConnection(STRcon);
            if (UsuarioInvitado == true)
            {
                string STRsql = "INSERT INTO Registros(Matricula, Nombres, Apellido_Paterno, Apellido_Materno, Fec_InicioSesion, Genero) " +
                        "VALUES (@mat,@nom,@a_p,@a_m,@fec_sesion,@gen)";
                SqlCommand cmd = new SqlCommand(STRsql, cnn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mat", "INVITADO");
                cmd.Parameters.AddWithValue("@nom", RegAlumnos["Nombres"]);
                cmd.Parameters.AddWithValue("@a_p", RegAlumnos["Apellido_Paterno"]);
                cmd.Parameters.AddWithValue("@a_m", RegAlumnos["Apellido_Materno"]);
                cmd.Parameters.AddWithValue("@fec_sesion", DateTime.Now);
                cmd.Parameters.AddWithValue("@gen", RegAlumnos["Genero"]);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                MessageBox.Show("Ya puedes pasar. Disfruta tu estadia!");
            }
            switch (txtMatricula.Text.Length)
            {
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
            cboGenero.Items.Clear();
            cboGenero.Visible = true;
            txtMatricula.Focus();
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
        private void InicioUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ReiniciarVentana();
            }
        }
        private void FiltrarDatos()
        {
            string carrera = cboCarrera.Text;
            cboCarrera.Items.Clear();
            cboCarrera.Text = carrera;
            string STRsql;
            if (cboCarrera.Text == "" || cboCarrera == null)
            {
                STRsql = "SELECT NomLargo FROM Carrera ORDER BY NomLargo ASC";
            }
            else
            {
                STRsql = "SELECT NomLargo FROM Carrera WHERE NomLargo LIKE '%" + cboCarrera.Text.Trim() + "%' OR NomCorto LIKE '%" + cboCarrera.Text.Trim() + "%' ORDER BY NomLargo ASC";
            }
            SqlConnection cnn = new SqlConnection(STRcon);
            SqlCommand cmd1 = new SqlCommand(STRsql, cnn);
            SqlDataAdapter BDFiltro = new SqlDataAdapter(cmd1);
            TBFiltro = new DataSet();
            BDFiltro.Fill(TBFiltro, "Carrera");
            try
            {
                for (int i = 0; i <= BindingContext[TBFiltro, "Carrera"].Count - 1; i++)
                {
                    RegFiltro = TBFiltro.Tables["Carrera"].Rows[i];
                    cboCarrera.Items.Add(RegFiltro["NomLargo"]);
                }
                cboCarrera.Select(cboCarrera.Text.Length, cboCarrera.Text.Length);
                cboCarrera.DroppedDown = true;
            }
            catch (Exception) { }
        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                txtApellidoPaterno.Focus();
            }
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
        private void VerificarMatricula()
        {
            if (txtMatricula.Text.Length == 8)
            {
                string matricula = txtMatricula.Text.Trim();
                string generacionActual = Convert.ToString(DateTime.Now).Substring(8, 2);
                string UnidadRegional = "04";
                //MessageBox.Show(generacionActual + " + " + UnidadRegional + " + ");                     //debug
                //MessageBox.Show(matricula.Substring(2, 2),"Unidad regional verificacion" );             //debug
                if ((Convert.ToInt32(matricula.Substring(0, 2)) <= Convert.ToInt32(generacionActual) && (Convert.ToInt32(matricula.Substring(0, 2)) >= 8)))
                { // Validacion de matricula
                    if (matricula.Substring(2, 2) == UnidadRegional)
                    { // Validacion de Unidad regiomal
                        //MessageBox.Show("Tu matricula es valida");                                      //debug
                    }
                    else
                    {
                        MessageBox.Show("Tu matricula es Invalida (Unidad Regional");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Tu matricula es Invalida (Generacion)");
                    return;
                }
            }
            IngresarDatos();
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