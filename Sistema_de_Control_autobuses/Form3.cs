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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Formulario2 = new Form2();
            Formulario2.Show();

            this.Hide();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            SqlConnection Conexion = new SqlConnection("server = DESKTOP-F5K59CG\\SQLEXPRESS ; database = Autobuses  ; integrated security = true ");
            Conexion.Open();

            string Nombre_Ruta = txt_nombre_ruta.Text;

            string Numero_Ruta = txt_numero_ruta.Text;

            string ID = txt_ID.Text;

           

            string Cadena = "insert into Rutas(ID_Rutas,Nombre_Ruta,Numero_Ruta) values('" + ID + "','" + Nombre_Ruta + "','" + Numero_Ruta + "')";
            SqlCommand comando = new SqlCommand(Cadena, Conexion);
            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos se han guardado");
            txt_nombre_ruta.Text = "";
            txt_numero_ruta.Text = "";
            txt_ID.Text = "";

            Form4.getID3(int.Parse(ID));

            Conexion.Close();
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            Form Formulario4 = new Form4();
            Formulario4.Show();

            this.Hide();
        }
    }
}
