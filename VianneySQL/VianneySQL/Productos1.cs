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
    public partial class Productos1 : Form
    {
        SqlConnection conexion2; //Para poder conectar con la BD de SQL

        public Productos1(SqlConnection conexion)
        {
            InitializeComponent();
            conexion2 = conexion;
            string query2 = "SELECT * FROM Almacen.TipoProducto";
            SqlCommand comando2 = new SqlCommand(query2, conexion);
            SqlDataAdapter adapatador = new SqlDataAdapter(comando2);
            DataTable tabla = new DataTable();
            adapatador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        //Para seguir dando de alta de productos
        private void Siguiente_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos(conexion2);
            producto.Show();
        }

        //Agregar producto 
        private void Agregar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Almacen.TipoProducto(Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
            SqlCommand comando = new SqlCommand(query, conexion2);
            comando.Parameters.AddWithValue("@Nombre", Nombre.Text);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion.Text);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string query2 = "SELECT * FROM Almacen.TipoProducto";
            SqlCommand comando2 = new SqlCommand(query2, conexion2);
            SqlDataAdapter adapatador = new SqlDataAdapter(comando2);
            DataTable tabla = new DataTable();
            adapatador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Nombre.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            Descripcion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
        }
    }
}
