using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VianneySQL
{
    class Venta:UserControl
    {
        #region Controls
        private Label labelIdVendedor;
        private TextBox textBoxIdVendedor;
        private TextBox textBoxIdCliente;
        private Label labelIdCliente;
        private Label label1;
        private DateTimePicker dateTimePickerFechaVenta;
        private ToolStripButton toolStripButtonAgregar;
        private ToolStripButton toolStripButtonModificar;
        private ToolStripButton toolStripButtonEliminar;
        private ToolStrip toolStripVenta;
        private DataGridView dataGridViewInformacion;
        private Button buttonVerVendedores;
        private Button buttonVerClientes;
        private GroupBox groupBoxVentas;
        private ToolStripButton toolStripButtonDetallesVenta;
        private DataGridView dataGridViewVentas;
        #endregion

        SqlConnection conexion; //Para poder conectar con la BD de SQL
        private uint bandera;
        private int indiceFilaInformacion, indiceFila, idVenta;
        private bool idClienteValido, idVendedorValido;
        

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Venta));
            this.labelIdVendedor = new System.Windows.Forms.Label();
            this.textBoxIdVendedor = new System.Windows.Forms.TextBox();
            this.textBoxIdCliente = new System.Windows.Forms.TextBox();
            this.labelIdCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.toolStripButtonAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripVenta = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDetallesVenta = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewInformacion = new System.Windows.Forms.DataGridView();
            this.buttonVerVendedores = new System.Windows.Forms.Button();
            this.buttonVerClientes = new System.Windows.Forms.Button();
            this.groupBoxVentas = new System.Windows.Forms.GroupBox();
            this.dataGridViewVentas = new System.Windows.Forms.DataGridView();
            this.toolStripVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformacion)).BeginInit();
            this.groupBoxVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIdVendedor
            // 
            this.labelIdVendedor.AutoSize = true;
            this.labelIdVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdVendedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.labelIdVendedor.Location = new System.Drawing.Point(15, 101);
            this.labelIdVendedor.Name = "labelIdVendedor";
            this.labelIdVendedor.Size = new System.Drawing.Size(97, 20);
            this.labelIdVendedor.TabIndex = 1;
            this.labelIdVendedor.Text = "Id Vendedor";
            // 
            // textBoxIdVendedor
            // 
            this.textBoxIdVendedor.Location = new System.Drawing.Point(118, 103);
            this.textBoxIdVendedor.Name = "textBoxIdVendedor";
            this.textBoxIdVendedor.ReadOnly = true;
            this.textBoxIdVendedor.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdVendedor.TabIndex = 2;
            this.textBoxIdVendedor.TextChanged += new System.EventHandler(this.textBoxIdVendedor_TextChanged);
            // 
            // textBoxIdCliente
            // 
            this.textBoxIdCliente.Location = new System.Drawing.Point(328, 103);
            this.textBoxIdCliente.Name = "textBoxIdCliente";
            this.textBoxIdCliente.ReadOnly = true;
            this.textBoxIdCliente.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdCliente.TabIndex = 4;
            this.textBoxIdCliente.TextChanged += new System.EventHandler(this.textBoxIdCliente_TextChanged);
            // 
            // labelIdCliente
            // 
            this.labelIdCliente.AutoSize = true;
            this.labelIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.labelIdCliente.Location = new System.Drawing.Point(246, 100);
            this.labelIdCliente.Name = "labelIdCliente";
            this.labelIdCliente.Size = new System.Drawing.Size(76, 20);
            this.labelIdCliente.TabIndex = 3;
            this.labelIdCliente.Text = "Id Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(3, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha";
            // 
            // dateTimePickerFechaVenta
            // 
            this.dateTimePickerFechaVenta.Location = new System.Drawing.Point(76, 139);
            this.dateTimePickerFechaVenta.Name = "dateTimePickerFechaVenta";
            this.dateTimePickerFechaVenta.Size = new System.Drawing.Size(358, 20);
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
            this.toolStripButtonDetallesVenta});
            this.toolStripVenta.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripVenta.Location = new System.Drawing.Point(0, 0);
            this.toolStripVenta.Name = "toolStripVenta";
            this.toolStripVenta.Size = new System.Drawing.Size(750, 39);
            this.toolStripVenta.TabIndex = 0;
            this.toolStripVenta.Text = "toolStrip1";
            // 
            // toolStripButtonDetallesVenta
            // 
            this.toolStripButtonDetallesVenta.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDetallesVenta.Image")));
            this.toolStripButtonDetallesVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDetallesVenta.Name = "toolStripButtonDetallesVenta";
            this.toolStripButtonDetallesVenta.Size = new System.Drawing.Size(116, 36);
            this.toolStripButtonDetallesVenta.Text = "Detalles Venta";
            this.toolStripButtonDetallesVenta.Click += new System.EventHandler(this.toolStripButtonDetallesVenta_Click);
            // 
            // dataGridViewInformacion
            // 
            this.dataGridViewInformacion.AllowUserToAddRows = false;
            this.dataGridViewInformacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInformacion.Location = new System.Drawing.Point(440, 73);
            this.dataGridViewInformacion.Name = "dataGridViewInformacion";
            this.dataGridViewInformacion.ReadOnly = true;
            this.dataGridViewInformacion.RowHeadersVisible = false;
            this.dataGridViewInformacion.RowHeadersWidth = 51;
            this.dataGridViewInformacion.RowTemplate.Height = 24;
            this.dataGridViewInformacion.Size = new System.Drawing.Size(303, 150);
            this.dataGridViewInformacion.TabIndex = 7;
            this.dataGridViewInformacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInformacion_CellClick);
            // 
            // buttonVerVendedores
            // 
            this.buttonVerVendedores.AutoSize = true;
            this.buttonVerVendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.buttonVerVendedores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.buttonVerVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVerVendedores.ForeColor = System.Drawing.Color.White;
            this.buttonVerVendedores.Location = new System.Drawing.Point(52, 61);
            this.buttonVerVendedores.Name = "buttonVerVendedores";
            this.buttonVerVendedores.Size = new System.Drawing.Size(106, 27);
            this.buttonVerVendedores.TabIndex = 8;
            this.buttonVerVendedores.Text = "Ver Vendedores";
            this.buttonVerVendedores.UseVisualStyleBackColor = false;
            this.buttonVerVendedores.Click += new System.EventHandler(this.buttonVerVendedores_Click);
            // 
            // buttonVerClientes
            // 
            this.buttonVerClientes.AutoSize = true;
            this.buttonVerClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.buttonVerClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonVerClientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.buttonVerClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVerClientes.ForeColor = System.Drawing.Color.White;
            this.buttonVerClientes.Location = new System.Drawing.Point(232, 61);
            this.buttonVerClientes.Name = "buttonVerClientes";
            this.buttonVerClientes.Size = new System.Drawing.Size(106, 27);
            this.buttonVerClientes.TabIndex = 9;
            this.buttonVerClientes.Text = "Ver Clientes";
            this.buttonVerClientes.UseVisualStyleBackColor = false;
            this.buttonVerClientes.Click += new System.EventHandler(this.buttonVerClientes_Click);
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
            // Venta
            // 
            this.BackColor = System.Drawing.Color.Thistle;
            this.Controls.Add(this.groupBoxVentas);
            this.Controls.Add(this.buttonVerClientes);
            this.Controls.Add(this.buttonVerVendedores);
            this.Controls.Add(this.dataGridViewInformacion);
            this.Controls.Add(this.dateTimePickerFechaVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIdCliente);
            this.Controls.Add(this.labelIdCliente);
            this.Controls.Add(this.textBoxIdVendedor);
            this.Controls.Add(this.labelIdVendedor);
            this.Controls.Add(this.toolStripVenta);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Venta";
            this.Size = new System.Drawing.Size(750, 500);
            this.toolStripVenta.ResumeLayout(false);
            this.toolStripVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformacion)).EndInit();
            this.groupBoxVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Venta(SqlConnection conexion) {
            InitializeComponent();
            this.conexion = conexion;
            bandera = 0;
            indiceFilaInformacion = indiceFila = idVenta = -1;
            idClienteValido = idVendedorValido = false;
            toolStripButtonAgregar.Enabled = toolStripButtonModificar.Enabled = toolStripButtonEliminar.Enabled = false;
            muestraConsulta();
            if (dataGridViewVentas.Columns.Count != 0) {
                toolStripButtonEliminar.Enabled = true;
            }
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            insertaRegistroTablaVenta();
            muestraConsulta();
        }

        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            modificaRegistroTablaVenta();
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
            string query = "SELECT v.IdVendedor, v.Nombre FROM Almacen.Vendedor v;";
            insertaDatosDataGridView(query);
        }

        private void buttonVerClientes_Click(object sender, EventArgs e)
        {
            bandera = 2;
            string query = "SELECT c.IdCliente, c.Nombre FROM Transaccion.Cliente c;";
            insertaDatosDataGridView(query);
        }

        public void muestraConsulta()
        {
            string query = "SELECT * FROM Transaccion.Venta;";
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
            if (indiceFilaInformacion != -1 && indiceFilaInformacion != 0) {
                DataGridViewRow fila = dataGridViewInformacion.Rows[indiceFilaInformacion];
                switch (bandera) {
                    case 1:
                        textBoxIdVendedor.Text = Convert.ToString(fila.Cells["IdVendedor"].Value);
                        break;
                    case 2:
                        textBoxIdCliente.Text = Convert.ToString(fila.Cells["IdCliente"].Value);
                        break;
                }
            }
        }

        private void textBoxIdCliente_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdCliente.Text != null)
            {
                idClienteValido = true;
                if (idVendedorValido)
                {
                    toolStripButtonAgregar.Enabled = toolStripButtonModificar.Enabled = true;
                }
                else
                {
                    toolStripButtonAgregar.Enabled = toolStripButtonModificar.Enabled = false;
                }
            }
            else
            {
                idClienteValido = false;
            }
        }

        private void dataGridViewVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indiceFila = e.RowIndex;
            if (indiceFila != -1) {
                DataGridViewRow fila = dataGridViewVentas.Rows[indiceFila];
                idVenta = int.Parse(Convert.ToString(fila.Cells["IdVenta"].Value));
                textBoxIdCliente.Text = Convert.ToString(fila.Cells["IdCliente"].Value);
                textBoxIdVendedor.Text = Convert.ToString(fila.Cells["IdVendedor"].Value);
                dateTimePickerFechaVenta.Value = DateTime.Parse(Convert.ToString(fila.Cells["Fecha"].Value));
            }
        }

        private void textBoxIdVendedor_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdVendedor.Text != null) { 
                idVendedorValido = true;
                if (idClienteValido)
                {
                    toolStripButtonAgregar.Enabled = toolStripButtonModificar.Enabled = true;
                }
                else {
                    toolStripButtonAgregar.Enabled = toolStripButtonModificar.Enabled = false;
                }
            } 
            else {
                idVendedorValido = false;
            }
        }

        private void insertaRegistroTablaVenta()
        {
            string query = "INSERT INTO Transaccion.Venta(IdCliente, IdVendedor, Fecha) VALUES (@idCliente, @idVendedor, @fecha);";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@idCliente", textBoxIdVendedor.Text);
            comando.Parameters.AddWithValue("@idVendedor", textBoxIdCliente.Text);
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
            if (idVenta == -1) {
                MessageBox.Show("Selecciona una venta primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form padre = (this.Parent.Parent as Form);
            ((Ventas)padre).cambiaADetallesVenta(idVenta);
        }

        private void modificaRegistroTablaVenta() {
            if (indiceFila != -1)
            {
                DataGridViewRow fila = dataGridViewVentas.Rows[indiceFila];
                string query = "UPDATE Transaccion.Venta SET IdVendedor = @idVendedor, " +
                    "IdCliente = @idCliente, Fecha = @fecha WHERE IdVenta = @idVenta;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idVendedor", textBoxIdVendedor.Text);
                comando.Parameters.AddWithValue("@idCliente", textBoxIdCliente.Text);
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
                string idVenta = Convert.ToString(fila.Cells["IdVenta"].Value);
                eliminaTablaDetalleVenta(idVenta);
                string query = "DELETE FROM Transaccion.Venta WHERE IdVenta = @idVenta;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idVenta", idVenta);
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

        public void eliminaTablaDetalleVenta(string idVenta) {
            string query = "DELETE FROM Transaccion.DetalleVenta WHERE idVenta = @idVenta;";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@idVenta", idVenta);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
