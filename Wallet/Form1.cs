using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Wallet
{
    public partial class Form1 : Form
    {
        Wallet coshel;
        string filename = "save.xml";
        public void WriteToXML(string filename, Wallet game)
        {
            FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(Wallet));
            serializer.Serialize(file, game);
            file.Close();
        }
        public void ReadFromXML(string filename, out Wallet game)
        {
            if(File.Exists(filename))
            {
                FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(Wallet));
                game = (Wallet)serializer.Deserialize(file);
                file.Close();
            }
            else
            {
                game = new Wallet();
            }
            
        }
        public void UpdateInfo()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Сумма";
            dataGridView1.Columns[1].HeaderText = "Описание";
            dataGridView1.Columns[2].HeaderText = "Дата";
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            if(coshel.opers.Count>0)
            {
                dataGridView1.RowCount = coshel.opers.Count;
                for (int i = coshel.opers.Count - 1; i >= 0; i--)
                {
                    if(coshel.opers[i].Type=="Расход")
                    {
                        dataGridView1.Rows[coshel.opers.Count - i - 1].Cells[0].Value = coshel.opers[i].Sum*-1;
                    }
                    else
                    {
                        dataGridView1.Rows[coshel.opers.Count - i - 1].Cells[0].Value = coshel.opers[i].Sum;
                    } 
                    dataGridView1.Rows[coshel.opers.Count - i - 1].Cells[1].Value = coshel.opers[i].Description;
                    dataGridView1.Rows[coshel.opers.Count - i - 1].Cells[2].Value = coshel.opers[i].Date;
                }
            }
            label2.Text = coshel.Money.ToString();
        }
        public Form1()
        {
            InitializeComponent();
            
            DateTime date = new DateTime();
            date = DateTime.Now;
            ReadFromXML(filename, out coshel);
            coshel.action += UpdateInfo;
            UpdateInfo();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            if (MessageBox.Show("Действительно удалить операцию?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                coshel.DelOperation(coshel.opers.Count - index - 1);
            }    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteToXML(filename, coshel);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Изменение данных";
            int index = coshel.opers.Count - dataGridView1.CurrentRow.Index - 1;
            Exchange.Index = index;
            Exchange.Sum = coshel.opers[index].Sum;
            Exchange.Description = coshel.opers[index].Description;
            Exchange.Date = coshel.opers[index].Date;
            Exchange.Type = coshel.opers[index].Type;
            form.ShowDialog();
            if(Exchange.Edit==1)
            {
                coshel.EditOperation(Exchange.Index, Exchange.Sum, Exchange.Date, Exchange.Description, Exchange.Type);
                Exchange.Index = -1;
                Exchange.Edit = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Новая операция";
            form.ShowDialog();
            if (Exchange.Edit == 2)
            {
                coshel.AddOperation(Exchange.Sum, Exchange.Date, Exchange.Description, Exchange.Type);
                Exchange.Index = -1;
                Exchange.Edit = 0;
            }
        }
    }
}
