using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace VianneySQL
{
    public partial class Productos : Form
    {
        SqlConnection conexion2; //Para poder conectar con la BD de SQL
        string tipoProducto = "";
        string id = "";

        public Productos(SqlConnection conexion, string tProducto)
        {
            InitializeComponent();
            conexion2 = conexion;
            tipoProducto = tProducto;
            string query = "SELECT tp.IdTipoProducto, tp.Nombre FROM Almacen.TipoProducto tp;";
            insertaDatosDataGridView(query);
        }

        private void insertaDatosDataGridView(string query)
        {
            SqlCommand comando = new SqlCommand(query, conexion2);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewInformacion.DataSource = tabla;
        } 

        //Muestra los Datos en el dataGrid 
        private void Datos()
        {
            string query2 = "SELECT p.IdProducto, p.IdTipoProducto, p.Stock, p.Tamaño, p.Precio " +
                            "FROM Almacen.Producto p JOIN Almacen.TipoProducto tp " +
                            "ON p.IdTipoProducto = tp.IdTipoProducto" +
                            " WHERE p.IdTipoProducto = " + id;
            SqlCommand comando2 = new SqlCommand(query2, conexion2);
            SqlDataAdapter adapatador = new SqlDataAdapter(comando2);
            DataTable tabla = new DataTable();
            adapatador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void Productos_Load(object sender, EventArgs e)
        { }

        /**Llamado de las ventas**/
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas(conexion2);
            venta.Show();
        }

        //Llamado a las devoluciones
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Devoluciones devolucion = new Devoluciones(conexion2);
            devolucion.Show();
        }

        //Boton agregar detalles
        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Almacen.Producto(IdTipoProducto, Stock, Tamaño, Precio) VALUES (@IdTipoProducto, @Stock, @Tamaño, @Precio)";
            SqlCommand comando = new SqlCommand(query, conexion2);
            comando.Parameters.AddWithValue("@IdTipoProducto", id);
            comando.Parameters.AddWithValue("@Stock", Stock.Text);
            comando.Parameters.AddWithValue("@Tamaño", Tamaño.Text);
            comando.Parameters.AddWithValue("@Precio", Precio.Text);
            try
            {
                comando.ExecuteNonQuery();
                Datos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Boton para modificar algun detalle en el producto
        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            string query = "UPDATE  Almacen.Vendedor SET Nombre = '" + Stock.Text +
                                                              "', Domicilio = '" + Tamaño.Text +
                                                              "', Email = '" + Precio.Text +
                        "WHERE IdProducto = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            SqlCommand comando = new SqlCommand(query, conexion2);

            try
            {
                comando.ExecuteNonQuery();
                Datos();
                Stock.Text = "";
                Tamaño.Text = "";
                Precio.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Boton para eliminar los detalles d eun producto
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Almacen.Producto " +
                            "WHERE IdProducto =" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            SqlCommand comando = new SqlCommand(query, conexion2);

            try
            {
                comando.ExecuteNonQuery();
                Datos();
                Stock.Text = "";
                Tamaño.Text = "";
                Precio.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Stock.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            Tamaño.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            Precio.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridViewInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridViewInformacion.Rows[dataGridViewInformacion.CurrentCell.RowIndex].Cells[0].Value.ToString();
        }
    }
}