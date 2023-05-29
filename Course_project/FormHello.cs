using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project
{
    public partial class FormHello : Form
    {
        private System.Windows.Forms.Timer timer;
        public FormHello()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += delegate
            {
                this.Close();
            };
            timer.Interval = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;
            timer.Start();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
