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
    public partial class Form4 : Form
    {
        public static int ID_Chofer { get; set; }
        public static int ID_Rutas { get; set; }
        public static int ID_Guagua { get; set; }
        public Form4()
        {
            InitializeComponent();
        }

        public static void getID1(int ID_Chofer)
        {

            Form4.ID_Chofer = ID_Chofer;

        }

        public static void getID2(int ID_Guagua)
        {

            Form4.ID_Guagua = ID_Guagua;

        }

        public static void getID3(int ID_Rutas)
        {

            Form4.ID_Rutas = ID_Rutas;

        }
        class conexion {

            SqlCommand cmd;
            SqlConnection cnn;
            SqlDataReader dr;

            public conexion()
            {
                try {
                    cnn = new SqlConnection("server = DESKTOP-F5K59CG\\SQLEXPRESS ; database = Autobuses  ; integrated security = true ");
                    cnn.Open();
                    

                }
                catch {

                    MessageBox.Show("No se ha conectado");
                }


            }
            public void llenarItems(ComboBox cb)
            {
                try
                {
                    cmd = new SqlCommand("Select Nombre From Chofer",cnn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cb.Items.Add(dr["Nombre"].ToString());
                    }
                    dr.Close();
                }
                catch
                {
                    MessageBox.Show("No Se ha podido llenar");

                }

            }

            public void llenarItems2(ComboBox cb)
            {
                try
                {
                    cmd = new SqlCommand("Select Marca From Guaguas", cnn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cb.Items.Add(dr["Marca"].ToString());
                    }
                    dr.Close();
                }
                catch
                {
                    MessageBox.Show("No Se ha podido llenar");

                }

            }

            public void llenarItems3(ComboBox cb)
            {
                try
                {
                    cmd = new SqlCommand("Select Nombre_Ruta From Rutas", cnn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cb.Items.Add(dr["Nombre_Ruta"].ToString());
                    }
                    dr.Close();
                }
                catch
                {
                    MessageBox.Show("No Se ha podido llenar");

                }

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conexion c = new conexion();
            c.llenarItems(comboBox1);
            c.llenarItems2(comboBox2);
            c.llenarItems3(comboBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Conexion = new SqlConnection("server = DESKTOP-F5K59CG\\SQLEXPRESS ; database = Autobuses ; integrated security = true ");
            Conexion.Open();
            string CB = comboBox1.Text;
            string CB2 = comboBox2.Text;
            string CB3 = comboBox3.Text;

            string Cadena = "Select Nombre_Chofer from Relacion where Nombre_Chofer = '"+ CB + "'";
            string Cadena2 = "Select Nombre_Guaguas from Relacion where Nombre_Guaguas ='" + CB2 + "'";
            string Cadena3 = "Select Nombre_Rutas from Relacion where Nombre_Rutas ='"+ CB3 + "'";  

            SqlCommand comando1 = new SqlCommand(Cadena, Conexion);
            SqlCommand comando2 = new SqlCommand(Cadena2, Conexion);
            SqlCommand comando3 = new SqlCommand(Cadena3, Conexion);

            SqlDataAdapter SQLAD1 = new SqlDataAdapter(comando1);
            SqlDataAdapter SQLAD2 = new SqlDataAdapter(comando2);
            SqlDataAdapter SQLAD3 = new SqlDataAdapter(comando3);

            DataTable Dt1 = new DataTable();
            DataTable Dt2 = new DataTable();
            DataTable Dt3 = new DataTable();


            SQLAD1.Fill(Dt1);
            SQLAD2.Fill(Dt2);
            SQLAD3.Fill(Dt3);
            /*int Row1 = Dt.;
            int Row2 = comando2.ExecuteNonQuery();
            int Row3 = comando3.ExecuteNonQuery();*/

            if (Dt1.Rows.Count ==1|| Dt2.Rows.Count == 1|| Dt3.Rows.Count == 1)
            {
                MessageBox.Show("La ruta ya fue seleccionada");
            }
            else
            {
                string Insertar = "insert into Relacion (Nombre_Chofer,Nombre_Guaguas,Nombre_Rutas) values ('" + CB + "','" + CB2 + "','" + CB3 + "')";
                SqlCommand Cad = new SqlCommand(Insertar, Conexion);
                Cad.ExecuteNonQuery();
            }



        }
    }
}
