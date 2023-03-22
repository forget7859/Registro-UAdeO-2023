using System;
using System.Windows.Forms;
//
namespace Registro_UAdeO_2023
{
    partial class InicioUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioUsuario));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaRegistrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRegistro = new System.Windows.Forms.Panel();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtSemestre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboCarrera = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlMostrarDatos = new System.Windows.Forms.Panel();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlRegistro.SuspendLayout();
            this.pnlMostrarDatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administradorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaRegistrosToolStripMenuItem,
            this.listaUsuariosToolStripMenuItem});
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.administradorToolStripMenuItem.Text = "Administrador";
            this.administradorToolStripMenuItem.Click += new System.EventHandler(this.administradorToolStripMenuItem_Click);
            // 
            // listaRegistrosToolStripMenuItem
            // 
            this.listaRegistrosToolStripMenuItem.Name = "listaRegistrosToolStripMenuItem";
            this.listaRegistrosToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.listaRegistrosToolStripMenuItem.Text = "Lista Registros";
            this.listaRegistrosToolStripMenuItem.Click += new System.EventHandler(this.listaRegistrosToolStripMenuItem_Click);
            // 
            // listaUsuariosToolStripMenuItem
            // 
            this.listaUsuariosToolStripMenuItem.Name = "listaUsuariosToolStripMenuItem";
            this.listaUsuariosToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.listaUsuariosToolStripMenuItem.Text = "Lista Usuarios";
            this.listaUsuariosToolStripMenuItem.Click += new System.EventHandler(this.listaUsuariosToolStripMenuItem_Click);
            // 
            // pnlRegistro
            // 
            this.pnlRegistro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlRegistro.BackColor = System.Drawing.SystemColors.Control;
            this.pnlRegistro.Controls.Add(this.cboGenero);
            this.pnlRegistro.Controls.Add(this.lblGenero);
            this.pnlRegistro.Controls.Add(this.txtSemestre);
            this.pnlRegistro.Controls.Add(this.label10);
            this.pnlRegistro.Controls.Add(this.cboCarrera);
            this.pnlRegistro.Controls.Add(this.btnAceptar);
            this.pnlRegistro.Controls.Add(this.txtApellidoMaterno);
            this.pnlRegistro.Controls.Add(this.txtApellidoPaterno);
            this.pnlRegistro.Controls.Add(this.txtNombre);
            this.pnlRegistro.Controls.Add(this.label7);
            this.pnlRegistro.Controls.Add(this.label3);
            this.pnlRegistro.Controls.Add(this.label2);
            this.pnlRegistro.Controls.Add(this.label6);
            this.pnlRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRegistro.Location = new System.Drawing.Point(15, 332);
            this.pnlRegistro.Name = "pnlRegistro";
            this.pnlRegistro.Size = new System.Drawing.Size(773, 164);
            this.pnlRegistro.TabIndex = 12;
            // 
            // cboGenero
            // 
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(281, 128);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(261, 33);
            this.cboGenero.TabIndex = 7;
            this.cboGenero.SelectedIndexChanged += new System.EventHandler(this.cboGenero_SelectedIndexChanged);
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(373, 100);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(83, 25);
            this.lblGenero.TabIndex = 29;
            this.lblGenero.Text = "Genero";
            this.lblGenero.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtSemestre
            // 
            this.txtSemestre.Location = new System.Drawing.Point(712, 71);
            this.txtSemestre.MaxLength = 1;
            this.txtSemestre.Name = "txtSemestre";
            this.txtSemestre.Size = new System.Drawing.Size(48, 31);
            this.txtSemestre.TabIndex = 8;
            this.txtSemestre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSemestre_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(590, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 25);
            this.label10.TabIndex = 28;
            this.label10.Text = "Semestre";
            // 
            // cboCarrera
            // 
            this.cboCarrera.FormattingEnabled = true;
            this.cboCarrera.Location = new System.Drawing.Point(3, 128);
            this.cboCarrera.Name = "cboCarrera";
            this.cboCarrera.Size = new System.Drawing.Size(261, 33);
            this.cboCarrera.TabIndex = 6;
            this.cboCarrera.SelectedIndexChanged += new System.EventHandler(this.cboCarrera_SelectedIndexChanged);
            this.cboCarrera.TextChanged += new System.EventHandler(this.cboCarrera_TextChanged);
            this.cboCarrera.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCarrera_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(595, 115);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(175, 46);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidoMaterno.Location = new System.Drawing.Point(595, 34);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(165, 31);
            this.txtApellidoMaterno.TabIndex = 5;
            this.txtApellidoMaterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApellidoMaterno_KeyDown);
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidoPaterno.Location = new System.Drawing.Point(333, 34);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(169, 31);
            this.txtApellidoPaterno.TabIndex = 4;
            this.txtApellidoPaterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApellidoPaterno_KeyDown);
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(0, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(264, 31);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Carrera";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Apellido Materno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(590, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Apellido Paterno";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nombre (s)";
            // 
            // pnlMostrarDatos
            // 
            this.pnlMostrarDatos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlMostrarDatos.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMostrarDatos.Controls.Add(this.lblSemestre);
            this.pnlMostrarDatos.Controls.Add(this.lblCarrera);
            this.pnlMostrarDatos.Controls.Add(this.lblNombres);
            this.pnlMostrarDatos.Controls.Add(this.label9);
            this.pnlMostrarDatos.Controls.Add(this.label8);
            this.pnlMostrarDatos.Controls.Add(this.label4);
            this.pnlMostrarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMostrarDatos.Location = new System.Drawing.Point(12, 215);
            this.pnlMostrarDatos.Name = "pnlMostrarDatos";
            this.pnlMostrarDatos.Size = new System.Drawing.Size(773, 111);
            this.pnlMostrarDatos.TabIndex = 11;
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(136, 80);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(146, 31);
            this.lblSemestre.TabIndex = 33;
            this.lblSemestre.Text = "[Semestre]";
            this.lblSemestre.Click += new System.EventHandler(this.lblSemestre_Click);
            // 
            // lblCarrera
            // 
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Location = new System.Drawing.Point(136, 40);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(122, 31);
            this.lblCarrera.TabIndex = 32;
            this.lblCarrera.Text = "[Carrera]";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(136, 0);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(140, 31);
            this.lblNombres.TabIndex = 31;
            this.lblNombres.Text = "[Nombres]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 31);
            this.label9.TabIndex = 30;
            this.label9.Text = "Semestre: ";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 31);
            this.label8.TabIndex = 29;
            this.label8.Text = "Carrera: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 31);
            this.label4.TabIndex = 28;
            this.label4.Text = "Nombres: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese su matricula:";
            // 
            // txtMatricula
            // 
            this.txtMatricula.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMatricula.Location = new System.Drawing.Point(274, 53);
            this.txtMatricula.MaxLength = 8;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(261, 38);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(274, 115);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(261, 44);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "&Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnIngresar);
            this.groupBox1.Controls.Add(this.txtMatricula);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 159);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese los siguientes datos por favor";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label11.Location = new System.Drawing.Point(12, 499);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Ver. beta 0.1.0";
            // 
            // InicioUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = global::Registro_UAdeO_2023.Properties.Resources.Lince_Circul;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnlRegistro);
            this.Controls.Add(this.pnlMostrarDatos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InicioUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio Usuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InicioUsuario_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InicioUsuario_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlRegistro.ResumeLayout(false);
            this.pnlRegistro.PerformLayout();
            this.pnlMostrarDatos.ResumeLayout(false);
            this.pnlMostrarDatos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administradorToolStripMenuItem;
        private System.Windows.Forms.Panel pnlRegistro;
        private System.Windows.Forms.ComboBox cboCarrera;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtApellidoMaterno;
        private System.Windows.Forms.TextBox txtApellidoPaterno;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlMostrarDatos;
        private System.Windows.Forms.ToolStripMenuItem listaRegistrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaUsuariosToolStripMenuItem;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSemestre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Label lblGenero;
        private ComboBox cboGenero;
    }
}