using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuradiBird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 frm2 = new Form2();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 295;
            this.Height = 238;
            this.BackColor = Color.FromArgb(0, 128, 192);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
