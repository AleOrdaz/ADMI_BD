﻿using System;
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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
        }

        /**Llamado de las ventas**/
        private void Venta_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            venta.Show();
        }

        private void Devolucion_Click(object sender, EventArgs e)
        {
            Devoluciones devolucion = new Devoluciones();
            devolucion.Show();
        }
    }
}
