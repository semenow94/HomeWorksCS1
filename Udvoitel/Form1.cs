using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udvoitel.Model;

namespace Udvoitel
{
    public partial class Form1 : Form
    {
        GameDoubler game;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToLongTimeString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Warning",MessageBoxButtons.YesNo)==DialogResult.Yes)  this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            game = new GameDoubler();
            game.action += UpdateInfo;
            UpdateInfo();
            btnMulti.Enabled = true;
            btnPlus.Enabled = true;
            
        }

        void UpdateInfo()
        {
            lblCount.Text = game.Count.ToString();
            lblCurrent.Text = game.Current.ToString();
            lblFinish.Text = game.Finish.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            game.Plus();
            
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            game.Multi();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Back();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.Reset();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exchange.Current = game.Current;
            formAbout about = new formAbout();
            about.ShowDialog();
        }
    }
}
