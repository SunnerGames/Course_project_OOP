using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Course_project
{
    public partial class Add_Partcp : Form
    {
        public static string firstName = "";
        public static string lastName = "";
        public static string date = "";
        public static string phone = "";
        public static int filmID = 0;

        public Add_Partcp()
        {
            InitializeComponent();
        }

        bool CheckOnCorrectName(TextBox tb) => Regex.IsMatch(tb.Text, @"^[А-ЯЁ][а-яё]") || 
            (tb.BackColor = Color.MistyRose) != Color.MistyRose;
        bool CheckOnCorrectDate(TextBox tb) => DateTime.TryParse(tb.Text, out _) || 
            (tb.BackColor = Color.MistyRose) != Color.MistyRose;
        bool CheckOnCorrectPhone(TextBox tb) => Regex.IsMatch(tb.Text, @"\d{9}") || 
            (tb.BackColor = Color.MistyRose) != Color.MistyRose;
        bool CheckOnCorrectID(TextBox tb) => (int.TryParse(tb.Text, out _) || 
            (tb.BackColor = Color.MistyRose) != Color.MistyRose);

        bool FlagCorrect =>
            CheckOnCorrectName(tb_Name) &
            CheckOnCorrectName(tb_Surname) &
            CheckOnCorrectDate(tb_Date) &
            CheckOnCorrectPhone(tb_Phone) &
            CheckOnCorrectID(tb_ID);

        void Control_Click(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.WhiteSmoke;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (FlagCorrect)
            {
                firstName = tb_Name.Text;
                lastName = tb_Surname.Text;
                date = tb_Date.Text;
                phone = tb_Phone.Text;
                filmID = Convert.ToInt32(tb_ID.Text);

                Close();
            }
            else
                MessageBox.Show($"Некорректные данные", "Добавление участника", 0, MessageBoxIcon.Information);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            firstName = "";
            lastName = "";
            date = "";
            phone = "";
            filmID = 0;
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tb_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Date_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
