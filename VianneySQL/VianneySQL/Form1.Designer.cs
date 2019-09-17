namespace VianneySQL
{
    partial class Vianney
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Productos = new System.Windows.Forms.ToolStripMenuItem();
            this.Venta = new System.Windows.Forms.ToolStripMenuItem();
            this.Devolucion = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendedores,
            this.clienteToolStripMenuItem,
            this.Productos,
            this.Venta,
            this.Devolucion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(612, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Productos
            // 
            this.Productos.Name = "Productos";
            this.Productos.Size = new System.Drawing.Size(73, 20);
            this.Productos.Text = "Productos";
            this.Productos.Click += new System.EventHandler(this.Productos_Click);
            // 
            // Venta
            // 
            this.Venta.Name = "Venta";
            this.Venta.Size = new System.Drawing.Size(48, 20);
            this.Venta.Text = "Venta";
            this.Venta.Click += new System.EventHandler(this.Venta_Click);
            // 
            // Devolucion
            // 
            this.Devolucion.Name = "Devolucion";
            this.Devolucion.Size = new System.Drawing.Size(79, 20);
            this.Devolucion.Text = "Devolucion";
            this.Devolucion.Click += new System.EventHandler(this.Devolucion_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // vendedores
            // 
            this.vendedores.Name = "vendedores";
            this.vendedores.Size = new System.Drawing.Size(69, 20);
            this.vendedores.Text = "Vendedor";
            this.vendedores.Click += new System.EventHandler(this.vendedores_Click);
            // 
            // Vianney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(612, 371);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Vianney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vianney";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Productos;
        private System.Windows.Forms.ToolStripMenuItem Venta;
        private System.Windows.Forms.ToolStripMenuItem Devolucion;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendedores;
    }
}

