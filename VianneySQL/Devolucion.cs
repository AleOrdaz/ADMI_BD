﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VianneySQL
{
    class Devolucion:UserControl
    {
        #region Controls
        private Label labelIdVenta;
        private TextBox textBoxIdVenta;
        private Label labelMotivo;
        private Label label1;
        private DateTimePicker dateTimePickerFechaVenta;
        private ToolStripButton toolStripButtonAgregar;
        private ToolStripButton toolStripButtonModificar;
        private ToolStripButton toolStripButtonEliminar;
        private ToolStrip toolStripVenta;
        private DataGridView dataGridViewInformacion;
        private Button buttonVerVentas;
        private GroupBox groupBoxVentas;
        private ToolStripButton toolStripButtonDetallesDevolucion;
        private DataGridView dataGridViewVentas;
        #endregion

        SqlConnection conexion; //Para poder conectar con la BD de SQL
        private uint bandera;
        private int indiceFilaInformacion, indiceFila, idDevolucion;
        private bool idClienteValido, idVendedorValido;
        private TextBox textBoxMotivo;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Devolucion));
            this.labelIdVenta = new System.Windows.Forms.Label();
            this.textBoxIdVenta = new System.Windows.Forms.TextBox();
            this.labelMotivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.toolStripButtonAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripVenta = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDetallesDevolucion = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewInformacion = new System.Windows.Forms.DataGridView();
            this.buttonVerVentas = new System.Windows.Forms.Button();
            this.groupBoxVentas = new System.Windows.Forms.GroupBox();
            this.dataGridViewVentas = new System.Windows.Forms.DataGridView();
            this.textBoxMotivo = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformacion)).BeginInit();
            this.groupBoxVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIdVenta
            // 
            this.labelIdVenta.AutoSize = true;
            this.labelIdVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.labelIdVenta.Location = new System.Drawing.Point(3, 102);
            this.labelIdVenta.Name = "labelIdVenta";
            this.labelIdVenta.Size = new System.Drawing.Size(52, 20);
            this.labelIdVenta.TabIndex = 1;
            this.labelIdVenta.Text = "Venta";
            // 
            // textBoxIdVenta
            // 
            this.textBoxIdVenta.Location = new System.Drawing.Point(61, 102);
            this.textBoxIdVenta.Name = "textBoxIdVenta";
            this.textBoxIdVenta.ReadOnly = true;
            this.textBoxIdVenta.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdVenta.TabIndex = 2;
            this.textBoxIdVenta.TextChanged += new System.EventHandler(this.textBoxIdVendedor_TextChanged);
            // 
            // labelMotivo
            // 
            this.labelMotivo.AutoSize = true;
            this.labelMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.labelMotivo.Location = new System.Drawing.Point(3, 143);
            this.labelMotivo.Name = "labelMotivo";
            this.labelMotivo.Size = new System.Drawing.Size(55, 20);
            this.labelMotivo.TabIndex = 3;
            this.labelMotivo.Text = "Motivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(176, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha";
            // 
            // dateTimePickerFechaVenta
            // 
            this.dateTimePickerFechaVenta.Location = new System.Drawing.Point(236, 102);
            this.dateTimePickerFechaVenta.Name = "dateTimePickerFechaVenta";
            this.dateTimePickerFechaVenta.Size = new System.Drawing.Size(198, 20);
            this.dateTimePickerFechaVenta.TabIndex = 6;
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
            // toolStripVenta
            // 
            this.toolStripVenta.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripVenta.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripVenta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAgregar,
            this.toolStripButtonModificar,
            this.toolStripButtonEliminar,
            this.toolStripButtonDetallesDevolucion});
            this.toolStripVenta.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripVenta.Location = new System.Drawing.Point(0, 0);
            this.toolStripVenta.Name = "toolStripVenta";
            this.toolStripVenta.Size = new System.Drawing.Size(750, 39);
            this.toolStripVenta.TabIndex = 0;
            this.toolStripVenta.Text = "toolStrip1";
            // 
            // toolStripButtonDetallesDevolucion
            // 
            this.toolStripButtonDetallesDevolucion.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDetallesDevolucion.Image")));
            this.toolStripButtonDetallesDevolucion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDetallesDevolucion.Name = "toolStripButtonDetallesDevolucion";
            this.toolStripButtonDetallesDevolucion.Size = new System.Drawing.Size(147, 36);
            this.toolStripButtonDetallesDevolucion.Text = "Detalles Devolución";
            this.toolStripButtonDetallesDevolucion.Click += new System.EventHandler(this.toolStripButtonDetallesVenta_Click);
            // 
            // dataGridViewInformacion
            // 
            this.dataGridViewInformacion.AllowUserToAddRows = false;
            this.dataGridViewInformacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInformacion.Location = new System.Drawing.Point(458, 73);
            this.dataGridViewInformacion.Name = "dataGridViewInformacion";
            this.dataGridViewInformacion.ReadOnly = true;
            this.dataGridViewInformacion.RowHeadersVisible = false;
            this.dataGridViewInformacion.RowHeadersWidth = 51;
            this.dataGridViewInformacion.RowTemplate.Height = 24;
            this.dataGridViewInformacion.Size = new System.Drawing.Size(285, 140);
            this.dataGridViewInformacion.TabIndex = 7;
            this.dataGridViewInformacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInformacion_CellClick);
            // 
            // buttonVerVentas
            // 
            this.buttonVerVentas.AutoSize = true;
            this.buttonVerVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.buttonVerVentas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.buttonVerVentas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVerVentas.ForeColor = System.Drawing.Color.White;
            this.buttonVerVentas.Location = new System.Drawing.Point(29, 60);
            this.buttonVerVentas.Name = "buttonVerVentas";
            this.buttonVerVentas.Size = new System.Drawing.Size(106, 27);
            this.buttonVerVentas.TabIndex = 8;
            this.buttonVerVentas.Text = "Ver Ventas";
            this.buttonVerVentas.UseVisualStyleBackColor = false;
            this.buttonVerVentas.Click += new System.EventHandler(this.buttonVerVendedores_Click);
            // 
            // groupBoxVentas
            // 
            this.groupBoxVentas.Controls.Add(this.dataGridViewVentas);
            this.groupBoxVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.groupBoxVentas.Location = new System.Drawing.Point(3, 232);
            this.groupBoxVentas.Name = "groupBoxVentas";
            this.groupBoxVentas.Size = new System.Drawing.Size(740, 268);
            this.groupBoxVentas.TabIndex = 10;
            this.groupBoxVentas.TabStop = false;
            this.groupBoxVentas.Text = "Ventas";
            // 
            // dataGridViewVentas
            // 
            this.dataGridViewVentas.AllowUserToAddRows = false;
            this.dataGridViewVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVentas.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewVentas.Name = "dataGridViewVentas";
            this.dataGridViewVentas.ReadOnly = true;
            this.dataGridViewVentas.RowHeadersVisible = false;
            this.dataGridViewVentas.RowHeadersWidth = 51;
            this.dataGridViewVentas.RowTemplate.Height = 24;
            this.dataGridViewVentas.Size = new System.Drawing.Size(734, 249);
            this.dataGridViewVentas.TabIndex = 0;
            this.dataGridViewVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVentas_CellClick);
            // 
            // textBoxMotivo
            // 
            this.textBoxMotivo.Location = new System.Drawing.Point(61, 143);
            this.textBoxMotivo.Multiline = true;
            this.textBoxMotivo.Name = "textBoxMotivo";
            this.textBoxMotivo.Size = new System.Drawing.Size(373, 70);
            this.textBoxMotivo.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Devolucion
            // 
            this.BackColor = System.Drawing.Color.Thistle;
            this.Controls.Add(this.textBoxMotivo);
            this.Controls.Add(this.groupBoxVentas);
            this.Controls.Add(this.buttonVerVentas);
            this.Controls.Add(this.dataGridViewInformacion);
            this.Controls.Add(this.dateTimePickerFechaVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMotivo);
            this.Controls.Add(this.textBoxIdVenta);
            this.Controls.Add(this.labelIdVenta);
            this.Controls.Add(this.toolStripVenta);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Devolucion";
            this.Size = new System.Drawing.Size(750, 510);
            this.toolStripVenta.ResumeLayout(false);
            this.toolStripVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformacion)).EndInit();
            this.groupBoxVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Devolucion(SqlConnection conexion) {
            InitializeComponent();
            this.conexion = conexion;
            bandera = 0;
            indiceFilaInformacion = indiceFila = idDevolucion = -1;
            idClienteValido = idVendedorValido = false;
            toolStripButtonAgregar.Enabled = toolStripButtonModificar.Enabled = toolStripButtonEliminar.Enabled = false;
            muestraConsulta();
            if (dataGridViewVentas.Columns.Count != 0) {
                toolStripButtonEliminar.Enabled = true;
            }
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            insertaRegistroTablaDevolucion();
            muestraConsulta();
        }

        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            modificaRegistroTablaDevolucion();
            muestraConsulta();
        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            if (indiceFila != -1)
            {
                eliminaRegistroTablaVenta();
                muestraConsulta();
            }
        }

        private void buttonVerVendedores_Click(object sender, EventArgs e)
        {
            bandera = 1;
            string query = "SELECT v.IdVenta FROM Transaccion.Venta v;";
            insertaDatosDataGridView(query);
        }

        private void muestraConsulta()
        {
            string query = "SELECT * FROM Almacen.Devolucion;";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewVentas.DataSource = tabla;
        }

        private void insertaDatosDataGridView(string query)
        {
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewInformacion.DataSource = tabla;
        }

        private void dataGridViewInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indiceFilaInformacion = e.RowIndex;
            if (indiceFilaInformacion != -1) {
                DataGridViewRow fila = dataGridViewInformacion.Rows[indiceFilaInformacion];
                switch (bandera) {
                    case 1:
                        textBoxIdVenta.Text = Convert.ToString(fila.Cells["IdVenta"].Value);
                        break;
                }
            }
        }

        private void dataGridViewVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indiceFila = e.RowIndex;
            if (indiceFila != -1) {
                DataGridViewRow fila = dataGridViewVentas.Rows[indiceFila];
                idDevolucion = int.Parse(Convert.ToString(fila.Cells["IdDevolucion"].Value));
                textBoxMotivo.Text = Convert.ToString(fila.Cells["Motivo"].Value);
                textBoxIdVenta.Text = Convert.ToString(fila.Cells["IdVenta"].Value);
                dateTimePickerFechaVenta.Value = DateTime.Parse(Convert.ToString(fila.Cells["Fecha"].Value));
            }
        }

        private void textBoxIdVendedor_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdVenta.Text != null) { 
                idVendedorValido = true;
                 toolStripButtonAgregar.Enabled = toolStripButtonModificar.Enabled = true;
            } 
            else {
                idVendedorValido = false;
            }
        }

        private void insertaRegistroTablaDevolucion()
        {
            string query = "INSERT INTO Almacen.Devolucion(IdVenta, Motivo, Fecha) VALUES (@idVenta, @Motivo, @fecha);";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@idVenta", textBoxIdVenta.Text);
            comando.Parameters.AddWithValue("@Motivo", textBoxMotivo.Text);
            comando.Parameters.AddWithValue("@fecha", dateTimePickerFechaVenta.Value.ToString("MM/dd/yyyy"));
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonDetallesVenta_Click(object sender, EventArgs e)
        {
            if (idDevolucion == -1) {
                MessageBox.Show("Selecciona una venta primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form padre = (this.Parent.Parent as Form);
            ((Devoluciones)padre).cambiaADetallesDevolucion(idDevolucion);
        }

        private void modificaRegistroTablaDevolucion() {
            if (indiceFila != -1)
            {
                DataGridViewRow fila = dataGridViewVentas.Rows[indiceFila];
                string query = "UPDATE Transaccion.Venta SET IdVenta = @idVenta, " +
                    "Motivo = @Motivo, Fecha = @fecha " +
                    "WHERE IdVenta = @idVenta;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idVenta", textBoxIdVenta.Text);
                comando.Parameters.AddWithValue("@Motivo", textBoxMotivo.Text);
                comando.Parameters.AddWithValue("@fecha", dateTimePickerFechaVenta.Value.ToString("MM/dd/yyyy"));
                comando.Parameters.AddWithValue("@idVenta", Convert.ToString(fila.Cells["IdVenta"].Value));
                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void eliminaRegistroTablaVenta() {
            if (indiceFila != -1)
            {
                DataGridViewRow fila = dataGridViewVentas.Rows[indiceFila];
                string query = "DELETE FROM Transaccion.Venta WHERE IdVenta = @idVenta;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idVenta", Convert.ToString(fila.Cells["IdVenta"].Value));
                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
