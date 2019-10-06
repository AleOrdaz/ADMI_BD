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
    public partial class Devoluciones : Form
    {
        SqlConnection conexion2; //Para poder conectar con la BD de SQL

        public Devoluciones(SqlConnection conexion)
        {
            InitializeComponent();
            conexion2 = conexion;
            MessageBox.Show("Exito");
        }

        /**Llamado de las ventas**/
        private void Producto_Click(object sender, EventArgs e)
        {
           // Productos producto = new Productos(conexion2);
            //producto.Show();
        }

        private void Venta_Click(object sender, EventArgs e)
        {
            //Ventas venta = new Ventas(conexion2);
            //venta.Show();
        }
    }
}
