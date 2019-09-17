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
    public partial class Clientes : Form
    {
        SqlConnection conexion2; //Para poder conectar con la BD de SQL

        public Clientes(SqlConnection conexion)
        {
            InitializeComponent();
            conexion2 = conexion;
            MessageBox.Show("Exito");
        }
    }
}
