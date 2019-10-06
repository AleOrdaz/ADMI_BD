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
            detallesDevolucion = new DetallesDevolucion(conexion2);
            devolucion = new Devolucion(conexion2);
            agregaControlDevolucion();
            agregaControlDetallesDevolucion();
        }

        public void agregaControlDevolucion()
        {
            panelDevoluciones.Controls.Add(devolucion);
            devolucion.Dock = DockStyle.Fill;
            devolucion.BringToFront();
        }

        public void agregaControlDetallesDevolucion()
        {
            panelDevoluciones.Controls.Add(detallesDevolucion);
            detallesDevolucion.Dock = DockStyle.Fill;
        }

        public void cambiaADetallesDevolucion(int idVenta)
        {
            detallesDevolucion.IdDevolucion = idVenta;
            detallesDevolucion.BringToFront();
            detallesDevolucion.muestraConsultaDetallesDevolucion();
        }

        public void cambiaADevolucion()
        {
            devolucion.BringToFront();
        }
    }
}
