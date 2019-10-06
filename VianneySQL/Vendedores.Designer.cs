namespace VianneySQL
{
    partial class Vendedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vendedores));
            this.Domicilio = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.Telefono = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripVenta = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStripVenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // Domicilio
            // 
            this.Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Domicilio.Location = new System.Drawing.Point(260, 84);
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Size = new System.Drawing.Size(360, 21);
            this.Domicilio.TabIndex = 24;
            // 
            // Email
            // 
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(260, 116);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(360, 21);
            this.Email.TabIndex = 23;
            // 
            // Nombre
            // 
            this.Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.Location = new System.Drawing.Point(260, 54);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(360, 21);
            this.Nombre.TabIndex = 21;
            // 
            // Telefono
            // 
            this.Telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefono.Location = new System.Drawing.Point(260, 178);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(196, 21);
            this.Telefono.TabIndex = 30;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(708, 199);
            this.dataGridView1.TabIndex = 33;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // toolStripVenta
            // 
            this.toolStripVenta.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripVenta.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripVenta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAgregar,
            this.toolStripButtonModificar,
            this.toolStripButtonEliminar});
            this.toolStripVenta.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripVenta.Location = new System.Drawing.Point(0, 0);
            this.toolStripVenta.Name = "toolStripVenta";
            this.toolStripVenta.Size = new System.Drawing.Size(768, 39);
            this.toolStripVenta.TabIndex = 35;
            this.toolStripVenta.Text = "toolStrip1";
            // 
            // toolStripButtonAgregar
            // 
            this.toolStripButtonAgregar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAgregar.Image")));
            this.toolStripButtonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAgregar.Name = "toolStripButtonAgregar";
            this.toolStripButtonAgregar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButtonAgregar.Size = new System.Drawing.Size(85, 36);
            this.toolStripButtonAgregar.Text = "Agregar";
            this.toolStripButtonAgregar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButtonAgregar.Click += new System.EventHandler(this.toolStripButtonAgregar_Click);
            // 
            // toolStripButtonModificar
            // 
            this.toolStripButtonModificar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonModificar.Image")));
            this.toolStripButtonModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonModificar.Name = "toolStripButtonModificar";
            this.toolStripButtonModificar.Size = new System.Drawing.Size(94, 36);
            this.toolStripButtonModificar.Text = "Modificar";
            this.toolStripButtonModificar.Click += new System.EventHandler(this.toolStripButtonModificar_Click);
            // 
            // toolStripButtonEliminar
            // 
            this.toolStripButtonEliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEliminar.Image")));
            this.toolStripButtonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEliminar.Name = "toolStripButtonEliminar";
            this.toolStripButtonEliminar.Size = new System.Drawing.Size(86, 36);
            this.toolStripButtonEliminar.Text = "Eliminar";
            this.toolStripButtonEliminar.Click += new System.EventHandler(this.toolStripButtonEliminar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.label9.Location = new System.Drawing.Point(111, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 60;
            this.label9.Text = "Telefono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.label8.Location = new System.Drawing.Point(111, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 20);
            this.label8.TabIndex = 59;
            this.label8.Text = "Fecha Nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.label7.Location = new System.Drawing.Point(111, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 58;
            this.label7.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.label5.Location = new System.Drawing.Point(111, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "Domicilio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.label10.Location = new System.Drawing.Point(111, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 56;
            this.label10.Text = "Nombre";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Location = new System.Drawing.Point(260, 149);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(360, 20);
            this.dateTimePickerFecha.TabIndex = 61;
            // 
            // Vendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(768, 422);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.toolStripVenta);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.Domicilio);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Nombre);
            this.Name = "Vendedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendedores";
            this.Load += new System.EventHandler(this.Vendedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStripVenta.ResumeLayout(false);
            this.toolStripVenta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Domicilio;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.TextBox Telefono;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStripVenta;
        private System.Windows.Forms.ToolStripButton toolStripButtonAgregar;
        private System.Windows.Forms.ToolStripButton toolStripButtonModificar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEliminar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
    }
}