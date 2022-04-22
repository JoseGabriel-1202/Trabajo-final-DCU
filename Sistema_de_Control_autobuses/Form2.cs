using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_de_Control_autobuses
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form1();
            Formulario1.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Formulario3 = new Form3();
            Formulario3.Show();
            
            this.Hide();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            SqlConnection Conexion = new SqlConnection("server = DESKTOP-F5K59CG\\SQLEXPRESS ; database = Autobuses ; integrated security = true ");
            Conexion.Open();

            MessageBox.Show("Se ha conectado a la base de datos y se han insertado los datos");

            string Marca = txt_marca.Text;

            string Placa = txt_placa.Text;

            string Modelo = txt_modelo.Text;

            string Color = txt_color.Text;

            string Año = txt_año.Text;

            string ID = txt_ID.Text;

           

            string Cadena = "insert into Guaguas(ID_Guaguas,Marca,Placa,Modelo,Color,Año) values('" + ID + "','" + Marca + "','" + Placa + "','" + Modelo + "', '" + Color + "','" + Año + "')";
            SqlCommand comando = new SqlCommand(Cadena, Conexion);
            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos se han guardado");
            txt_marca.Text = "";
            txt_placa.Text = "";
            txt_modelo.Text = "";
            txt_color.Text = "";
            txt_año.Text = "";
            txt_ID.Text = "";

            Form4.getID2(int.Parse(ID));

            Conexion.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }

}
