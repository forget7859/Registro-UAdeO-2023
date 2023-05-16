namespace Registro_UAdeO_2023
{
    partial class AdminReportes
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
            this.fec_inicio = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fec_final = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rBtnHombre = new System.Windows.Forms.RadioButton();
            this.rBtnMujer = new System.Windows.Forms.RadioButton();
            this.rBtnOtros = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // fec_inicio
            // 
            this.fec_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fec_inicio.Location = new System.Drawing.Point(6, 19);
            this.fec_inicio.Name = "fec_inicio";
            this.fec_inicio.Size = new System.Drawing.Size(200, 20);
            this.fec_inicio.TabIndex = 0;
            this.fec_inicio.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fec_final);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fec_inicio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 195);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // fec_final
            // 
            this.fec_final.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fec_final.Location = new System.Drawing.Point(212, 20);
            this.fec_final.Name = "fec_final";
            this.fec_final.Size = new System.Drawing.Size(200, 20);
            this.fec_final.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fec. Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(281, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fec. Fin";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rBtnOtros);
            this.groupBox2.Controls.Add(this.rBtnMujer);
            this.groupBox2.Controls.Add(this.rBtnHombre);
            this.groupBox2.Location = new System.Drawing.Point(6, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 52);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // rBtnHombre
            // 
            this.rBtnHombre.AutoSize = true;
            this.rBtnHombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnHombre.Location = new System.Drawing.Point(6, 19);
            this.rBtnHombre.Name = "rBtnHombre";
            this.rBtnHombre.Size = new System.Drawing.Size(74, 20);
            this.rBtnHombre.TabIndex = 0;
            this.rBtnHombre.TabStop = true;
            this.rBtnHombre.Text = "Hombre";
            this.rBtnHombre.UseVisualStyleBackColor = true;
            // 
            // rBtnMujer
            // 
            this.rBtnMujer.AutoSize = true;
            this.rBtnMujer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnMujer.Location = new System.Drawing.Point(115, 19);
            this.rBtnMujer.Name = "rBtnMujer";
            this.rBtnMujer.Size = new System.Drawing.Size(58, 20);
            this.rBtnMujer.TabIndex = 1;
            this.rBtnMujer.TabStop = true;
            this.rBtnMujer.Text = "Mujer";
            this.rBtnMujer.UseVisualStyleBackColor = true;
            // 
            // rBtnOtros
            // 
            this.rBtnOtros.AutoSize = true;
            this.rBtnOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnOtros.Location = new System.Drawing.Point(244, 19);
            this.rBtnOtros.Name = "rBtnOtros";
            this.rBtnOtros.Size = new System.Drawing.Size(57, 20);
            this.rBtnOtros.TabIndex = 2;
            this.rBtnOtros.TabStop = true;
            this.rBtnOtros.Text = "Otros";
            this.rBtnOtros.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSalir);
            this.groupBox3.Controls.Add(this.btnImprimir);
            this.groupBox3.Location = new System.Drawing.Point(6, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 52);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(6, 19);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(98, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // AdminReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 219);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminReportes";
            this.Text = "AdminReportecs";
            this.Load += new System.EventHandler(this.AdminReportes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fec_inicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker fec_final;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rBtnOtros;
        private System.Windows.Forms.RadioButton rBtnMujer;
        private System.Windows.Forms.RadioButton rBtnHombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}