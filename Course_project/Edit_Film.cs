using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Course_project
{
    public partial class Edit_Film : Form
    {
        private DataGridViewRow selectedRow;
        /*public static string title = "";
        public static string filmGenre = "";
        public static int ratesNumber = 0;
        public static double avgRate = 0;
        public static int productionYear = 0;
        public static string nomination = "";*/
        public Edit_Film(/*string title_got, string filmGenre_got, string ratesNumber_got, string avgRate_got, string productionYear_got, string nomination_got,*/ DataGridViewRow row)
        {
            InitializeComponent();
            selectedRow = row;
            /*title = title_got;
            filmGenre = filmGenre_got;
            ratesNumber = Convert.ToInt32(ratesNumber_got);
            avgRate = Convert.ToInt32(avgRate_got);
            productionYear = Convert.ToInt32(productionYear_got);
            nomination = nomination_got;*/
            tb_Title.Text = selectedRow.Cells[1].Value.ToString();
            cb_FilmGenre.SelectedItem = selectedRow.Cells[2].Value.ToString();
            tb_RatesNumber.Text = selectedRow.Cells[3].Value.ToString();
            tb_AvgRate.Text = selectedRow.Cells[4].Value.ToString();
            tb_ProductionYear.Text = selectedRow.Cells[5].Value.ToString();
            tb_Nomination.Text = selectedRow.Cells[6].Value.ToString();
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

        async void Edit_Film_Load(object sender, EventArgs e)
        {
            /*var films = await ReadFromFile<InfoFilms>(FILMS_JSON);
            Print(films[1]);*/
        }

        async Task WriteToFile<T>(List<T> data, string FILE_NAME)
        {
            using (var streamWriter = new StreamWriter(FILE_NAME, false))
            {
                await streamWriter.WriteAsync(await Task.Run(() => JsonConvert.SerializeObject(data)));
            }
        }

        //чтение из файла json
        async Task<List<T>> ReadFromFile<T>(string FILE_NAME)
        {
            using (var streamReader = new StreamReader(FILE_NAME))
            {
                return await Task.Run(async () => JsonConvert.DeserializeObject<List<T>>(await streamReader.ReadToEndAsync()) ?? new List<T>());
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (FlagCorrect)
            {
                /*title = tb_Title.Text;
                filmGenre = cb_FilmGenre.SelectedItem as string;
                ratesNumber = Convert.ToInt32(tb_RatesNumber.Text);
                avgRate = Convert.ToDouble(tb_AvgRate.Text);
                productionYear = Convert.ToInt32(tb_ProductionYear.Text);
                nomination = tb_Nomination.Text;*/
                selectedRow.Cells[1].Value = tb_Title.Text;
                selectedRow.Cells[2].Value = cb_FilmGenre.SelectedItem as string;
                selectedRow.Cells[3].Value = Convert.ToInt32(tb_RatesNumber.Text);
                selectedRow.Cells[4].Value = Convert.ToDouble(tb_AvgRate.Text);
                selectedRow.Cells[5].Value = Convert.ToInt32(tb_ProductionYear.Text); 
                selectedRow.Cells[6].Value = tb_Nomination.Text;
                Close();
                MessageBox.Show($"Успешно изменено!", "Редактирование фильма", 0, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show($"Некорректные данные", "Редактирование фильма", 0, MessageBoxIcon.Information);
        }
    }
}
