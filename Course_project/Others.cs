using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Course_project
{
    public partial class Others : Form
    {
        const string OTHERS_JSON = "Others.json";
        int numbers = 0;
        public Others()
        {
            Task.Run(() => File.Open(OTHERS_JSON, FileMode.OpenOrCreate).Close());
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        async Task<List<T>> ReadFromFile<T>(string FILE_NAME)
        {
            using (var streamReader = new StreamReader(FILE_NAME))
            {
                return await Task.Run(async () => JsonConvert.DeserializeObject<List<T>>(await streamReader.ReadToEndAsync()) ?? new List<T>());
            }
        }

        async Task WriteToFile<T>(List<T> data, string FILE_NAME)
        {
            using (var streamWriter = new StreamWriter(FILE_NAME, false))
            {
                await streamWriter.WriteAsync(await Task.Run(() => JsonConvert.SerializeObject(data)));
            }
        }

        async void Others_Load(object sender, EventArgs e)
        {
            if (File.Exists(OTHERS_JSON))
            {
                var others = await ReadFromFile<InfoOthers>(OTHERS_JSON);

                if (others != null)
                    foreach (var other in others)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[numbers].Cells[0].Value = other.FirstName;
                        dataGridView1.Rows[numbers].Cells[1].Value = other.LastName;
                        dataGridView1.Rows[numbers].Cells[2].Value = other.Date;
                        dataGridView1.Rows[numbers].Cells[3].Value = other.Phone;
                        dataGridView1.Rows[numbers].Cells[4].Value = other.Role;
                        numbers++;
                    }
            }
        }

        async void btn_Add_Click(object sender, EventArgs e)
        {
            Add_Other addOther = new Add_Other();
            addOther.ShowDialog();
            string firstName = Add_Other.firstName;
            string lastName = Add_Other.lastName;
            string date = Add_Other.date;
            string phone = Add_Other.phone;
            string role = Add_Other.role;
            InfoOthers newOther = new InfoOthers(firstName, lastName, date, phone, role);

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(date) &&
                !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(role))
            {
                var others = await ReadFromFile<InfoOthers>(OTHERS_JSON);
                others.Add(newOther);
                await WriteToFile(others, OTHERS_JSON);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[numbers].Cells[0].Value = firstName;
                dataGridView1.Rows[numbers].Cells[1].Value = lastName;
                dataGridView1.Rows[numbers].Cells[2].Value = date;
                dataGridView1.Rows[numbers].Cells[3].Value = phone;
                dataGridView1.Rows[numbers].Cells[4].Value = role;
                numbers++;
            }
        }

        async void btn_Remove_Click(object sender, EventArgs e)
        {
            var Items = dataGridView1.SelectedRows;
            int selectCount = Items.Count;

            if (selectCount > 0)
            {
                var others = await ReadFromFile<InfoOthers>(OTHERS_JSON);

                foreach (var item in Items)
                {
                    var it = (DataGridViewRow)item;
                    string firstName = it.Cells[0].Value.ToString();
                    string lastName = it.Cells[1].Value.ToString();
                    string date = it.Cells[2].Value.ToString();
                    string phone = it.Cells[3].Value.ToString();
                    string role = it.Cells[4].Value.ToString();

                    foreach (var oth in others)
                    {
                        if (firstName == oth.FirstName && lastName == oth.LastName && date == oth.Date &&
                            phone == oth.Phone && role == oth.Role)
                        {
                            others.Remove(oth);
                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                            numbers--;
                            MessageBox.Show($"{oth.FirstName} {oth.LastName}  удалён!", "Удаление гостей и жюри",
                                0, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                await WriteToFile(others, OTHERS_JSON);
            }
            else
            {
                MessageBox.Show("Нет гостей и жюри", "Удаление", 0, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
