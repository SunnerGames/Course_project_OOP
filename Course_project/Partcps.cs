using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Course_project
{
    public partial class Partcps : Form
    {
        const string FILMS_JSON = "Films.json";
        const string PARTCP_JSON = "Partcp.json";
        int numbers = 0;

        public Partcps()
        {
            Task.Run(() => File.Open(PARTCP_JSON, FileMode.OpenOrCreate).Close());
            Task.Run(() => File.Open(FILMS_JSON, FileMode.OpenOrCreate).Close());

            InitializeComponent();
        }

        async void Partcps_Load(object sender, EventArgs e)
        {
            if (File.Exists(PARTCP_JSON))
            {
                var participants = await ReadFromFile<InfoPartcps>(PARTCP_JSON);

                if (participants != null)
                    foreach (var participant in participants)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[numbers].Cells[0].Value = participant.FirstName;
                        dataGridView1.Rows[numbers].Cells[1].Value = participant.LastName;
                        dataGridView1.Rows[numbers].Cells[2].Value = participant.Date;
                        dataGridView1.Rows[numbers].Cells[3].Value = participant.Phone;
                        dataGridView1.Rows[numbers].Cells[4].Value = participant.FilmID;
                        numbers++;
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

        async void btn_Add_Click(object sender, EventArgs e)
        {
            Add_Partcp addPartcp = new Add_Partcp();
            addPartcp.ShowDialog();

            string firstName = Add_Partcp.firstName;
            string lastName = Add_Partcp.lastName;
            string date = Add_Partcp.date;
            string phone = Add_Partcp.phone;
            int filmID = Add_Partcp.filmID;

            InfoPartcps newPartcp = new InfoPartcps(firstName, lastName, date, phone, filmID);

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(date) &&
                !string.IsNullOrEmpty(phone) && (filmID > 0))
            {
                var partcps = await ReadFromFile<InfoPartcps>(PARTCP_JSON);
                var films = await ReadFromFile<InfoFilms>(FILMS_JSON);

                bool check = false;
                foreach (var film in films)
                    if (film.FilmID == filmID)
                        check = true;
                if (!check)
                {
                    MessageBox.Show($"Фильм с ID {filmID} не существует."
                            , "Добавление участника", 0, MessageBoxIcon.Information);
                    return;
                }

                partcps.Add(newPartcp);

                await WriteToFile(partcps, PARTCP_JSON);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[numbers].Cells[0].Value = firstName;
                dataGridView1.Rows[numbers].Cells[1].Value = lastName;
                dataGridView1.Rows[numbers].Cells[2].Value = date;
                dataGridView1.Rows[numbers].Cells[3].Value = phone;
                dataGridView1.Rows[numbers].Cells[4].Value = filmID;
                numbers++;
            }
        }

        async void btn_Remove_Click(object sender, EventArgs e)
        {
            var Items = dataGridView1.SelectedRows;
            int selectCount = Items.Count;

            if (selectCount > 0)
            {
                var partcps = await ReadFromFile<InfoPartcps>(PARTCP_JSON);

                foreach (var item in Items)
                {
                    var it = (DataGridViewRow)item;
                    string firstName = it.Cells[0].Value.ToString();
                    string lastName = it.Cells[1].Value.ToString();
                    string date = it.Cells[2].Value.ToString();
                    string phone = it.Cells[3].Value.ToString();
                    int filmID = Convert.ToInt32(it.Cells[4].Value.ToString());

                    foreach (var pt in partcps)
                    {
                        if (firstName == pt.FirstName && lastName == pt.LastName && date == pt.Date &&
                            phone == pt.Phone && filmID == pt.FilmID)
                        {
                            partcps.Remove(pt);
                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                            numbers--;
                            MessageBox.Show($"Участник  {pt.FirstName} {pt.LastName}  удалён!", "Удаление участника",
                                0, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                await WriteToFile(partcps, PARTCP_JSON);
            }
            else
            {
                MessageBox.Show("Нет участников", "Удаление", 0, MessageBoxIcon.Information);
                return;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
