using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator
{
    public partial class Form1 : Form
    {


        

        public Form1()
        {
            InitializeComponent();

        }
    

        

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            int counter = int.Parse(textBox2.Text);

            Random random1 = new Random();
            StringBuilder builder = new StringBuilder();

            char ch;


            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random1.NextDouble() + 65)));
                    builder.Append(ch);
                }

                string city = builder.ToString();
                builder.Clear();



                for (int j = 0; j < 6; j++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random1.NextDouble() + 65)));
                    builder.Append(ch);
                }

                string postalCode = builder.ToString();
                builder.Clear();

                for (int j = 0; j < 35; j++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random1.NextDouble() + 65)));
                    builder.Append(ch);
                }

                string road = builder.ToString();
                builder.Clear();

                for (int j = 0; j < 5; j++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random1.NextDouble() + 65)));
                    builder.Append(ch);
                }

                string number = builder.ToString();
                builder.Clear();

                string query = "INSERT INTO Adres(Kod_pocztowy,Miasto,Ulica,Numer_domu)\n";
                query += $" VALUES ('{postalCode}','{city}','{road}','{number}');\n";

                textBox1.AppendText(query);
            }
        }
    }
}
