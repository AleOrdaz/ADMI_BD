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
    public partial class Vendedores : Form
    {
        SqlConnection conexion2; //Para poder conectar con la BD de SQL

        public Vendedores(SqlConnection conexion)
        { 
            InitializeComponent();
            conexion2 = conexion;
            Datos();
        }

        //Muestra los Datos en el dataGrid 
        private void Datos()
        {
            string query = "SELECT * FROM Almacen.Vendedor";
            SqlCommand comando = new SqlCommand(query, conexion2);
            SqlDataAdapter adapatador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapatador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        //Agregar Vendedores
        private void Agregar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Almacen.Vendedor(Nombre, Domicilio, Email, Telefono, FechaNac) VALUES (@Nombre, @Domicilio, @Email, @Telefono, @FechaNac)";
            SqlCommand comando = new SqlCommand(query, conexion2);
            comando.Parameters.AddWithValue("@Nombre", Nombre.Text);     
            comando.Parameters.AddWithValue("@Domicilio", Domicilio.Text);
            comando.Parameters.AddWithValue("@Email", Email.Text);
            comando.Parameters.AddWithValue("@Telefono", Telefono.Text);
            comando.Parameters.AddWithValue("@FechaNac", FechaNac.Text);

            try
            {
                comando.ExecuteNonQuery();
                //MessageBox.Show("Ingresado con Exito");
                Datos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Modifica los DATOS de los Vendedores
        private void Modificar_Click(object sender, EventArgs e)
        {
            string query = "UPDATE  Almacen.Vendedor SET Nombre = '" + Nombre.Text +
                                                              "', Domicilio = '" + Domicilio.Text +
                                                              "', Email = '" + Email.Text +
                                                              "', Telefono = '" + Telefono.Text +
                                                              "', FechaNac = '" + FechaNac.Text + "'" +
                        "WHERE IdVendedor = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            SqlCommand comando = new SqlCommand(query, conexion2);

            try
            {
                comando.ExecuteNonQuery();
                Datos();
                Nombre.Text = "";
                Domicilio.Text = "";
                Email.Text = "";
                Telefono.Text = "";
                FechaNac.Text = "";
                Agregar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar la hora en Fecha de nacimiento");
            }
        }

        //elimina los datos del vendedor
        private void Eliminar_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Almacen.Vendedor WHERE IdVendedor ="
                    + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            SqlCommand comando = new SqlCommand(query, conexion2);

            try
            {
                comando.ExecuteNonQuery();
                Datos();
                Nombre.Text = "";
                Domicilio.Text = "";
                Email.Text = "";
                Telefono.Text = "";
                FechaNac.Text = "";
                Agregar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //al seleccionar el nombre me da los datos el los texbox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Nombre.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            Domicilio.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            Email.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            Telefono.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            FechaNac.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            Agregar.Enabled = false;
        }
    }
}
