using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток.Для ввода данных от человека используется элемент TextBox.
//Семенов Дмитрий

namespace GuessNumber
{
    public partial class Form1 : Form
    {
        int number, count;
        public Form1()
        {
            InitializeComponent();
        }

        void NewGame()
        {
            MessageBox.Show("Угадайте целое число от 1 до 100 включительно");
            Random random = new Random();
            number = random.Next(1, 101);
            count = 0;
            groupBox1.Visible = true;
        }
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Действительно выйти?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text, out int a))
            {
                count++;
            }
            else
            {
                MessageBox.Show("Введите целое число!");
            }
            textBox1.Text = "";
            if(a==number)
            {
                MessageBox.Show($"Вы угадали число {number} за {count} попыток");
                if (MessageBox.Show("Хотите сыграть еще?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    NewGame();
                }
                else
                {
                    this.Close();
                }
            }else if(a<number)
            {
                MessageBox.Show($"Число {a} меньше загаданного");
            }
            else
            {
                MessageBox.Show($"Число {a} больше загаданного");
            }
        }
    }
}
