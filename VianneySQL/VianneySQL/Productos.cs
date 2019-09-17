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

        public Productos(SqlConnection conexion)
        {
            InitializeComponent();
            conexion2 = conexion;
            MessageBox.Show("Exito");
        }

        private void Productos_Load(object sender, EventArgs e)
        {
        }

        /**Llamado de las ventas**/
        private void Venta_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas(conexion2);
            venta.Show();
        }

        private void Devolucion_Click(object sender, EventArgs e)
        {
            Devoluciones devolucion = new Devoluciones(conexion2);
            devolucion.Show();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Almacen.Producto(Stock, Tamaño, Precio) VALUES (@Stock, @Tamaño, @Precio)";
            SqlCommand comando = new SqlCommand(query, conexion2);
            comando.Parameters.AddWithValue("@Stock", Stock.Text);
            comando.Parameters.AddWithValue("@Tamaño", Tamaño.Text);
            comando.Parameters.AddWithValue("@Precio", Precio.Text);

            string query2 = "INSERT INTO Almacen.TipoProducto(Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
            SqlCommand comando2 = new SqlCommand(query2, conexion2);
            comando2.Parameters.AddWithValue("@Nombre", Nombre.Text);
            comando2.Parameters.AddWithValue("@Descripcion", Descripcion.Text);

            try
            {
                comando.ExecuteNonQuery();
                // MessageBox.Show("Ingresado con Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string query1 = "SELECT * FROM Almacen.Producto";
            SqlCommand comando3 = new SqlCommand(query1, conexion2);
            SqlDataAdapter adapatador = new SqlDataAdapter(comando2);
            DataTable tabla = new DataTable();
            adapatador.Fill(tabla);
            dataGridView1.DataSource = tabla;

            string query4 = "SELECT * FROM Almacen.TipoProducto";
            SqlCommand comando4 = new SqlCommand(query4, conexion2);
            SqlDataAdapter adapatador1 = new SqlDataAdapter(comando2);
            DataTable tabla2 = new DataTable();
            adapatador.Fill(tabla2);
            dataGridView1.DataSource = tabla2;
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Nombre.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            Stock.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            Tamaño.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            Precio.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            Descripcion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
        }
    }
}
