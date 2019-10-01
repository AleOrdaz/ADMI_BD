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
        SqlConnection conexion; //Para poder conectar con la BD de SQL
        DetallesVenta detallesVenta;
        Venta venta;
        public Ventas(SqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            detallesVenta = new DetallesVenta(conexion);
            venta = new Venta(conexion);
            agregaControlVenta();
            agregaControlDetallesVenta();
        }

        public void agregaControlVenta() {
            panelVentas.Controls.Add(venta);
            venta.Dock = DockStyle.Fill;
            venta.BringToFront();
        }

        public void agregaControlDetallesVenta()
        {
            panelVentas.Controls.Add(detallesVenta);
            detallesVenta.Dock = DockStyle.Fill;
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

        public void cambiaADetallesVenta(int idVenta) {
            detallesVenta.IdVenta = idVenta;
            detallesVenta.BringToFront();
            detallesVenta.muestraConsultaDetallesVenta();
        }

        public void cambiaAVenta() {
            venta.BringToFront();
        }
    }
}
