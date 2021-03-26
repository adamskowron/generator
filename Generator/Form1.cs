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
            textBoxOut.ReadOnly = true;
            textBoxOut.Multiline = true;
            textBoxOut.AcceptsReturn = true;
            comboBoxDataType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            textBoxOut.Clear();
            int counter = int.Parse(textBoxQueryCounter.Text);
            textBoxQueryCounter.ReadOnly = false;

            char ch;
            Random random1 = new Random();
            StringBuilder builder = new StringBuilder();
            
            for (int i = 0; i < counter; i++)
            {
                builder.Append($"INSERT INTO {textBox1.Text} VALUES (");
                foreach(string item in listBoxValues.Items)
                {
                    String[] words = item.Split('/');
                    
                    if(words[0].Equals("INT"))
                    {
                        for (int j = 0; j< Int32.Parse( words[1]) ; j++)
                        {
                            int num = random1.Next(0,9);
                            builder.Append(num.ToString());
                        }
                        builder.Append(",");
                        
                    }
                    else
                    {
                        builder.Append("\"");
                        for (int j = 0; j < Int32.Parse(words[1]); j++)
                        {
                            builder.Append(Convert.ToChar(
                                Convert.ToInt32(Math.Floor(26 * random1.NextDouble() + 65))));
                        }
                        builder.Append("\"");
                        builder.Append(",");
                    }
                }
                builder.Length -= 1;
                builder.Append(");" + Environment.NewLine);
                

            }
            textBoxOut.AppendText(builder.ToString());
         
            builder.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int lenght = -1;
            if (int.TryParse(textBoxLenght.Text, out lenght))
            {
                if (comboBoxDataType.Text.Equals("INT"))
                {
                    listBoxValues.Items.Add("INT/" + textBoxLenght.Text);

                }
                else if (comboBoxDataType.Text.Equals("STRING"))
                {
                    listBoxValues.Items.Add("STRING/" + textBoxLenght.Text);
                }
            }
            else
            {
                MessageBox.Show("Incorrect input", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxValues);
            selectedItems = listBoxValues.SelectedItems;

            if (listBoxValues.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBoxValues.Items.Remove(selectedItems[i]);
            }
            else
                MessageBox.Show("No item selected");
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(textBoxOut.Text);
        }
    }
}
