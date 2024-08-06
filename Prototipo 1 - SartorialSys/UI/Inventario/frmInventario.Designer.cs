namespace Prototipo_1___SartorialSys
{
    partial class frmInventario
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
            this.tabInventario = new System.Windows.Forms.TabControl();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStockConsulta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtColorConsulta = new System.Windows.Forms.TextBox();
            this.txtTallaConsulta = new System.Windows.Forms.TextBox();
            this.txtCategoriaConsulta = new System.Windows.Forms.TextBox();
            this.txtDescripcionConsulta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcodigoBusqueda = new System.Windows.Forms.TextBox();
            this.tabActualizar = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpFechaActualizacion = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.txtEgresoProducto = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtIngresoProducto = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStockActualizar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtColorActualizar = new System.Windows.Forms.TextBox();
            this.txtTallaActualizar = new System.Windows.Forms.TextBox();
            this.txtCategoriaActualizar = new System.Windows.Forms.TextBox();
            this.txtDescripcionActualizar = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bntBuscarActualizar = new System.Windows.Forms.Button();
            this.txtParametroActualizar = new System.Windows.Forms.TextBox();
            this.tabInventario.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabActualizar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabInventario
            // 
            this.tabInventario.Controls.Add(this.tabConsulta);
            this.tabInventario.Controls.Add(this.tabActualizar);
            this.tabInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInventario.Location = new System.Drawing.Point(0, 0);
            this.tabInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabInventario.Name = "tabInventario";
            this.tabInventario.SelectedIndex = 0;
            this.tabInventario.Size = new System.Drawing.Size(978, 684);
            this.tabInventario.TabIndex = 18;
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.panel1);
            this.tabConsulta.Controls.Add(this.groupBox1);
            this.tabConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConsulta.Location = new System.Drawing.Point(4, 25);
            this.tabConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabConsulta.Size = new System.Drawing.Size(970, 655);
            this.tabConsulta.TabIndex = 0;
            this.tabConsulta.Text = "Consultar Stock";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 507);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtPrecioVenta);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtStockConsulta);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtColorConsulta);
            this.panel3.Controls.Add(this.txtTallaConsulta);
            this.panel3.Controls.Add(this.txtCategoriaConsulta);
            this.panel3.Controls.Add(this.txtDescripcionConsulta);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label29);
            this.panel3.Location = new System.Drawing.Point(25, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 405);
            this.panel3.TabIndex = 0;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.Location = new System.Drawing.Point(249, 331);
            this.txtPrecioVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.ReadOnly = true;
            this.txtPrecioVenta.Size = new System.Drawing.Size(309, 28);
            this.txtPrecioVenta.TabIndex = 60;
            this.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrecioVenta.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(34, 331);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 21);
            this.label12.TabIndex = 59;
            this.label12.Text = "Precio Venta:";
            this.label12.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(244, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 28);
            this.label2.TabIndex = 58;
            this.label2.Text = "Datos Producto";
            // 
            // txtStockConsulta
            // 
            this.txtStockConsulta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockConsulta.Location = new System.Drawing.Point(250, 287);
            this.txtStockConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStockConsulta.Name = "txtStockConsulta";
            this.txtStockConsulta.ReadOnly = true;
            this.txtStockConsulta.Size = new System.Drawing.Size(309, 28);
            this.txtStockConsulta.TabIndex = 57;
            this.txtStockConsulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 56;
            this.label1.Text = "Stock:";
            // 
            // txtColorConsulta
            // 
            this.txtColorConsulta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColorConsulta.Location = new System.Drawing.Point(250, 199);
            this.txtColorConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtColorConsulta.Name = "txtColorConsulta";
            this.txtColorConsulta.ReadOnly = true;
            this.txtColorConsulta.Size = new System.Drawing.Size(309, 28);
            this.txtColorConsulta.TabIndex = 55;
            this.txtColorConsulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTallaConsulta
            // 
            this.txtTallaConsulta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTallaConsulta.Location = new System.Drawing.Point(250, 243);
            this.txtTallaConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTallaConsulta.Name = "txtTallaConsulta";
            this.txtTallaConsulta.ReadOnly = true;
            this.txtTallaConsulta.Size = new System.Drawing.Size(309, 28);
            this.txtTallaConsulta.TabIndex = 54;
            this.txtTallaConsulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCategoriaConsulta
            // 
            this.txtCategoriaConsulta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoriaConsulta.Location = new System.Drawing.Point(251, 155);
            this.txtCategoriaConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategoriaConsulta.Name = "txtCategoriaConsulta";
            this.txtCategoriaConsulta.ReadOnly = true;
            this.txtCategoriaConsulta.Size = new System.Drawing.Size(307, 28);
            this.txtCategoriaConsulta.TabIndex = 53;
            this.txtCategoriaConsulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcionConsulta
            // 
            this.txtDescripcionConsulta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionConsulta.Location = new System.Drawing.Point(250, 111);
            this.txtDescripcionConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcionConsulta.Name = "txtDescripcionConsulta";
            this.txtDescripcionConsulta.ReadOnly = true;
            this.txtDescripcionConsulta.Size = new System.Drawing.Size(309, 28);
            this.txtDescripcionConsulta.TabIndex = 52;
            this.txtDescripcionConsulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 21);
            this.label8.TabIndex = 51;
            this.label8.Text = "Talla:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 21);
            this.label7.TabIndex = 50;
            this.label7.Text = "Color:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 21);
            this.label10.TabIndex = 49;
            this.label10.Text = "Descripción:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(34, 159);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(101, 21);
            this.label29.TabIndex = 48;
            this.label29.Text = "Categoría:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtcodigoBusqueda);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(964, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Código del Producto:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(649, 66);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 36);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Consultar Producto";
            // 
            // txtcodigoBusqueda
            // 
            this.txtcodigoBusqueda.Location = new System.Drawing.Point(372, 71);
            this.txtcodigoBusqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcodigoBusqueda.Name = "txtcodigoBusqueda";
            this.txtcodigoBusqueda.Size = new System.Drawing.Size(230, 26);
            this.txtcodigoBusqueda.TabIndex = 0;
            this.txtcodigoBusqueda.Leave += new System.EventHandler(this.txtcodigoBusqueda_Leave);
            // 
            // tabActualizar
            // 
            this.tabActualizar.Controls.Add(this.panel2);
            this.tabActualizar.Controls.Add(this.groupBox2);
            this.tabActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabActualizar.Location = new System.Drawing.Point(4, 25);
            this.tabActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabActualizar.Name = "tabActualizar";
            this.tabActualizar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabActualizar.Size = new System.Drawing.Size(970, 655);
            this.tabActualizar.TabIndex = 1;
            this.tabActualizar.Text = "Actualizar Stock";
            this.tabActualizar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 540);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtpFechaActualizacion);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Controls.Add(this.iconButton1);
            this.panel4.Controls.Add(this.txtEgresoProducto);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.txtIngresoProducto);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtStockActualizar);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtColorActualizar);
            this.panel4.Controls.Add(this.txtTallaActualizar);
            this.panel4.Controls.Add(this.txtCategoriaActualizar);
            this.panel4.Controls.Add(this.txtDescripcionActualizar);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Location = new System.Drawing.Point(64, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 450);
            this.panel4.TabIndex = 0;
            // 
            // dtpFechaActualizacion
            // 
            this.dtpFechaActualizacion.Location = new System.Drawing.Point(420, 346);
            this.dtpFechaActualizacion.Name = "dtpFechaActualizacion";
            this.dtpFechaActualizacion.Size = new System.Drawing.Size(200, 26);
            this.dtpFechaActualizacion.TabIndex = 70;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(46, 346);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(213, 21);
            this.label26.TabIndex = 69;
            this.label26.Text = "Fecha de Actualización:";
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(257, 394);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(137, 53);
            this.iconButton1.TabIndex = 68;
            this.iconButton1.Text = "Actualizar";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // txtEgresoProducto
            // 
            this.txtEgresoProducto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEgresoProducto.Location = new System.Drawing.Point(350, 305);
            this.txtEgresoProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEgresoProducto.Name = "txtEgresoProducto";
            this.txtEgresoProducto.Size = new System.Drawing.Size(320, 28);
            this.txtEgresoProducto.TabIndex = 67;
            this.txtEgresoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(44, 305);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(179, 21);
            this.label25.TabIndex = 66;
            this.label25.Text = "Egreso de Producto:";
            // 
            // txtIngresoProducto
            // 
            this.txtIngresoProducto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngresoProducto.Location = new System.Drawing.Point(350, 264);
            this.txtIngresoProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIngresoProducto.Name = "txtIngresoProducto";
            this.txtIngresoProducto.Size = new System.Drawing.Size(320, 28);
            this.txtIngresoProducto.TabIndex = 65;
            this.txtIngresoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(46, 264);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(180, 21);
            this.label24.TabIndex = 64;
            this.label24.Text = "Ingreso de Producto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(252, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 28);
            this.label9.TabIndex = 63;
            this.label9.Text = "Datos Producto";
            // 
            // txtStockActualizar
            // 
            this.txtStockActualizar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockActualizar.Location = new System.Drawing.Point(350, 223);
            this.txtStockActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStockActualizar.Name = "txtStockActualizar";
            this.txtStockActualizar.ReadOnly = true;
            this.txtStockActualizar.Size = new System.Drawing.Size(320, 28);
            this.txtStockActualizar.TabIndex = 62;
            this.txtStockActualizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(45, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 21);
            this.label11.TabIndex = 61;
            this.label11.Text = "Stock:";
            // 
            // txtColorActualizar
            // 
            this.txtColorActualizar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColorActualizar.Location = new System.Drawing.Point(350, 141);
            this.txtColorActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtColorActualizar.Name = "txtColorActualizar";
            this.txtColorActualizar.ReadOnly = true;
            this.txtColorActualizar.Size = new System.Drawing.Size(320, 28);
            this.txtColorActualizar.TabIndex = 60;
            this.txtColorActualizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTallaActualizar
            // 
            this.txtTallaActualizar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTallaActualizar.Location = new System.Drawing.Point(350, 182);
            this.txtTallaActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTallaActualizar.Name = "txtTallaActualizar";
            this.txtTallaActualizar.ReadOnly = true;
            this.txtTallaActualizar.Size = new System.Drawing.Size(320, 28);
            this.txtTallaActualizar.TabIndex = 59;
            this.txtTallaActualizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCategoriaActualizar
            // 
            this.txtCategoriaActualizar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoriaActualizar.Location = new System.Drawing.Point(351, 100);
            this.txtCategoriaActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategoriaActualizar.Name = "txtCategoriaActualizar";
            this.txtCategoriaActualizar.ReadOnly = true;
            this.txtCategoriaActualizar.Size = new System.Drawing.Size(318, 28);
            this.txtCategoriaActualizar.TabIndex = 58;
            this.txtCategoriaActualizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcionActualizar
            // 
            this.txtDescripcionActualizar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionActualizar.Location = new System.Drawing.Point(350, 59);
            this.txtDescripcionActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcionActualizar.Name = "txtDescripcionActualizar";
            this.txtDescripcionActualizar.ReadOnly = true;
            this.txtDescripcionActualizar.Size = new System.Drawing.Size(320, 28);
            this.txtDescripcionActualizar.TabIndex = 57;
            this.txtDescripcionActualizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(45, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 21);
            this.label14.TabIndex = 56;
            this.label14.Text = "Talla:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(45, 141);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 21);
            this.label16.TabIndex = 55;
            this.label16.Text = "Color:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(45, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 21);
            this.label17.TabIndex = 54;
            this.label17.Text = "Descripción:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(45, 100);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 21);
            this.label23.TabIndex = 53;
            this.label23.Text = "Categoría:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.bntBuscarActualizar);
            this.groupBox2.Controls.Add(this.txtParametroActualizar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(964, 106);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Consultar Producto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(181, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Código del Producto:";
            // 
            // bntBuscarActualizar
            // 
            this.bntBuscarActualizar.Location = new System.Drawing.Point(714, 63);
            this.bntBuscarActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bntBuscarActualizar.Name = "bntBuscarActualizar";
            this.bntBuscarActualizar.Size = new System.Drawing.Size(95, 36);
            this.bntBuscarActualizar.TabIndex = 11;
            this.bntBuscarActualizar.Text = "Buscar";
            this.bntBuscarActualizar.UseVisualStyleBackColor = true;
            this.bntBuscarActualizar.Click += new System.EventHandler(this.bntBuscarActualizar_Click);
            // 
            // txtParametroActualizar
            // 
            this.txtParametroActualizar.Location = new System.Drawing.Point(437, 68);
            this.txtParametroActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtParametroActualizar.Name = "txtParametroActualizar";
            this.txtParametroActualizar.Size = new System.Drawing.Size(230, 26);
            this.txtParametroActualizar.TabIndex = 0;
            this.txtParametroActualizar.Leave += new System.EventHandler(this.txtParametroActualizar_Leave);
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 684);
            this.Controls.Add(this.tabInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInventario";
            this.Text = "SartorialSys";
            this.tabInventario.ResumeLayout(false);
            this.tabConsulta.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabActualizar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabInventario;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStockConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColorConsulta;
        private System.Windows.Forms.TextBox txtTallaConsulta;
        private System.Windows.Forms.TextBox txtCategoriaConsulta;
        private System.Windows.Forms.TextBox txtDescripcionConsulta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcodigoBusqueda;
        private System.Windows.Forms.TabPage tabActualizar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpFechaActualizacion;
        private System.Windows.Forms.Label label26;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox txtEgresoProducto;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtIngresoProducto;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStockActualizar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtColorActualizar;
        private System.Windows.Forms.TextBox txtTallaActualizar;
        private System.Windows.Forms.TextBox txtCategoriaActualizar;
        private System.Windows.Forms.TextBox txtDescripcionActualizar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bntBuscarActualizar;
        private System.Windows.Forms.TextBox txtParametroActualizar;
    }
}