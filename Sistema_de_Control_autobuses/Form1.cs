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

namespace Sistema_de_Control_autobuses
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            SqlConnection Conexion = new SqlConnection("server = DESKTOP-F5K59CG\\SQLEXPRESS ; database = Autobuses ; integrated security = true ");
            Conexion.Open();
            
            MessageBox.Show("Se ha conectado a la base de datos");
            Conexion.Close();
        }



        

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            
            SqlConnection Conexion = new SqlConnection("server = DESKTOP-F5K59CG\\SQLEXPRESS ; database = Autobuses ; integrated security = true ");
            Conexion.Open();

            string Nombre = txt_Nombre.Text;

            string Apellido = txt_apellido.Text;
      
            string FechaN = txt_fecha_de_nacimiento.Text;
            
            string Cedula = txt_cedula.Text;

            string ID = txt_ID.Text;

            

            string Cadena = "insert into Chofer(ID_Chofer,Nombre,Apellido,FechaN,Cedula) values('" + ID + "','" + Nombre + "','" + Apellido + "', '" + FechaN + "','" + Cedula + "')";
            SqlCommand comando = new SqlCommand(Cadena, Conexion);
            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos se han guardado");
            txt_cedula.Text = "";
            txt_Nombre.Text = "";
            txt_apellido.Text = "";
            txt_fecha_de_nacimiento.Text = "";
            txt_ID.Text = "";

            Form4.getID1(int.Parse(ID));
            
            Conexion.Close();
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            
            Form Formulario = new Form2();
            Formulario.Show();

            this.Hide();
        }
    }
}
