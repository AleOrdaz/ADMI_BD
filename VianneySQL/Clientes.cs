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
        bool seleccion = false;
        private int indiceFila;
        
        public Clientes(SqlConnection conexion)
        {
            InitializeComponent();
            conexion2 = conexion;
            Datos();
            indiceFila = -1;
            toolStripButtonModificar.Enabled = toolStripButtonEliminar.Enabled = false;
        }

        //Muestra los Datos en el dataGrid 
        private void Datos()
        {
            string query = "SELECT * FROM Transaccion.Cliente";
            SqlCommand comando = new SqlCommand(query, conexion2);
            SqlDataAdapter adapatador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapatador.Fill(tabla);
            dataGridViewCliente.DataSource = tabla;
        }

        //Agrega a un nuevo Cliente
        private void toolStripButtonAgregar_Click_1(object sender, EventArgs e)
        {
            if (Nombre.Text != "" && Domicilio.Text != "" && Email.Text != "" && Telefono.Text != "")
            {
                string query = "INSERT INTO Transaccion.Cliente(Nombre, Domicilio, Email, Telefono, FechaNac) VALUES (@Nombre, @Domicilio, @Email, @Telefono, @FechaNac)";
                SqlCommand comando = new SqlCommand(query, conexion2);
                comando.Parameters.AddWithValue("@Nombre", Nombre.Text);
                comando.Parameters.AddWithValue("@Domicilio", Domicilio.Text);
                comando.Parameters.AddWithValue("@Email", Email.Text);
                comando.Parameters.AddWithValue("@Telefono", Telefono.Text);
                comando.Parameters.AddWithValue("@FechaNac", dateTimePickerFecha.Value.ToString("MM/dd/yyyy"));

                try
                {
                    comando.ExecuteNonQuery();
                    Datos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            { MessageBox.Show("Favor de completar todos los campos", "Error", MessageBoxButtons.OK); }
        }

        //Modifica los datos de un Cliente
        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            if (seleccion == true)
            {
                string query = "UPDATE Transaccion.Cliente SET Nombre = '" + Nombre.Text +
                                                  "', Domicilio = '" + Domicilio.Text +
                                                  "', Email = '" + Email.Text +
                                                  "', Telefono = '" + Telefono.Text +
                                                  "', FechaNac = '" + dateTimePickerFecha.Value.ToString("MM/dd/yyyy") + "'" +
                "WHERE IdCliente = " + dataGridViewCliente.Rows[dataGridViewCliente.CurrentCell.RowIndex].Cells[0].Value.ToString();
                SqlCommand comando = new SqlCommand(query, conexion2);

                try
                {
                    comando.ExecuteNonQuery();
                    Datos();
                    Nombre.Text = "";
                    Domicilio.Text = "";
                    Email.Text = "";
                    Telefono.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eliminar la hora en Fecha de nacimiento", "Error", MessageBoxButtons.OK);
                }
            }
            else
            { MessageBox.Show("Seleccionar el elemento a Modificar", "Error", MessageBoxButtons.OK); }

        }

        //Elimina los datos de un cliente
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            if (seleccion == true)
            { 
                string query = "DELETE FROM Transaccion.Cliente" +
                               " WHERE IdCliente =" + dataGridViewCliente.Rows[dataGridViewCliente.CurrentCell.RowIndex].Cells[0].Value.ToString();
                SqlCommand comando = new SqlCommand(query, conexion2);

                try
                {
                    comando.ExecuteNonQuery();
                    Datos();
                    Nombre.Text = "";
                    Domicilio.Text = "";
                    Email.Text = "";
                    Telefono.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            { MessageBox.Show("Seleccionar el elemento a Eliminar", "Error", MessageBoxButtons.OK); }
        }
        //al seleccionar el nombre me da los datos el los texbox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indiceFila = e.RowIndex;
            if (indiceFila != -1)
            {
                DataGridViewRow fila = dataGridViewCliente.Rows[indiceFila];
                Nombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
                Domicilio.Text = Convert.ToString(fila.Cells["Domicilio"].Value);
                dateTimePickerFecha.Value = DateTime.Parse(Convert.ToString(fila.Cells["FechaNac"].Value));
                Email.Text = Convert.ToString(fila.Cells["Email"].Value);
                Telefono.Text = Convert.ToString(fila.Cells["Telefono"].Value);
                seleccion = true;
                toolStripButtonEliminar.Enabled = toolStripButtonModificar.Enabled = true;
            }
            
        }
    }
}
