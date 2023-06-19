using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoConstruccion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DESKTOP-CM1NFV1\\SQLEXPRESS; database=ProyectoC; integrated security=true");
            conexion.Open();
            string placa = textBox1.Text;
            string marca = textBox2.Text;
            string color = textBox3.Text;
            string nro_vehiculos = textBox4.Text;
            string precio = textBox5.Text;
            string estado = textBox6.Text;

            string cadena = "insert into vehiculos(placa,marca,color,nro_vehiculos,precio,estado) values ('" + placa + "','" + marca + "','" + color + "','" + nro_vehiculos + "','" + precio + "','" + estado + "')";
            SqlCommand comando = new SqlCommand(cadena, conexion);

            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos se guardaron correctamente");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            conexion.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DESKTOP-CM1NFV1\\SQLEXPRESS; database=ProyectoC; integrated security=true");
            conexion.Open();
            string cadena = "select placa, marca, color, nro_vehiculos, precio, estado from vehiculos";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                
                textBox7.AppendText(registros["placa"].ToString());
                textBox7.AppendText(" - ");
                textBox7.AppendText(registros["marca"].ToString());
                textBox7.AppendText(" - ");
                textBox7.AppendText(registros["color"].ToString());
                textBox7.AppendText(" - ");
                textBox7.AppendText(registros["nro_vehiculos"].ToString());
                textBox7.AppendText(" - ");
                textBox7.AppendText(registros["precio"].ToString());
                textBox7.AppendText(" - ");
                textBox7.AppendText(registros["estado"].ToString());
                textBox7.AppendText(Environment.NewLine);
            }
            conexion.Close();
        }
    }
}
