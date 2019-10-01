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
    public partial class Vianney : Form
    {
        SqlConnection conexion; //Para poder conectar con la BD de SQL

        public Vianney()
        {
            InitializeComponent();
            ConectarBD();
        }

        //Para conectar Automaticamente la BD
        private void ConectarBD()
        {
            string connectionString = null, usuario;
            usuario = "LAPTOP-KDNRGED3\\SQLEXPRESS;";
            connectionString = "Server=" + usuario + "Database = Proyecto; Trusted_Connection=true;";
            conexion = new SqlConnection(connectionString);
            try
            {
                conexion.Open();
<<<<<<< HEAD
                //MessageBox.Show("Conexión OK");

=======
>>>>>>> d3a3ed4e28af6da8521453ce42ad4a7ca8274ef4
            }
            catch (Exception exepction)
            {
                MessageBox.Show("Conexión Fallida: " + exepction.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**Llamado de las ventas**/
        private void Productos_Click(object sender, EventArgs e)
        {
            Productos1 producto = new Productos1(conexion);
            producto.Show();
        }

        private void Venta_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas(conexion);
            venta.Show();
        }

        private void Devolucion_Click(object sender, EventArgs e)
        {
            Devoluciones devolucion = new Devoluciones(conexion);
            devolucion.Show();
        }

        private void vendedores_Click(object sender, EventArgs e)
        {
            Vendedores vendedor = new Vendedores(conexion);
            vendedor.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes(conexion);
            cliente.Show();
        }
    }
}
