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
        string tipoproducto = "";
        bool seleccion = false;

        public Productos1(SqlConnection conexion)
        {
            InitializeComponent();
            conexion2 = conexion;
            Datos();
            toolStripButtonEliminar.Enabled = toolStripButtonModificar.Enabled = false;
        }

        //Muestra los Datos en el dataGrid 
        private void Datos()
        {
            string query2 = "SELECT * FROM Almacen.TipoProducto";
            tipoproducto = query2;
            SqlCommand comando2 = new SqlCommand(query2, conexion2);
            SqlDataAdapter adapatador = new SqlDataAdapter(comando2);
            DataTable tabla = new DataTable();
            adapatador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        //Para seguir dando de alta de productos
        private void Siguiente_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos(conexion2, tipoproducto);
            producto.Show();
        }

        //Agregar producto 
        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            if (Nombre.Text != "" && Descripcion.Text != "")
            { 
                string query = "INSERT INTO Almacen.TipoProducto(Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                SqlCommand comando = new SqlCommand(query, conexion2);
                comando.Parameters.AddWithValue("@Nombre", Nombre.Text);
                comando.Parameters.AddWithValue("@Descripcion", Descripcion.Text);

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
            else
            {  MessageBox.Show("Favor de completar todos los campos", "Error", MessageBoxButtons.OK);  }
        }

        //Boton modifica el producto
        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            string query = "UPDATE  Almacen.TipoProducto SET Nombre = '" + Nombre.Text +
                                                    "', Descripcion = '" + Descripcion.Text + "'" +
                           "WHERE IdTipoProducto = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            SqlCommand comando = new SqlCommand(query, conexion2);

            try
            {
                comando.ExecuteNonQuery();
                Datos();
                Nombre.Text = "";
                Descripcion.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Boton para eliminar un producto
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Almacen.TipoProducto " +
                            "WHERE IdTipoProducto =" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            SqlCommand comando = new SqlCommand(query, conexion2);

            try
            {
                comando.ExecuteNonQuery();
                Datos();
                Nombre.Text = "";
                Descripcion.Text = "";
            }
            catch (Exception ex)
            {
                string query2 = "SELECT COUNT(*) FROM Almacen.Producto " +
                    "WHERE IdTipoProducto = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                SqlCommand comando2 = new SqlCommand(query2, conexion2);
                SqlDataAdapter adapatador = new SqlDataAdapter(comando2);
                DataTable tabla = new DataTable();
                adapatador.Fill(tabla);
                dataGridView2.DataSource = tabla;
                string cantidad = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                
                if (cantidad != "0")
                {
                    MessageBox.Show("Por Favor, primero elimine los Elementos agregados de este.", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccion = true;
            Nombre.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            Descripcion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            toolStripButtonModificar.Enabled = toolStripButtonEliminar.Enabled = true;
        }

        private void Productos1_Load(object sender, EventArgs e)
        { }
    }
}
