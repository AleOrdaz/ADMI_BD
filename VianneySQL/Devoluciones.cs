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
        DetallesDevolucion detallesDevolucion;
        Devolucion devolucion;

        public Devoluciones(SqlConnection conexion)
        {
            InitializeComponent();
            conexion2 = conexion;
            
            devolucion = new Devolucion(conexion2);
            agregaControlDevolucion();
        }

        public void agregaControlDevolucion()
        {
            panelDevoluciones.Controls.Add(devolucion);
            devolucion.Dock = DockStyle.Fill;
            devolucion.BringToFront();
        }

        public void agregaControlDetallesDevolucion()
        {
            if (!panelDevoluciones.Contains(detallesDevolucion)) {
                panelDevoluciones.Controls.Add(detallesDevolucion);
                detallesDevolucion.Dock = DockStyle.Fill;
            }   
        }

        public void cambiaADetallesDevolucion(int idVenta, int idDevolucion)
        {
            detallesDevolucion = new DetallesDevolucion(conexion2);
            agregaControlDetallesDevolucion();
            detallesDevolucion.IdVenta = idVenta;
            detallesDevolucion.IdDevolucion = idDevolucion;
            detallesDevolucion.muestraConsultaProductos();
            detallesDevolucion.BringToFront();
            detallesDevolucion.muestraConsultaDetallesDevolucion();
        }

        public void cambiaADevolucion()
        {
            devolucion.BringToFront();
            devolucion.muestraConsulta();
        }
    }
}
