namespace Prototipo_1___SartorialSys
{
    partial class frmAdministrarUsuarios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabUsuarios = new System.Windows.Forms.TabControl();
            this.tabRegistrar = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxRolRegistrar = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsuarioRegistrar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelarRegistro = new System.Windows.Forms.Button();
            this.txtContraseñaRegistrar = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtCedulaEmpleadoRegistrar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabConsultar = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgtvCredenciales = new System.Windows.Forms.DataGridView();
            this.tabActualizar = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnActualizarRol = new System.Windows.Forms.Button();
            this.btnActualizarContraseña = new System.Windows.Forms.Button();
            this.btnBuscarActualizar = new System.Windows.Forms.Button();
            this.comboBoxRolActualizar = new System.Windows.Forms.ComboBox();
            this.checkBoxRol = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkContraseña = new System.Windows.Forms.CheckBox();
            this.txtContraseñaActualizar = new System.Windows.Forms.TextBox();
            this.txtUsuarioActualizar = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCedulaActualizar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabEliminar = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscarDarDeBaja = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtRolDarDeBaja = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCedulaEmpleadoDarDeBaja = new System.Windows.Forms.TextBox();
            this.txtContraseñaDarDeBaja = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtUsuarioDarDeBaja = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabUsuarios.SuspendLayout();
            this.tabRegistrar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabConsultar.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgtvCredenciales)).BeginInit();
            this.tabActualizar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabEliminar.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabUsuarios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 593);
            this.panel1.TabIndex = 0;
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Controls.Add(this.tabRegistrar);
            this.tabUsuarios.Controls.Add(this.tabConsultar);
            this.tabUsuarios.Controls.Add(this.tabActualizar);
            this.tabUsuarios.Controls.Add(this.tabEliminar);
            this.tabUsuarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabUsuarios.Location = new System.Drawing.Point(0, 11);
            this.tabUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.SelectedIndex = 0;
            this.tabUsuarios.Size = new System.Drawing.Size(739, 582);
            this.tabUsuarios.TabIndex = 20;
            // 
            // tabRegistrar
            // 
            this.tabRegistrar.Controls.Add(this.groupBox1);
            this.tabRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRegistrar.Location = new System.Drawing.Point(4, 25);
            this.tabRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabRegistrar.Name = "tabRegistrar";
            this.tabRegistrar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabRegistrar.Size = new System.Drawing.Size(731, 553);
            this.tabRegistrar.TabIndex = 0;
            this.tabRegistrar.Text = "Registrar Usuario";
            this.tabRegistrar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxRolRegistrar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtUsuarioRegistrar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCancelarRegistro);
            this.groupBox1.Controls.Add(this.txtContraseñaRegistrar);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.Controls.Add(this.txtCedulaEmpleadoRegistrar);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(734, 470);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxRolRegistrar
            // 
            this.comboBoxRolRegistrar.FormattingEnabled = true;
            this.comboBoxRolRegistrar.Items.AddRange(new object[] {
            "Gerente",
            "Administrativo",
            "Vendedor"});
            this.comboBoxRolRegistrar.Location = new System.Drawing.Point(420, 125);
            this.comboBoxRolRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxRolRegistrar.Name = "comboBoxRolRegistrar";
            this.comboBoxRolRegistrar.Size = new System.Drawing.Size(211, 28);
            this.comboBoxRolRegistrar.TabIndex = 14;
            this.comboBoxRolRegistrar.Text = "Seleccione";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(114, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Número de cédula del empleado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(114, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Usuario:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(114, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Rol:";
            // 
            // txtUsuarioRegistrar
            // 
            this.txtUsuarioRegistrar.Location = new System.Drawing.Point(420, 171);
            this.txtUsuarioRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuarioRegistrar.Name = "txtUsuarioRegistrar";
            this.txtUsuarioRegistrar.Size = new System.Drawing.Size(211, 26);
            this.txtUsuarioRegistrar.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(114, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Contraseña:";
            // 
            // btnCancelarRegistro
            // 
            this.btnCancelarRegistro.Location = new System.Drawing.Point(388, 299);
            this.btnCancelarRegistro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarRegistro.Name = "btnCancelarRegistro";
            this.btnCancelarRegistro.Size = new System.Drawing.Size(121, 36);
            this.btnCancelarRegistro.TabIndex = 12;
            this.btnCancelarRegistro.Text = "Cancelar";
            this.btnCancelarRegistro.UseVisualStyleBackColor = true;
            // 
            // txtContraseñaRegistrar
            // 
            this.txtContraseñaRegistrar.Location = new System.Drawing.Point(420, 215);
            this.txtContraseñaRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContraseñaRegistrar.Name = "txtContraseñaRegistrar";
            this.txtContraseñaRegistrar.Size = new System.Drawing.Size(211, 26);
            this.txtContraseñaRegistrar.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(218, 299);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(121, 36);
            this.btnRegistrar.TabIndex = 11;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // txtCedulaEmpleadoRegistrar
            // 
            this.txtCedulaEmpleadoRegistrar.Location = new System.Drawing.Point(420, 81);
            this.txtCedulaEmpleadoRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCedulaEmpleadoRegistrar.Name = "txtCedulaEmpleadoRegistrar";
            this.txtCedulaEmpleadoRegistrar.Size = new System.Drawing.Size(211, 26);
            this.txtCedulaEmpleadoRegistrar.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(248, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(217, 24);
            this.label11.TabIndex = 1;
            this.label11.Text = "Credenciales de Usuario";
            // 
            // tabConsultar
            // 
            this.tabConsultar.Controls.Add(this.panel3);
            this.tabConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConsultar.Location = new System.Drawing.Point(4, 25);
            this.tabConsultar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabConsultar.Name = "tabConsultar";
            this.tabConsultar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabConsultar.Size = new System.Drawing.Size(731, 553);
            this.tabConsultar.TabIndex = 2;
            this.tabConsultar.Text = "Mostrar Usuarios";
            this.tabConsultar.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dgtvCredenciales);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 474);
            this.panel3.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuarios";
            // 
            // dgtvCredenciales
            // 
            this.dgtvCredenciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgtvCredenciales.Location = new System.Drawing.Point(3, 59);
            this.dgtvCredenciales.Name = "dgtvCredenciales";
            this.dgtvCredenciales.RowHeadersWidth = 51;
            this.dgtvCredenciales.RowTemplate.Height = 24;
            this.dgtvCredenciales.Size = new System.Drawing.Size(700, 415);
            this.dgtvCredenciales.TabIndex = 1;
            // 
            // tabActualizar
            // 
            this.tabActualizar.Controls.Add(this.groupBox2);
            this.tabActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabActualizar.Location = new System.Drawing.Point(4, 25);
            this.tabActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabActualizar.Name = "tabActualizar";
            this.tabActualizar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabActualizar.Size = new System.Drawing.Size(731, 553);
            this.tabActualizar.TabIndex = 1;
            this.tabActualizar.Text = "Actualizar Usuario";
            this.tabActualizar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnActualizarRol);
            this.groupBox2.Controls.Add(this.btnActualizarContraseña);
            this.groupBox2.Controls.Add(this.btnBuscarActualizar);
            this.groupBox2.Controls.Add(this.comboBoxRolActualizar);
            this.groupBox2.Controls.Add(this.checkBoxRol);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.checkContraseña);
            this.groupBox2.Controls.Add(this.txtContraseñaActualizar);
            this.groupBox2.Controls.Add(this.txtUsuarioActualizar);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtCedulaActualizar);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(5, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(758, 426);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnActualizarRol
            // 
            this.btnActualizarRol.Location = new System.Drawing.Point(603, 203);
            this.btnActualizarRol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizarRol.Name = "btnActualizarRol";
            this.btnActualizarRol.Size = new System.Drawing.Size(115, 39);
            this.btnActualizarRol.TabIndex = 31;
            this.btnActualizarRol.Text = "Actualizar";
            this.btnActualizarRol.UseVisualStyleBackColor = true;
            this.btnActualizarRol.Click += new System.EventHandler(this.btnActualizarRol_Click_1);
            // 
            // btnActualizarContraseña
            // 
            this.btnActualizarContraseña.Location = new System.Drawing.Point(603, 157);
            this.btnActualizarContraseña.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizarContraseña.Name = "btnActualizarContraseña";
            this.btnActualizarContraseña.Size = new System.Drawing.Size(115, 39);
            this.btnActualizarContraseña.TabIndex = 30;
            this.btnActualizarContraseña.Text = "Actualizar";
            this.btnActualizarContraseña.UseVisualStyleBackColor = true;
            this.btnActualizarContraseña.Click += new System.EventHandler(this.btnActualizarContraseña_Click_1);
            // 
            // btnBuscarActualizar
            // 
            this.btnBuscarActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarActualizar.Location = new System.Drawing.Point(603, 84);
            this.btnBuscarActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarActualizar.Name = "btnBuscarActualizar";
            this.btnBuscarActualizar.Size = new System.Drawing.Size(115, 39);
            this.btnBuscarActualizar.TabIndex = 6;
            this.btnBuscarActualizar.Text = "Buscar";
            this.btnBuscarActualizar.UseVisualStyleBackColor = true;
            this.btnBuscarActualizar.Click += new System.EventHandler(this.btnBuscarActualizar_Click);
            // 
            // comboBoxRolActualizar
            // 
            this.comboBoxRolActualizar.Enabled = false;
            this.comboBoxRolActualizar.FormattingEnabled = true;
            this.comboBoxRolActualizar.Items.AddRange(new object[] {
            "Gerente",
            "Administrativo",
            "Vendedor"});
            this.comboBoxRolActualizar.Location = new System.Drawing.Point(387, 205);
            this.comboBoxRolActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxRolActualizar.Name = "comboBoxRolActualizar";
            this.comboBoxRolActualizar.Size = new System.Drawing.Size(193, 28);
            this.comboBoxRolActualizar.TabIndex = 29;
            this.comboBoxRolActualizar.Text = "Seleccione";
            // 
            // checkBoxRol
            // 
            this.checkBoxRol.AutoSize = true;
            this.checkBoxRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRol.Location = new System.Drawing.Point(61, 210);
            this.checkBoxRol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxRol.Name = "checkBoxRol";
            this.checkBoxRol.Size = new System.Drawing.Size(57, 22);
            this.checkBoxRol.TabIndex = 28;
            this.checkBoxRol.Text = "Rol:";
            this.checkBoxRol.UseVisualStyleBackColor = true;
            this.checkBoxRol.CheckedChanged += new System.EventHandler(this.checkBoxRol_CheckedChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "Usuario:";
            // 
            // checkContraseña
            // 
            this.checkContraseña.AutoSize = true;
            this.checkContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkContraseña.Location = new System.Drawing.Point(61, 170);
            this.checkContraseña.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkContraseña.Name = "checkContraseña";
            this.checkContraseña.Size = new System.Drawing.Size(111, 22);
            this.checkContraseña.TabIndex = 26;
            this.checkContraseña.Text = "Contraseña:";
            this.checkContraseña.UseVisualStyleBackColor = true;
            this.checkContraseña.CheckedChanged += new System.EventHandler(this.checkContraseña_CheckedChanged);
            // 
            // txtContraseñaActualizar
            // 
            this.txtContraseñaActualizar.Location = new System.Drawing.Point(388, 164);
            this.txtContraseñaActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContraseñaActualizar.Name = "txtContraseñaActualizar";
            this.txtContraseñaActualizar.ReadOnly = true;
            this.txtContraseñaActualizar.Size = new System.Drawing.Size(193, 26);
            this.txtContraseñaActualizar.TabIndex = 20;
            // 
            // txtUsuarioActualizar
            // 
            this.txtUsuarioActualizar.Location = new System.Drawing.Point(387, 123);
            this.txtUsuarioActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuarioActualizar.Name = "txtUsuarioActualizar";
            this.txtUsuarioActualizar.ReadOnly = true;
            this.txtUsuarioActualizar.Size = new System.Drawing.Size(193, 26);
            this.txtUsuarioActualizar.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(61, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(221, 18);
            this.label14.TabIndex = 12;
            this.label14.Text = "Número de cédula del empleado";
            // 
            // txtCedulaActualizar
            // 
            this.txtCedulaActualizar.Location = new System.Drawing.Point(387, 86);
            this.txtCedulaActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCedulaActualizar.Name = "txtCedulaActualizar";
            this.txtCedulaActualizar.Size = new System.Drawing.Size(193, 26);
            this.txtCedulaActualizar.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(246, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(217, 24);
            this.label13.TabIndex = 0;
            this.label13.Text = "Credenciales de Usuario";
            // 
            // tabEliminar
            // 
            this.tabEliminar.Controls.Add(this.groupBox6);
            this.tabEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEliminar.Location = new System.Drawing.Point(4, 25);
            this.tabEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabEliminar.Name = "tabEliminar";
            this.tabEliminar.Size = new System.Drawing.Size(731, 553);
            this.tabEliminar.TabIndex = 3;
            this.tabEliminar.Text = "Eliminar Usuarios";
            this.tabEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnCancelar);
            this.groupBox6.Controls.Add(this.btnBuscarDarDeBaja);
            this.groupBox6.Controls.Add(this.btnEliminar);
            this.groupBox6.Controls.Add(this.txtRolDarDeBaja);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.txtCedulaEmpleadoDarDeBaja);
            this.groupBox6.Controls.Add(this.txtContraseñaDarDeBaja);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.txtUsuarioDarDeBaja);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Location = new System.Drawing.Point(47, 23);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(699, 386);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dar de Baja/Alta Usuario";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(367, 257);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(175, 32);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnBuscarDarDeBaja
            // 
            this.btnBuscarDarDeBaja.Location = new System.Drawing.Point(546, 76);
            this.btnBuscarDarDeBaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarDarDeBaja.Name = "btnBuscarDarDeBaja";
            this.btnBuscarDarDeBaja.Size = new System.Drawing.Size(107, 31);
            this.btnBuscarDarDeBaja.TabIndex = 24;
            this.btnBuscarDarDeBaja.Text = "Buscar";
            this.btnBuscarDarDeBaja.UseVisualStyleBackColor = true;
            this.btnBuscarDarDeBaja.Click += new System.EventHandler(this.btnBuscarDarDeBaja_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(182, 257);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(175, 32);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // txtRolDarDeBaja
            // 
            this.txtRolDarDeBaja.Location = new System.Drawing.Point(388, 178);
            this.txtRolDarDeBaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRolDarDeBaja.Name = "txtRolDarDeBaja";
            this.txtRolDarDeBaja.ReadOnly = true;
            this.txtRolDarDeBaja.Size = new System.Drawing.Size(151, 26);
            this.txtRolDarDeBaja.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(64, 178);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 18);
            this.label21.TabIndex = 21;
            this.label21.Text = "Rol:";
            // 
            // txtCedulaEmpleadoDarDeBaja
            // 
            this.txtCedulaEmpleadoDarDeBaja.Location = new System.Drawing.Point(388, 78);
            this.txtCedulaEmpleadoDarDeBaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCedulaEmpleadoDarDeBaja.Name = "txtCedulaEmpleadoDarDeBaja";
            this.txtCedulaEmpleadoDarDeBaja.Size = new System.Drawing.Size(151, 26);
            this.txtCedulaEmpleadoDarDeBaja.TabIndex = 20;
            // 
            // txtContraseñaDarDeBaja
            // 
            this.txtContraseñaDarDeBaja.Location = new System.Drawing.Point(388, 142);
            this.txtContraseñaDarDeBaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContraseñaDarDeBaja.Name = "txtContraseñaDarDeBaja";
            this.txtContraseñaDarDeBaja.ReadOnly = true;
            this.txtContraseñaDarDeBaja.Size = new System.Drawing.Size(151, 26);
            this.txtContraseñaDarDeBaja.TabIndex = 19;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(67, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(221, 18);
            this.label23.TabIndex = 18;
            this.label23.Text = "Número de cédula del empleado";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(64, 146);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(89, 18);
            this.label24.TabIndex = 17;
            this.label24.Text = "Contraseña:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(64, 114);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 18);
            this.label25.TabIndex = 16;
            this.label25.Text = "Usuario:";
            // 
            // txtUsuarioDarDeBaja
            // 
            this.txtUsuarioDarDeBaja.Location = new System.Drawing.Point(388, 110);
            this.txtUsuarioDarDeBaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuarioDarDeBaja.Name = "txtUsuarioDarDeBaja";
            this.txtUsuarioDarDeBaja.ReadOnly = true;
            this.txtUsuarioDarDeBaja.Size = new System.Drawing.Size(151, 26);
            this.txtUsuarioDarDeBaja.TabIndex = 15;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(313, 32);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 24);
            this.label26.TabIndex = 1;
            this.label26.Text = "Datos";
            // 
            // frmAdministrarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 593);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAdministrarUsuarios";
            this.Text = "SartorialSys";
            this.panel1.ResumeLayout(false);
            this.tabUsuarios.ResumeLayout(false);
            this.tabRegistrar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabConsultar.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgtvCredenciales)).EndInit();
            this.tabActualizar.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabEliminar.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabUsuarios;
        private System.Windows.Forms.TabPage tabRegistrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxRolRegistrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsuarioRegistrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelarRegistro;
        private System.Windows.Forms.TextBox txtContraseñaRegistrar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox txtCedulaEmpleadoRegistrar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabConsultar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgtvCredenciales;
        private System.Windows.Forms.TabPage tabActualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnActualizarRol;
        private System.Windows.Forms.Button btnActualizarContraseña;
        private System.Windows.Forms.Button btnBuscarActualizar;
        private System.Windows.Forms.ComboBox comboBoxRolActualizar;
        private System.Windows.Forms.CheckBox checkBoxRol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkContraseña;
        private System.Windows.Forms.TextBox txtContraseñaActualizar;
        private System.Windows.Forms.TextBox txtUsuarioActualizar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCedulaActualizar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabEliminar;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscarDarDeBaja;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtRolDarDeBaja;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCedulaEmpleadoDarDeBaja;
        private System.Windows.Forms.TextBox txtContraseñaDarDeBaja;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtUsuarioDarDeBaja;
        private System.Windows.Forms.Label label26;
    }
}