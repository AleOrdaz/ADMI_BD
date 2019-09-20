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
        }

        //Para seguir dando de alta de productos
        private void Siguiente_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos(conexion2);
            producto.Show();
        }
    }
}
