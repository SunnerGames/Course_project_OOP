using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Linq;

namespace Course_project
{
    public partial class Films : Form
    {
        const string FILMS_JSON = "Films.json";
        const string PARTCP_JSON = "Partcp.json";
        int number = 0;
        int ID = 1;

        public Films()
        {
            Task.Run(() => File.Open(FILMS_JSON, FileMode.OpenOrCreate).Close());
            Task.Run(() => File.Open(PARTCP_JSON, FileMode.OpenOrCreate).Close());

            InitializeComponent();
        }

        async void Films_Load(object sender, EventArgs e)
        {
            if (File.Exists(FILMS_JSON))
            {
                var film_number = await ReadFromFile<InfoFilms>(FILMS_JSON);


                if (film_number.Count != 0)
                {
                    foreach (var films in film_number)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[number].Cells[0].Value = films.FilmID;
                        dataGridView1.Rows[number].Cells[1].Value = films.Title;
                        dataGridView1.Rows[number].Cells[2].Value = films.FilmGenre;
                        dataGridView1.Rows[number].Cells[3].Value = films.RatesNumber;
                        dataGridView1.Rows[number].Cells[4].Value = films.AvgRate;
                        dataGridView1.Rows[number].Cells[5].Value = films.ProductionYear;
                        dataGridView1.Rows[number].Cells[6].Value = films.Nomination;
                        number++;
                        if (ID == films.FilmID) ID++;
                    }
                }
            }
        }

        //запись в файл json
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

        void Control_Click(object sender, EventArgs e) => (sender as Control).BackColor = Color.White;

        async void btn_Add_Click(object sender, EventArgs e)
        {
            Add_Film FormAdd = new Add_Film();
            FormAdd.ShowDialog();

            string title = Add_Film.title;
            string filmGenre = Add_Film.filmGenre;
            int ratesNumber = Add_Film.ratesNumber;
            double avgRate = Add_Film.avgRate;
            int productionYear = Add_Film.productionYear;
            string nomination = Add_Film.nomination;
            int FilmID = ID;

            InfoFilms newFilm = new InfoFilms(title, filmGenre, ratesNumber, avgRate, productionYear, nomination, FilmID);

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(filmGenre) && !string.IsNullOrEmpty(nomination) && (ratesNumber > 0) && (avgRate > 0)
            && (productionYear > 0) && (FilmID > 0))
            {
                var films = await ReadFromFile<InfoFilms>(FILMS_JSON);

                if (!films.Contains(newFilm))
                {
                    films.Add(newFilm);
                    ID++;

                    await WriteToFile(films, FILMS_JSON);

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[number].Cells[0].Value = FilmID;
                    dataGridView1.Rows[number].Cells[1].Value = title;
                    dataGridView1.Rows[number].Cells[2].Value = filmGenre;
                    dataGridView1.Rows[number].Cells[3].Value = ratesNumber;
                    dataGridView1.Rows[number].Cells[4].Value = avgRate;
                    dataGridView1.Rows[number].Cells[5].Value = productionYear;
                    dataGridView1.Rows[number].Cells[6].Value = nomination;
                    number++;
                }
                else
                {
                    MessageBox.Show($"Данный фильм уже представлен на фестивале", 
                        "Добавление фильма", 0, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        async void StringGrid1SetEditText(object sender, DataGridViewCellEventArgs e)
        {
            // Получаем уникальный идентификатор фильма
            int FilmID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

            // Ищем соответствующий объект в JSON файле
            var films = await ReadFromFile<InfoFilms>(FILMS_JSON);
            var item = films.FirstOrDefault(f => f.FilmID == FilmID);
            if (item == null)
                return;

            // Обновляем значение в объекте на основании столбца, который был отредактирован
            switch (e.ColumnIndex)
            {
                case 1:
                    item.Title = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    break;
                case 2:
                    item.FilmGenre = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    break;
                case 3:
                    int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out var ratesNumber);
                    item.RatesNumber = ratesNumber;
                    break;
                case 4:
                    double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out var avgRate);
                    item.AvgRate = avgRate;
                    break;
                case 5:
                    int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out var productionYear);
                    item.ProductionYear = productionYear;
                    break;
                case 6:
                    item.Nomination = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    break;
            }

            // Сохраняем измененный объект в JSON файле
             await WriteToFile<InfoFilms>(films, FILMS_JSON);
        }

        async void UpdateFilmsFromDataGridView()
        {
            List<InfoFilms> films = new List<InfoFilms>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int filmId;
                if (int.TryParse(row.Cells[0].Value.ToString(), out filmId))
                {
                    string title = row.Cells[1].Value?.ToString() ?? "";
                    string genre = row.Cells[2].Value?.ToString() ?? "";
                    int rateNumber;
                    int.TryParse(row.Cells[3].Value?.ToString(), out rateNumber);
                    double avgRate;
                    double.TryParse(row.Cells[4].Value?.ToString(), out avgRate);
                    int prodYear;
                    int.TryParse(row.Cells[5].Value?.ToString(), out prodYear);
                    string nomination = row.Cells[6].Value?.ToString() ?? "";

                    films.Add(new InfoFilms(title,genre,rateNumber,avgRate,prodYear,nomination,filmId)
                    /*{
                        Title = title,
                        FilmGenre = genre,
                        RatesNumber = rateNumber,
                        AvgRate = avgRate,
                        ProductionYear = prodYear,
                        Nomination = nomination,
                        FilmID = filmId
                    }*/);
                }
            }
            await WriteToFile(films, FILMS_JSON);
        }

        async void btn_Remove_Click(object sender, EventArgs e)
        {
            var Items = dataGridView1.SelectedRows;
            int selectCount = Items.Count;

            if (selectCount > 0)
            {
                var films = await ReadFromFile<InfoFilms>(FILMS_JSON);
                var partcp = await ReadFromFile<InfoPartcps>(PARTCP_JSON);

                foreach (var item in Items)
                {
                    int ID = Convert.ToInt32(((DataGridViewRow)item).Cells[0].Value);

                    foreach (var film in films)
                    {
                        if (ID == film.FilmID)
                        {
                            bool check = true;

                            foreach (var prt in partcp)
                            {
                                if (ID == prt.FilmID)
                                {
                                    MessageBox.Show($"Удаление невозможно, данный фильм представляется участником",
                                        "Удаление фильма", 0, MessageBoxIcon.Information);
                                    check = false;
                                    break;
                                }
                            }
                            if (check)
                            {
                                films.Remove(film);
                                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                                number--;
                                MessageBox.Show($"Фильм <{film.Title}> удалён",
                                    "Удаление фильма", 0, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                }
                
                await WriteToFile(films, FILMS_JSON);
            }
            else
            {
                MessageBox.Show("Выберите фильм для удаления", "Удаление фильма", 0, MessageBoxIcon.Information);
                return;
            }
        }

        bool Print(InfoFilms film)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[number].Cells[0].Value = film.FilmID;
            dataGridView1.Rows[number].Cells[1].Value = film.Title;
            dataGridView1.Rows[number].Cells[2].Value = film.FilmGenre;
            dataGridView1.Rows[number].Cells[3].Value = film.RatesNumber;
            dataGridView1.Rows[number].Cells[4].Value = film.AvgRate;
            dataGridView1.Rows[number].Cells[5].Value = film.ProductionYear;
            dataGridView1.Rows[number].Cells[6].Value = film.Nomination;
            number++;
            return true;
        }

        async void btn_filter_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Выберите фильтр", "Фильтрация", 0, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните поле", "Фильтрация", 0, MessageBoxIcon.Information);
                textBox1.BackColor = Color.MistyRose;
            }
            else
            {
                string filter = textBox1.Text;
                int fil;

                textBox2.Text = "";
                dataGridView1.Rows.Clear();
                number = 0;

                bool flag = false;

                var films = await ReadFromFile<InfoFilms>(FILMS_JSON);

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        foreach (var film in films)
                            if (film.FilmGenre == Convert.ToString(filter))
                                flag = Print(film);

                        if (flag == false)
                            MessageBox.Show($"Фильмы жанра '{filter}' не найдены, проверьте корректность ввода",
                                "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 1:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var film in films)
                                if (film.RatesNumber >= fil)
                                    flag = Print(film);
                            if (flag == false)
                                MessageBox.Show($"Фильмы с количеством оценок от {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 2:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var film in films)
                                if (film.RatesNumber < fil)
                                    flag = Print(film);

                            if (flag == false)
                                MessageBox.Show($"Фильмы с количеством оценок до {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 3:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var film in films)
                                if (film.AvgRate >= fil)
                                    flag = Print(film);

                            if (flag == false)
                                MessageBox.Show($"Фильмы со средней оценкой от {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 4:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var film in films)
                                if (film.AvgRate < fil)
                                    flag = Print(film);

                            if (flag == false)
                                MessageBox.Show($"Фильмы со средней оценкой до {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 5:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var film in films)
                                if (film.ProductionYear > fil)
                                    flag = Print(film);

                            if (flag == false)
                                MessageBox.Show($"Фильмы вышедшие после {filter} года не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 6:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var film in films)
                                if (film.ProductionYear < fil)
                                    flag = Print(film);

                            if (flag == false)
                                MessageBox.Show($"Фильмы вышедшие до {filter} года не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            dataGridView1.ClearSelection();

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Заполните поле", "Поиск", 0, MessageBoxIcon.Information);
                textBox2.BackColor = Color.MistyRose;
            }
            else
            {
                if (int.TryParse(textBox2.Text, out int fil))
                {
                    bool flag = false;
                    var Items = dataGridView1.Rows;

                    foreach (var item in Items)
                        if (Convert.ToInt32(((DataGridViewRow)item).Cells[0].Value) == fil)
                        {
                            ((DataGridViewRow)item).Selected = true;
                            flag = true;
                        }

                    if (flag == false)
                        MessageBox.Show($"Фильм с номером {fil} не найден, " +
                            $"проверьте корректность номера",
                            "Поиск", 0, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show($"Некорректные данные",
                            "Поиск", 0, MessageBoxIcon.Information);
            }
        }

        async void btn_Reset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.Rows.Clear();
            comboBox1.SelectedIndex = -1;
            number = 0;

            var films = await ReadFromFile<InfoFilms>(FILMS_JSON);

            foreach (var film in films)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[number].Cells[0].Value = film.FilmID;
                dataGridView1.Rows[number].Cells[1].Value = film.Title;
                dataGridView1.Rows[number].Cells[2].Value = film.FilmGenre;
                dataGridView1.Rows[number].Cells[3].Value = film.RatesNumber;
                dataGridView1.Rows[number].Cells[4].Value = film.AvgRate;
                dataGridView1.Rows[number].Cells[5].Value = film.ProductionYear;
                dataGridView1.Rows[number].Cells[6].Value = film.Nomination;
                number++;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        async void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2) { 
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            /*string title = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string filmGenre = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string ratesNumber = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string avgRate = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string productionYear = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            string nomination = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();*/
            Edit_Film FormEdit = new Edit_Film(/*title,filmGenre,ratesNumber,avgRate,productionYear,nomination,*/ row);
            FormEdit.ShowDialog();
            }
            UpdateFilmsFromDataGridView();
        }
        
    }
}
