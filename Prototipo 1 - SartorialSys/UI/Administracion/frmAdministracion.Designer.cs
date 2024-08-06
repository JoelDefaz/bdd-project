namespace Prototipo_1___SartorialSys
{
    partial class frmAdministracion
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnParámetros = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "Administración del Sistema";
            // 
            // btnParámetros
            // 
            this.btnParámetros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParámetros.Image = global::Prototipo_1___SartorialSys.Properties.Resources.icono_parametros;
            this.btnParámetros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParámetros.Location = new System.Drawing.Point(88, 236);
            this.btnParámetros.Name = "btnParámetros";
            this.btnParámetros.Size = new System.Drawing.Size(221, 78);
            this.btnParámetros.TabIndex = 18;
            this.btnParámetros.Text = "Parámetros";
            this.btnParámetros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParámetros.UseVisualStyleBackColor = true;
            this.btnParámetros.Click += new System.EventHandler(this.btnParámetros_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Prototipo_1___SartorialSys.Properties.Resources.icono_nuevoCliente;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(84, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 78);
            this.button1.TabIndex = 17;
            this.button1.Text = "Usuarios";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Prototipo_1___SartorialSys.Properties.Resources.icono_administracion;
            this.pictureBox1.Location = new System.Drawing.Point(28, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 91);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnParámetros);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(46, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 349);
            this.panel1.TabIndex = 21;
            // 
            // frmAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 422);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdministracion";
            this.Text = "SartorialSys";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnParámetros;
        private System.Windows.Forms.Panel panel1;
    }
}