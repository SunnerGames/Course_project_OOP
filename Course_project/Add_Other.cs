using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project
{
    public partial class Add_Other : Form
    {
        public static string firstName = "";
        public static string lastName = "";
        public static string date = "";
        public static string phone = "";
        public static string role = "";
        public Add_Other()
        {
            InitializeComponent();
        }

        bool CheckOnCorrectName(TextBox tb) => Regex.IsMatch(tb.Text, @"^[А-ЯЁ][а-яё]") ||
            (tb.BackColor = Color.MistyRose) != Color.MistyRose;
        bool CheckOnCorrectDate(TextBox tb) => DateTime.TryParse(tb.Text, out _) ||
            (tb.BackColor = Color.MistyRose) != Color.MistyRose;
        bool CheckOnCorrectPhone(TextBox tb) => Regex.IsMatch(tb.Text, @"\d{9}") ||
            (tb.BackColor = Color.MistyRose) != Color.MistyRose;
        bool CheckOnCorrectRole(ComboBox cb) => !(cb.SelectedItem is null) ||
            (cb.BackColor = Color.MistyRose) != Color.MistyRose;

        bool FlagCorrect =>
            CheckOnCorrectName(tb_Name) &
            CheckOnCorrectName(tb_Surname) &
            CheckOnCorrectDate(tb_Date) &
            CheckOnCorrectPhone(tb_Phone) &
            CheckOnCorrectRole(cb_Role);

        void Control_Click(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.WhiteSmoke;
        }



        private void btn_Back_Click(object sender, EventArgs e)
        {
            firstName = "";
            lastName = "";
            date = "";
            phone = "";
            role = "";
            Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (FlagCorrect)
            {
                firstName = tb_Name.Text;
                lastName = tb_Surname.Text;
                date = tb_Date.Text;
                phone = tb_Phone.Text;
                role = cb_Role.Text;

                Close();
            }
            else
                MessageBox.Show($"Некорректные данные", "Добавление гостя или жюри", 0, MessageBoxIcon.Information);
        }
    }
}
