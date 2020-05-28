using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if(Exchange.Index>=0)
            {
                textBox1.Text = Exchange.Sum.ToString();
                textBox2.Text = Exchange.Description;
                dateTimePicker1.Value = Exchange.Date;
                if(Exchange.Type=="Доход")
                {
                    comboBox1.SelectedIndex=1;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            else
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Exchange.Index>=0)
            {
                Exchange.Sum = Double.Parse(textBox1.Text);
                Exchange.Description = textBox2.Text;
                Exchange.Date = dateTimePicker1.Value;
                if ((string)comboBox1.SelectedItem == "Доход")
                {
                    Exchange.Type = "Доход";
                }
                else
                {
                    Exchange.Type = "Расход";
                }
                Exchange.Edit = 1;
            }
            else
            {
                Exchange.Sum = Double.Parse(textBox1.Text);
                Exchange.Description = textBox2.Text;
                Exchange.Date = dateTimePicker1.Value;
                if ((string)comboBox1.SelectedItem == "Доход")
                {
                    Exchange.Type = "Доход";
                }
                else
                {
                    Exchange.Type = "Расход";
                }
                Exchange.Edit = 2;
            }
            
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char number = e.KeyChar;

            //if (!Char.IsDigit(number) || e.KeyChar == '.' || e.KeyChar == ',')
            //{
            //    e.Handled = true;
            //}
            //if (e.KeyChar =='.' || e.KeyChar == ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            string tmp = textBox1.Text.Trim();
            string outS = string.Empty;
            bool zapyataya = true;
            foreach (char ch in tmp)

                if (Char.IsDigit(ch) || (ch == ',' && zapyataya))
                {
                    outS += ch;
                    if (ch == ',')
                        zapyataya = false;
                }

            textBox1.Text = outS;
            textBox1.SelectionStart = outS.Length;

            if (str.Contains("."))
            {
                string s = str.Replace(".", ",");
                textBox1.Clear();
                textBox1.AppendText(str.Replace(".", ","));

            }
        }
    }
}
