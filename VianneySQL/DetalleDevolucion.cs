using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VianneySQL
{
    class DetallesDevolucion : UserControl
    {
        #region Controles
        private ToolStrip toolStripVenta;
        private ToolStripButton toolStripButtonAgregar;
        private ToolStripButton toolStripButtonModificar;
        private ToolStripButton toolStripButtonEliminar;
        private ToolStripButton toolStripButtonVentas;
        private GroupBox groupBoxProductos;
        private DataGridView dataGridViewProductos;
        private Label labelIdProducto;
        private TextBox textBoxIdProducto;
        private Label labelCantidad;
        private NumericUpDown numericUpDownCantidad;
        private GroupBox groupBoxDetallesVenta;
        private DataGridView dataGridViewDetallesVenta;
        #endregion
        private SqlConnection conexion;
        private int indiceFila, indiceFilaProducto, idDevolucion, idVenta;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetallesDevolucion));
            this.toolStripVenta = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVentas = new System.Windows.Forms.ToolStripButton();
            this.groupBoxProductos = new System.Windows.Forms.GroupBox();
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.labelIdProducto = new System.Windows.Forms.Label();
            this.textBoxIdProducto = new System.Windows.Forms.TextBox();
            this.labelCantidad = new System.Windows.Forms.Label();
            this.numericUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.groupBoxDetallesVenta = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetallesVenta = new System.Windows.Forms.DataGridView();
            this.toolStripVenta.SuspendLayout();
            this.groupBoxProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).BeginInit();
            this.groupBoxDetallesVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetallesVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripVenta
            // 
            this.toolStripVenta.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripVenta.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripVenta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAgregar,
            this.toolStripButtonModificar,
            this.toolStripButtonEliminar,
            this.toolStripButtonVentas});
            this.toolStripVenta.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripVenta.Location = new System.Drawing.Point(0, 0);
            this.toolStripVenta.Name = "toolStripVenta";
            this.toolStripVenta.Size = new System.Drawing.Size(750, 39);
            this.toolStripVenta.TabIndex = 1;
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
            // toolStripButtonVentas
            // 
            this.toolStripButtonVentas.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonVentas.Image")));
            this.toolStripButtonVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVentas.Name = "toolStripButtonVentas";
            this.toolStripButtonVentas.Size = new System.Drawing.Size(114, 36);
            this.toolStripButtonVentas.Text = "Devoluciones";
            this.toolStripButtonVentas.ToolTipText = "Ventas";
            this.toolStripButtonVentas.Click += new System.EventHandler(this.toolStripButtonVentas_Click);
            // 
            // groupBoxProductos
            // 
            this.groupBoxProductos.Controls.Add(this.dataGridViewProductos);
            this.groupBoxProductos.ForeColor = System.Drawing.Color.Purple;
            this.groupBoxProductos.Location = new System.Drawing.Point(4, 43);
            this.groupBoxProductos.Name = "groupBoxProductos";
            this.groupBoxProductos.Size = new System.Drawing.Size(743, 208);
            this.groupBoxProductos.TabIndex = 2;
            this.groupBoxProductos.TabStop = false;
            this.groupBoxProductos.Text = "Productos";
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductos.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.ReadOnly = true;
            this.dataGridViewProductos.RowHeadersVisible = false;
            this.dataGridViewProductos.RowHeadersWidth = 51;
            this.dataGridViewProductos.RowTemplate.Height = 24;
            this.dataGridViewProductos.Size = new System.Drawing.Size(731, 183);
            this.dataGridViewProductos.TabIndex = 1;
            this.dataGridViewProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductos_CellClick);
            // 
            // labelIdProducto
            // 
            this.labelIdProducto.AutoSize = true;
            this.labelIdProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.labelIdProducto.Location = new System.Drawing.Point(6, 254);
            this.labelIdProducto.Name = "labelIdProducto";
            this.labelIdProducto.Size = new System.Drawing.Size(91, 20);
            this.labelIdProducto.TabIndex = 3;
            this.labelIdProducto.Text = "Id Producto";
            // 
            // textBoxIdProducto
            // 
            this.textBoxIdProducto.Location = new System.Drawing.Point(103, 254);
            this.textBoxIdProducto.Name = "textBoxIdProducto";
            this.textBoxIdProducto.ReadOnly = true;
            this.textBoxIdProducto.Size = new System.Drawing.Size(119, 20);
            this.textBoxIdProducto.TabIndex = 4;
            // 
            // labelCantidad
            // 
            this.labelCantidad.AutoSize = true;
            this.labelCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(33)))), ((int)(((byte)(109)))));
            this.labelCantidad.Location = new System.Drawing.Point(247, 254);
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Size = new System.Drawing.Size(73, 20);
            this.labelCantidad.TabIndex = 5;
            this.labelCantidad.Text = "Cantidad";
            // 
            // numericUpDownCantidad
            // 
            this.numericUpDownCantidad.Location = new System.Drawing.Point(326, 255);
            this.numericUpDownCantidad.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCantidad.Name = "numericUpDownCantidad";
            this.numericUpDownCantidad.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCantidad.TabIndex = 6;
            this.numericUpDownCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBoxDetallesVenta
            // 
            this.groupBoxDetallesVenta.Controls.Add(this.dataGridViewDetallesVenta);
            this.groupBoxDetallesVenta.ForeColor = System.Drawing.Color.Purple;
            this.groupBoxDetallesVenta.Location = new System.Drawing.Point(4, 282);
            this.groupBoxDetallesVenta.Name = "groupBoxDetallesVenta";
            this.groupBoxDetallesVenta.Size = new System.Drawing.Size(743, 208);
            this.groupBoxDetallesVenta.TabIndex = 7;
            this.groupBoxDetallesVenta.TabStop = false;
            this.groupBoxDetallesVenta.Text = "Detalles Devolución";
            // 
            // dataGridViewDetallesVenta
            // 
            this.dataGridViewDetallesVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetallesVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetallesVenta.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewDetallesVenta.Name = "dataGridViewDetallesVenta";
            this.dataGridViewDetallesVenta.ReadOnly = true;
            this.dataGridViewDetallesVenta.RowHeadersVisible = false;
            this.dataGridViewDetallesVenta.RowHeadersWidth = 51;
            this.dataGridViewDetallesVenta.RowTemplate.Height = 24;
            this.dataGridViewDetallesVenta.Size = new System.Drawing.Size(731, 183);
            this.dataGridViewDetallesVenta.TabIndex = 1;
            this.dataGridViewDetallesVenta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetallesVenta_CellClick);
            // 
            // DetallesDevolucion
            // 
            this.BackColor = System.Drawing.Color.Thistle;
            this.Controls.Add(this.groupBoxDetallesVenta);
            this.Controls.Add(this.numericUpDownCantidad);
            this.Controls.Add(this.labelCantidad);
            this.Controls.Add(this.textBoxIdProducto);
            this.Controls.Add(this.labelIdProducto);
            this.Controls.Add(this.groupBoxProductos);
            this.Controls.Add(this.toolStripVenta);
            this.Name = "DetallesDevolucion";
            this.Size = new System.Drawing.Size(750, 500);
            this.toolStripVenta.ResumeLayout(false);
            this.toolStripVenta.PerformLayout();
            this.groupBoxProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).EndInit();
            this.groupBoxDetallesVenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetallesVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public int IdDevolucion {
            get { return idDevolucion; }
            set { idDevolucion = value; }
        } 

        public int IdVenta {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public DetallesDevolucion(SqlConnection conexion) {
            InitializeComponent();
            this.conexion = conexion;
            indiceFila = indiceFilaProducto = -1;
            muestraConsultaProductos();
        }

        private void toolStripButtonVentas_Click(object sender, EventArgs e)
        {
            Form padre = (this.Parent.Parent as Form);
            ((Devoluciones)padre).cambiaADevolucion();
        }

        public void muestraConsultaProductos() {
            /*string query = "SELECT P.idProducto, TP.Nombre, P.Precio, P.Tamaño, TP.Descripcion, P.Cantidad " +
                "FROM Almacen.TipoProducto TP INNER JOIN  "*/
            string query = "SELECT Consulta.idProducto, Consulta.Nombre, Consulta.Precio, Consulta.Tamaño, Consulta.Descripcion, dv.Cantidad " +
                " FROM Transaccion.DetalleVenta dv" +
                " INNER JOIN" +
                " (SELECT p.idProducto, tp.Nombre, p.Precio, p.Tamaño, tp.Descripcion" +
                " FROM Almacen.TipoProducto tp" +
                " INNER JOIN Almacen.Producto p" +
                " ON p.idTipoProducto = tp.idTipoProducto) AS Consulta" +
                " ON Consulta.idProducto = dv.idProducto" +
                " WHERE dv.idVenta = @idVenta;";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@idVenta", idDevolucion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewProductos.DataSource = tabla;
        }

        public void muestraConsultaDetallesDevolucion() {
            string query = "SELECT * FROM Almacen.DetalleDevolucion WHERE IdDevolucion = @idDevolucion;";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@idDevolucion", idDevolucion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewDetallesVenta.DataSource = tabla;
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Almacen.DetalleDevolucion(IdDevolucion, IdProducto, Cantidad) VALUES (@idDevolucion, @idProducto, @cantidad);";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@idDevolucion", idDevolucion);
            comando.Parameters.AddWithValue("@idProducto", textBoxIdProducto.Text);
            comando.Parameters.AddWithValue("@cantidad", numericUpDownCantidad.Value);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            muestraConsultaDetallesDevolucion();
        }

        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            if (indiceFila != -1)
            {
                DataGridViewRow fila = dataGridViewDetallesVenta.Rows[indiceFila];
                string query = "UPDATE Almacen.DetalleDevolucion SET IdProducto = @idProducto, " +
                    "Cantidad = @cantidad WHERE idDevolucion = @idVenta AND IdProducto = @idP;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idProducto", textBoxIdProducto.Text);
                comando.Parameters.AddWithValue("@cantidad", numericUpDownCantidad.Value);
                comando.Parameters.AddWithValue("@idVenta", Convert.ToString(fila.Cells["idDevolucion"].Value));
                comando.Parameters.AddWithValue("@idP", Convert.ToString(fila.Cells["idProducto"].Value));
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
            muestraConsultaDetallesDevolucion();
            
        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            if (indiceFila != -1)
            {
                DataGridViewRow fila = dataGridViewDetallesVenta.Rows[indiceFila];
                string query = "DELETE FROM Almacen.DetalleDevolucion WHERE idDevolucion = @idVenta AND IdProducto = @idP;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idVenta", Convert.ToString(fila.Cells["idDevolucion"].Value));
                comando.Parameters.AddWithValue("@idP", Convert.ToString(fila.Cells["idProducto"].Value));
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
            muestraConsultaDetallesDevolucion();
        }

        private void dataGridViewDetallesVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indiceFila = e.RowIndex;
            if (indiceFila != -1)
            {
                DataGridViewRow fila = dataGridViewDetallesVenta.Rows[indiceFila];
                textBoxIdProducto.Text = Convert.ToString(fila.Cells["IdProducto"].Value);
                numericUpDownCantidad.Value = int.Parse(Convert.ToString(fila.Cells["Cantidad"].Value));
            }
        }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indiceFilaProducto = e.RowIndex;
            if (indiceFilaProducto != -1)
            {
                DataGridViewRow fila = dataGridViewProductos.Rows[indiceFilaProducto];
                textBoxIdProducto.Text = Convert.ToString(fila.Cells["IdProducto"].Value);
                numericUpDownCantidad.Maximum = int.Parse(Convert.ToString(fila.Cells["Cantidad"].Value));
            }
        }
    }
}
