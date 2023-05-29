using System;
using System.Windows.Forms;

namespace Course_project
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_films_Click(object sender, EventArgs e)
        {
            Films Car = new Films();
            Car.ShowDialog();
        }

        private void btn_partcp_Click(object sender, EventArgs e)
        {
            Partcps Client = new Partcps();
            Client.ShowDialog();
        }

        private void btn_others_Click(object sender, EventArgs e)
        {
            Others Other = new Others();
            Other.ShowDialog();
        }
    }
}
