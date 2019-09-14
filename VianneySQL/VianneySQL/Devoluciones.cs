using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VianneySQL
{
    public partial class Devoluciones : Form
    {
        public Devoluciones()
        {
            InitializeComponent();
        }

        /**Llamado de las ventas**/
        private void Producto_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Show();
        }

        private void Venta_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            venta.Show();
        }
    }
}
