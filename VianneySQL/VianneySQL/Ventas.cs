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
    public partial class Ventas : Form
    {
        SqlConnection conexion2; //Para poder conectar con la BD de SQL

        public Ventas(SqlConnection conexion)
        {
            InitializeComponent();
            conexion2 = conexion;
            MessageBox.Show("Exito");
        }

        /**Llamado de las ventas**/
        private void Producto_Click(object sender, EventArgs e)
        {
            //Productos producto = new Productos(conexion2);
            //producto.Show();
        }

        private void Devolucion_Click(object sender, EventArgs e)
        {
            //Devoluciones devolucion = new Devoluciones(conexion2);
            //devolucion.Show();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }
    }
}
