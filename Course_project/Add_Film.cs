using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Course_project
{
	public partial class Add_Film : Form
	{
		public static string title = "";
		public static string filmGenre = "";
		public static int ratesNumber = 0;
		public static double avgRate = 0;
		public static int productionYear = 0;
		public static string nomination = "";
		
		public Add_Film()
		{
			InitializeComponent();
		}

		bool CheckOnCorrectTitle(TextBox tb) => tb.Text != "" || (tb.BackColor = Color.MistyRose) != Color.MistyRose;
		bool CheckOnCorrectFilmGenre(ComboBox cb) => !(cb.SelectedItem is null) || (cb.BackColor = Color.MistyRose) != Color.MistyRose;
		bool CheckOnCorrectNumber(TextBox tb) => int.TryParse(tb.Text, out _) || (tb.BackColor = Color.MistyRose) != Color.MistyRose;
		bool CheckOnCorrectAvgRate(TextBox tb) => /*double.TryParse(tb.Text, out _)*/Regex.IsMatch(tb.Text, "^(10|[0-9])$") || (tb.BackColor = Color.MistyRose) != Color.MistyRose;

		bool FlagCorrect =>
			CheckOnCorrectTitle(tb_Title) &
			CheckOnCorrectFilmGenre(cb_FilmGenre) &
			CheckOnCorrectAvgRate(tb_AvgRate) &
			CheckOnCorrectNumber(tb_RatesNumber) &
			CheckOnCorrectNumber(tb_ProductionYear) &
			CheckOnCorrectTitle(tb_Nomination);

		void Control_Click(object sender, EventArgs e) => (sender as Control).BackColor = Color.WhiteSmoke;

		private void btn_Add_Click(object sender, EventArgs e)
		{

			if (FlagCorrect)
			{
				title = tb_Title.Text;
				filmGenre = cb_FilmGenre.SelectedItem as string;
				ratesNumber = Convert.ToInt32(tb_RatesNumber.Text);
				avgRate = Convert.ToDouble(tb_AvgRate.Text);
				productionYear = Convert.ToInt32(tb_ProductionYear.Text);
				nomination = tb_Nomination.Text;

                Close();
			}
			else
				MessageBox.Show($"Некорректные данные", "Добавление фильма", 0, MessageBoxIcon.Information);
		}

		private void btn_Back_Click(object sender, EventArgs e)
		{
			title = "";
			filmGenre = "";
			ratesNumber = 0;
			avgRate = 0;
			productionYear = 0;
			nomination = "";
			Close();
		}

        private void label7_Click(object sender, EventArgs e)
        {

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

        private void cb_FilmGenre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_Nomination_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_ProductionYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_AvgRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_RatesNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Title_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
