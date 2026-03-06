using CatalogGames.SteamDataSetTableAdapters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CatalogGames
{
    public partial class Form3 : Form
    {
        private Form1 f1;
        private Dictionary<string, TabPage> allTabs = new Dictionary<string, TabPage>();
        private Dictionary<string, int> tabIndexes = new Dictionary<string, int>();
        public Form3(Form1 form1)
        {
            InitializeComponent();
            gamesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesDataGridView.MultiSelect = false;
            f1 = form1;
        }
        string user;


        public void SetUserData(string login, int level)
        {
            user = login;
            label2.Text = login;
            if (level == 0)
            {
                label3.Text = "Пользователь";
                label6.Text = "Разрешения:\n" +
                    " - Просматривать таблицы";
                groupBox1.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                usersDataGridView.Visible = false;
                HideTab("tabPage2");
                HideTab("tabPage4");
                button16.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                pictureBox1.Visible = false;
            }
            else
            {
                label3.Text = "Администратор";
                label6.Text = "Разрешения:\n" +
                    " - Просматривать таблицы\n" +
                    " - Добавлять данные в таблицы\n" +
                    " - Редактировать данные в таблицах\n" +
                    " - Удалять данные из таблиц\n";
                groupBox1.Visible = true;
                button16.Visible = true;
                button17.Visible = true;
                button18.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                usersDataGridView.Visible = true;
                pictureBox1.Visible = true;
                ShowTab("tabPage2");
                ShowTab("tabPage4");
            }


        }

        private void HideTab(string tabName)
        {
            if (tabControl1.TabPages.ContainsKey(tabName))
            {
                tabControl1.TabPages.RemoveByKey(tabName);
            }
        }

        private void ShowTab(string tabName)
        {
            if (!tabControl1.TabPages.ContainsKey(tabName))
            {
                TabPage tab = allTabs[tabName];
                int index = tabIndexes[tabName];


                int actualIndex = 0;
                for (int i = 0; i < index; i++)
                {
                    string name = allTabs.ElementAt(i).Key;
                    if (tabControl1.TabPages.ContainsKey(name))
                    {
                        actualIndex++;
                    }
                }

                tabControl1.TabPages.Insert(actualIndex, tab);
            }
        }

        private void gamesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gamesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.steamDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'steamDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.steamDataSet.Users);
            // TODO: This line of code loads data into the 'steamDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.steamDataSet.Developer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "steamDataSet.Genres". При необходимости она может быть перемещена или удалена.
            this.genresTableAdapter.Fill(this.steamDataSet.Genres);
            // TODO: This line of code loads data into the 'steamDataSet.Tags' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'steamDataSet.Game_Tags' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'steamDataSet.Games' table. You can move, or remove it, as needed.
            this.gamesTableAdapter.Fill(this.steamDataSet.Games);
            System.Windows.Forms.Button[] buttons = { button1, button2, button3, button7, button8, button9, button10, button11, button12, button13, btnSelectImage, button19, button14, button15, button16, button17, button18, button19 };
            foreach (System.Windows.Forms.Button btn in buttons)
            {
                btn.BackColor = ColorTranslator.FromHtml("#829FE4");
                btn.ForeColor = Color.FromArgb(44, 41, 227);
                btn.Font = new Font("Arial", 8f);
            }
            System.Windows.Forms.DataGridView[] datagrid = { genresDataGridView, developerDataGridView, gamesDataGridView, usersDataGridView };
            foreach (System.Windows.Forms.DataGridView dgv in datagrid)
            {
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(88, 127, 219);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(44, 41, 227);
                dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#829FE4");
                dgv.DefaultCellStyle.ForeColor = Color.FromArgb(44, 41, 227);
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            System.Windows.Forms.Label[] labels = { labelgenre, labelnamedev, foundedLabel, founderLabel, websiteLabel, number_of_employeesLabel };

            foreach (System.Windows.Forms.Label l in labels)
            {
                l.Font = new Font("Arial", 8.25f);
                l.ForeColor = Color.FromArgb(44, 41, 227);
            }

            txtDate.ForeColor = Color.FromArgb(44, 41, 227);
            txtDate.BackColor = Color.White;
            txtDate.ReadOnly = true;
            comboBox1.Font = new Font("Microsoft Sans Serif", 8.25f);
            comboBox1.ForeColor = Color.FromArgb(44, 41, 227);
            monthCalendar1.Visible = false;
            monthCalendar1.MaxSelectionCount = 1;
            usersDataGridView.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";


            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                TabPage tab = tabControl1.TabPages[i];
                allTabs[tab.Name] = tab;
                tabIndexes[tab.Name] = i;
            }
        }

        private void linkLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void gamesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int index = e.RowIndex;

        }
        private byte[] selectedImageBytes = null;

        private void gamesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (gamesDataGridView.SelectedRows.Count > 0 && button18.Text == "Добавить строку")
            {
                string req = gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells["req"].Value.ToString();
                string[] reqsplit = req.Split(',');
                System.Windows.Forms.TextBox[] textBoxes = { CPU_textbox, RAM_textbox, GPU_textbox };
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    textBoxes[i].Text = reqsplit[i].TrimStart().Split(':')[1];
                }
                genre_comboBox.Items.Clear();
                for (int i = 0; i < genresDataGridView.Rows.Count - 1; i++)
                {
                    genre_comboBox.Items.Add(genresDataGridView.Rows[i].Cells[1].Value);
                    if (genresDataGridView.Rows[i].Cells[1].Value == gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells["genre"].FormattedValue)
                    {
                        genre_comboBox.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < comboBox5.Items.Count; i++)
                {
                    if (comboBox5.Items[i].ToString() == gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells["dataGridViewTextBoxColumn9"].Value.ToString())
                    {
                        comboBox5.SelectedIndex = i;
                    }
                }
                developer_comboBox.Items.Clear();
                for (int i = 0; i < developerDataGridView.Rows.Count; i++)
                {
                    developer_comboBox.Items.Add(developerDataGridView.Rows[i].Cells[1].Value);
                    if (developerDataGridView.Rows[i].Cells[1].Value == gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells["razrab"].FormattedValue)
                    {
                        developer_comboBox.SelectedIndex = i;
                    }
                }
            }
            
            
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {

            f1.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (name_of_genreTextBox.Text != "")
            {
                int id = genresDataGridView.CurrentRow.Index;
                genresDataGridView.Rows[id].Cells[1].Value = name_of_genreTextBox.Text;
                genresTableAdapter.Update(steamDataSet);
                genresDataGridView.DataSource = genresBindingSource;
            }
            else
            {
                MessageBox.Show("Произошла ошибка. Повторите попытку", "Ошибка", MessageBoxButtons.OK);
            }
            genresTableAdapter.Update(steamDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Добавить строку")
            {
                name_of_genreTextBox.Text = "";
                button1.Text = "Сохранить строку";

            }
            else if (button1.Text == "Сохранить строку")
            {

                if (name_of_genreTextBox.Text == "")
                {
                }
                bool error = false;
                if (name_of_genreTextBox.Text != "")
                {
                    for (int i = 0; i < genresDataGridView.Rows.Count - 1; i++)
                    {
                        string cellValue = genresDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                        if (cellValue != null)
                        {
                            if (name_of_genreTextBox.Text == genresDataGridView.Rows[i].Cells[1].Value.ToString())
                            {
                                error = true;
                                MessageBox.Show("Такой жанр уже существует. Запрос на добавление отклонен.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                    if (error == false)
                    {
                        DataRow newRow = steamDataSet.Genres.NewRow();
                        newRow[1] = name_of_genreTextBox.Text;
                        steamDataSet.Genres.Rows.Add(newRow);
                        genresTableAdapter.Update(steamDataSet.Genres);
                        name_of_genreTextBox.Text = "";
                        button1.Text = "Добавить строку";
                        int lastIndex = genresDataGridView.Rows.Count - 1;
                        genresDataGridView.Rows[lastIndex].Selected = true;
                        genresDataGridView.CurrentCell = genresDataGridView.Rows[lastIndex].Cells[0];
                    }
                }
            }
        }

        private void name_of_genreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (name_of_genreTextBox.Text != "" && genresDataGridView.CurrentRow.Index != -1)
            {
                bool error = false;
                int idgenre = int.Parse(genresDataGridView.Rows[genresDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
                for (int i = 0; i < gamesDataGridView.Rows.Count - 1; i++)
                {
                    int genre = int.Parse(gamesDataGridView.Rows[i].Cells["genre"].Value.ToString());
                    Console.WriteLine(genre);
                    if (idgenre == int.Parse(gamesDataGridView.Rows[i].Cells["genre"].Value.ToString()))
                    {
                        error = true;
                        MessageBox.Show("Такой жанр имеет связи в таблице 'Игры'. Сначала уберите этот жанр из всех строк в таблице 'Игры' и повторите попытку.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (error == false)
                {
                    DialogResult dr = MessageBox.Show("Вы точно хотите удалить жанр " + genresDataGridView.Rows[genresDataGridView.CurrentRow.Index].Cells[1].Value.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in genresDataGridView.SelectedRows)
                        {
                            genresDataGridView.Rows.Remove(row);
                            name_of_genreTextBox.Text = "";
                        }
                        genresTableAdapter.Update(steamDataSet);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1) return;

            int studioId = (int)comboBox4.SelectedValue;
            int gameCount = 0;
            double sumRating = 0;
            double minRating = 10.0;
            double maxRating = 0.0;
            string studioName = "";

            if (gamesDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Нет игр в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow game in gamesDataGridView.Rows)
            {
                if (game.IsNewRow) continue;

                if (int.TryParse(game.Cells["razrab"].Value?.ToString(), out int gameStudioId) &&
                    gameStudioId == studioId)
                {
                    if (double.TryParse(game.Cells["dataGridViewTextBoxColumn4"].Value?.ToString(), out double rating))
                    {
                        gameCount++;
                        sumRating += rating;

                        if (rating < minRating) minRating = rating;
                        if (rating > maxRating) maxRating = rating;

                        
                        if (gameCount == 1)
                            studioName = comboBox4.Text;
                    }
                }
            }

            
            if (gameCount == 0)
            {
                MessageBox.Show("У этой студии нет игр в базе данных!",
                    "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            double avgRating = sumRating / gameCount;

            
            string result = $@"📊 СТАТИСТИКА РАЗРАБОТЧИКА

🏢 Студия: {studioName}
🎮 Количество игр: {gameCount}
⭐ Средний рейтинг: {avgRating:F1}
📉 Худшая игра: {minRating:F1}
📈 Лучшая игра: {maxRating:F1}";

            MessageBox.Show(result, $"Анализ: {studioName}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        
}







        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "Добавить строку")
            {
                developerDataGridView.CurrentCell = null;
                name_of_developerTextBox.Text = "";
                txtDate.Text = "";
                founderTextBox.Text = "";
                websiteTextBox.Text = "";
                number_of_employeesTextBox.Text = "";
                picturePictureBox.Image = null;
                button9.Text = "Сохранить строку";

            } else if (button9.Text == "Сохранить строку") { 
                bool error = false;
                if (name_of_developerTextBox.Text != "" && name_of_developerTextBox.Text != "" &&
                txtDate.Text != "" &&
                founderTextBox.Text != "" &&
                websiteTextBox.Text != "" &&
                number_of_employeesTextBox.Text != "")
                {
                    for (int i = 0; i < developerDataGridView.Rows.Count; i++)
                    {
                        string cellValue = developerDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn21"].Value?.ToString() ?? "";
                        if (cellValue != null)
                        {
                            if (name_of_developerTextBox.Text == developerDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn21"].Value.ToString())
                            {
                                error = true;
                                MessageBox.Show("Такой разработчик уже существует. Запрос на добавление отклонен.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                    if (error == false)
                    {
                        DataRow newRow = steamDataSet.Developer.NewRow();
                        newRow[1] = name_of_developerTextBox.Text;
                        newRow[2] = txtDate.Text;
                        newRow[3] = founderTextBox.Text;
                        if (IsValidHttps(websiteTextBox.Text))
                        {
                            newRow[4] = websiteTextBox.Text;
                        }
                        else
                        {
                            MessageBox.Show("Ссылка неккоректна.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        newRow[5] = number_of_employeesTextBox.Text;
                        steamDataSet.Developer.Rows.Add(newRow);
                        developerTableAdapter.Update(steamDataSet);
                        developerDataGridView.ClearSelection();
                        button9.Text = "Добавить строку";
                        int lastIndex = developerDataGridView.Rows.Count - 1;
                        developerDataGridView.Rows[lastIndex].Selected = true;
                        developerDataGridView.CurrentCell = developerDataGridView.Rows[lastIndex].Cells[0];
                       
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            developerTableAdapter.Update(steamDataSet.Developer);
            if (name_of_developerTextBox.Text != "" && developerDataGridView.CurrentRow.Index != -1)
            {
                bool error = false;
                int iddev = int.Parse(developerDataGridView.Rows[developerDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
                for (int i = 0; i < gamesDataGridView.Rows.Count - 1; i++)
                {
                    int dev = int.Parse(gamesDataGridView.Rows[i].Cells["razrab"].Value.ToString());
                    if (iddev == dev)
                    {
                        error = true;
                        MessageBox.Show("Этот разработчик имеет связи в таблице 'Игры'. Сначала уберите этого разработчика из всех строк в таблице 'Игры' и повторите попытку.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (error == false)
                {
                    DialogResult dr = MessageBox.Show("Вы точно хотите удалить разработчика " + developerDataGridView.Rows[developerDataGridView.CurrentRow.Index].Cells[1].Value.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in developerDataGridView.SelectedRows)
                        {
                            developerDataGridView.Rows.Remove(row);
                        }
                        developerTableAdapter.Update(steamDataSet.Developer);
                        developerDataGridView.ClearSelection();
                        int lastIndex = developerDataGridView.Rows.Count - 1;
                        developerDataGridView.Rows[lastIndex].Selected = true;
                        developerDataGridView.CurrentCell = developerDataGridView.Rows[lastIndex].Cells[0];

                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (name_of_developerTextBox.Text != "" &&
            txtDate.Text != "" &&
            founderTextBox.Text != "" &&
            websiteTextBox.Text != "" &&
            number_of_employeesTextBox.Text != "")
            {
                int id = developerDataGridView.CurrentRow.Index;
                developerDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn21"].Value = name_of_developerTextBox.Text;
                var date = DateTime.Parse(txtDate.Text);
                developerDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn22"].Value = date;
                developerDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn23"].Value = founderTextBox.Text;
                developerDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn24"].Value = websiteTextBox.Text;
                developerDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn25"].Value = number_of_employeesTextBox.Text;
                developerBindingSource.EndEdit();
                developerTableAdapter.Update(steamDataSet);
                developerDataGridView.DataSource = developerBindingSource;
            }
            else
            {
                MessageBox.Show("Произошла ошибка. Повторите попытку", "Ошибка", MessageBoxButtons.OK);
            }
            
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(txtDate.Left, txtDate.Bottom);
            monthCalendar1.Visible = !monthCalendar1.Visible;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDate.Text = e.Start.ToString("dd/MM/yyyy");
            monthCalendar1.Visible = false;
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void usersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < usersDataGridView.Rows.Count)
            {
                if (int.Parse(usersDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString()) == 0)
                {
                    usersDataGridView.Rows[e.RowIndex].Cells["lvl"].Value = "Пользователь";
                }
                else
                {
                    usersDataGridView.Rows[e.RowIndex].Cells["lvl"].Value = "Администратор";
                }
            }
        }

        private void usersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (int.Parse(usersDataGridView.Rows[usersDataGridView.CurrentRow.Index].Cells[4].Value.ToString()) == 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bool error = false;
            if (textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                for (int i = 0; i < usersDataGridView.Rows.Count; i++)
                {
                    string cellValue = usersDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                    if (cellValue != null)
                    {
                        if (textBox2.Text == usersDataGridView.Rows[i].Cells[1].Value.ToString())
                        {
                            error = true;
                            MessageBox.Show("Такой пользователь уже существует. Запрос на добавление отклонен.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }
                if (error == false)
                {
                    DataRow newRow = steamDataSet.Users.NewRow();
                    newRow[1] = textBox2.Text;
                    newRow[2] = textBox3.Text;
                    if (comboBox1.Text == "Пользователь")
                    {
                        newRow["level of access"] = 0;
                    }
                    else
                    {
                        newRow["level of access"] = 1;
                    }
                    steamDataSet.Users.Rows.Add(newRow);
                    usersTableAdapter.Update(steamDataSet);
                    usersDataGridView.ClearSelection();
                    int lastIndex = usersDataGridView.Rows.Count - 1;
                    usersDataGridView.Rows[lastIndex].Selected = true;
                    usersDataGridView.CurrentCell = usersDataGridView.Rows[lastIndex].Cells[0];
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                bool error = false;
                for (int i = 0; i < gamesDataGridView.Rows.Count - 1; i++)
                {

                    if (user == textBox2.Text)
                    {
                        error = true;
                        MessageBox.Show("Невозможно удалить пользователя с текущей сессии.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (error == false)
                {
                    DialogResult dr = MessageBox.Show("Вы точно хотите удалить пользователя " + usersDataGridView.Rows[usersDataGridView.CurrentRow.Index].Cells[1].Value.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in usersDataGridView.SelectedRows)
                        {
                            usersDataGridView.Rows.Remove(row);

                        }
                        usersTableAdapter.Update(steamDataSet);
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                int id = usersDataGridView.CurrentRow.Index;
                usersDataGridView.Rows[id].Cells[1].Value = textBox2.Text;
                usersDataGridView.Rows[id].Cells[2].Value = textBox3.Text;
                if (comboBox1.Text == "Пользователь")
                {
                    usersDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn29"].Value = 0;
                }
                else
                {
                    usersDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn29"].Value = 1;
                }
                usersTableAdapter.Update(steamDataSet);
                usersDataGridView.DataSource = usersBindingSource;
            }
            else
            {
                MessageBox.Show("Произошла ошибка. Повторите попытку", "Ошибка", MessageBoxButtons.OK);
            }
            usersTableAdapter.Update(steamDataSet);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            f1.Visible = true;
        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && comboBox2.SelectedIndex != -1)
            {
                comboBox3.MaxLength = 50;
                if (comboBox2.SelectedIndex == 0)
                {
                    label1.Text = "Введите название игры:";
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    label1.Text = "Выберите жанр:";
                    comboBox3.Items.Clear();
                    for (int i = 0; i < genresDataGridView.Rows.Count - 1; i++)
                    {
                        comboBox3.Items.Add(genresDataGridView.Rows[i].Cells[1].Value.ToString());
                    }
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    label1.Text = "Выберите оценку:";
                    comboBox3.MaxLength = 4;

                }
                else if (comboBox2.SelectedIndex == 3)
                {
                    label1.Text = "Выберите разработчика:";
                    comboBox3.Items.Clear();
                    for (int i = 0; i < developerDataGridView.Rows.Count; i++)
                    {
                        comboBox3.Items.Add(developerDataGridView.Rows[i].Cells[1].Value.ToString());
                    }
                }
                else if (comboBox2.SelectedIndex == 4)
                {
                    label1.Text = "Поддерживает ли игра геймпад";
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Да");
                    comboBox3.Items.Add("Нет");
                }
                else if (comboBox2.SelectedIndex == 5)
                {
                    label1.Text = "Выберите рейтинг:";
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("0+");
                    comboBox3.Items.Add("7+");
                    comboBox3.Items.Add("12+");
                    comboBox3.Items.Add("16+");
                    comboBox3.Items.Add("18+");
                }
                else if (comboBox2.SelectedIndex == 6)
                {
                    label1.Text = "Доступна ли игра в РФ";
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Да");
                    comboBox3.Items.Add("Нет");
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && comboBox3.Text != "")
            {

                if (comboBox2.SelectedIndex == 0)
                {
                    gamesBindingSource.Filter = "[Name of game] LIKE '%" + comboBox3.Text + "%'";
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    char[] chars = comboBox3.Text.ToCharArray();
                    if (chars.Length == 4)
                    {
                        if ((chars[0] == '>' || chars[0] == '=' || chars[0] == '<') &&
                            (char.IsDigit(chars[1])) &&
                            (chars[2] == '.') &&
                            (char.IsDigit(chars[3])))
                        {
                            gamesBindingSource.Filter = "Rating " + comboBox3.Text;
                        }
                        else
                        {
                            MessageBox.Show("Неверный формат фильтрации. Примеры верного формата: >9.5, <8.0, =5.8.", "Фильтрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    string genre = comboBox3.Text;
                    for (int i = 0; i < genresDataGridView.Rows.Count - 1; i++)
                    {
                        if (genresDataGridView.Rows[i].Cells[1].Value.ToString() == genre)
                        {
                            gamesBindingSource.Filter = "Genre_ID = " + genresDataGridView.Rows[i].Cells[0].Value;
                            break;
                        }
                    }

                }
                else if (comboBox2.SelectedIndex == 3)
                {
                    string dev = comboBox3.Text;
                    for (int i = 0; i < developerDataGridView.Rows.Count; i++)
                    {
                        if (developerDataGridView.Rows[i].Cells[1].Value.ToString() == dev)
                        {
                            gamesBindingSource.Filter = "Developer = " + developerDataGridView.Rows[i].Cells[0].Value;
                            break;
                        }
                    }
                }
                else if (comboBox2.SelectedIndex == 4)
                {
                    if (comboBox3.Text == "Да" || comboBox3.Text == "Нет")
                    {
                        if (comboBox3.Text == "Да")
                        {
                            gamesBindingSource.Filter = "Gamepad = True";
                        }
                        else
                        {
                            gamesBindingSource.Filter = "Gamepad = False";
                        }
                    }
                }
                else if (comboBox2.SelectedIndex == 5)
                {
                    gamesBindingSource.Filter = "[Age rating] LIKE '%" + comboBox3.Text + "%'";
                }
                else if (comboBox2.SelectedIndex == 6)
                {
                    if (comboBox3.Text == "Да" || comboBox3.Text == "Нет")
                    {
                        if (comboBox3.Text == "Да")
                        {
                            gamesBindingSource.Filter = "[Exist in Russia] = True";
                        }
                        else
                        {
                            gamesBindingSource.Filter = "[Exist in Russia] = False";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Невозможно выполнить фильтрацию", "Фильтрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Вы не выбрали все нужные условия для фильтрации", "Фильтрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            gamesBindingSource.Filter = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!comboBox3.Text.Contains("<") || !comboBox3.Text.Contains(">") || !comboBox3.Text.Contains("="))
            {
                comboBox3.Text = ">";

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start(linkTextBox.Text);

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.Text == "Добавить строку") {
                gamesDataGridView.CurrentCell = null;
                name_of_gameTextBox.Text = "";
                descriptionTextBox.Text = "";
                numericUpDown1.Text = "";
                date_of_publicationTextBox.Text = "";
                CPU_textbox.Text = "";
                RAM_textbox.Text = "";
                GPU_textbox.Text = "";
                comboBox5.Text = "";
                linkTextBox.Text = "";
                picturePictureBox.Image = null;
                button18.Text = "Сохранить строку";
            }
            else if (button18.Text == "Сохранить строку")
            {
                if (name_of_gameTextBox.Text != "" &&
            descriptionTextBox.Text != "" &&
            numericUpDown1.Text != "" &&

            date_of_publicationTextBox.Text != "" &&
            CPU_textbox.Text != "" &&
            RAM_textbox.Text != "" &&
            GPU_textbox.Text != "" &&
            comboBox5.Text != "" &&
            linkTextBox.Text != "")
                {
                    string name = name_of_gameTextBox.Text;
                    for (int i = 0; i < gamesDataGridView.Rows.Count; i++)
                    {
                        if (name == gamesDataGridView.Rows[i].Cells[1].Value.ToString())
                        {
                            MessageBox.Show("Такая игра уже существует.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else
                        {
                            DataRow newRow = steamDataSet.Games.NewRow();
                            newRow["Name of game"] = name_of_gameTextBox.Text;
                            newRow["Description"] = descriptionTextBox.Text;
                            newRow["Rating"] = Single.Parse(numericUpDown1.Text.ToString());
                            string genre = genre_comboBox.Text;
                            for (int j = 0; j < genresDataGridView.Rows.Count - 1; j++)
                            {
                                if (genresDataGridView.Rows[j].Cells[1].Value.ToString() == genre)
                                {
                                    newRow["Genre_ID"] = genresDataGridView.Rows[j].Cells[0].Value;
                                    break;
                                }
                            }
                            string developer = developer_comboBox.Text;
                            for (int j = 0; j < developerDataGridView.Rows.Count; j++)
                            {
                                if (developerDataGridView.Rows[j].Cells[1].Value.ToString() == developer)
                                {
                                    newRow["Developer"] = developerDataGridView.Rows[j].Cells[0].Value;
                                    break;
                                }
                            }
                            if (int.Parse(date_of_publicationTextBox.Text) > 1950 && int.Parse(date_of_publicationTextBox.Text) <= int.Parse(DateTime.Now.ToString("yyyy")))
                            {
                                newRow["Date of publication"] = date_of_publicationTextBox.Text;
                            }
                            else
                            {
                                MessageBox.Show("Введенный год выходит за пределы разрешенных значений. Год выпуска должен быть старше 1950 и младше либо равен " + DateTime.Now.ToString("yyyy"), "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            newRow["Gamepad"] = gamepadCheckBox.Checked;
                            newRow["Minimum system requirements"] = "CPU: " + CPU_textbox.Text + ", RAM: " + RAM_textbox.Text + ", GPU: " + GPU_textbox.Text;
                            newRow["Age rating"] = comboBox5.Text;
                            newRow["Exist in Russia"] = exist_in_RussiaCheckBox.Checked;
                            if (IsValidHttps(linkTextBox.Text))
                            {
                                newRow["Link"] = linkTextBox.Text;
                            }
                            else
                            {
                                MessageBox.Show("Ссылка неккоректна.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            newRow["Picture"] = selectedImageBytes;
                            steamDataSet.Games.Rows.Add(newRow);
                            gamesBindingSource.EndEdit();
                            gamesTableAdapter.Update(steamDataSet);
                            gamesDataGridView.ClearSelection();
                            button18.Text = "Добавить строку";                         
                            gamesDataGridView.DataSource = false;
                            gamesDataGridView.DataSource = gamesBindingSource;
                            int lastIndex = gamesDataGridView.Rows.Count - 1;
                            gamesDataGridView.Rows[lastIndex].Selected = true;
                            gamesDataGridView.CurrentCell = gamesDataGridView.Rows[lastIndex].Cells[1];
                            break;
                        }
                    }
                }
            }
        }

        private void genre_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void developer_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public bool IsValidHttps(string url)
        {

            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttps;
        }



        private void button20_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImageBytes = File.ReadAllBytes(ofd.FileName);
                    using (MemoryStream ms = new MemoryStream(selectedImageBytes))
                    {
                        picturePictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (name_of_gameTextBox.Text != "" &&
        descriptionTextBox.Text != "" &&
        numericUpDown1.Text != "" &&
        date_of_publicationTextBox.Text != "" &&
        CPU_textbox.Text != "" &&
        RAM_textbox.Text != "" &&
        GPU_textbox.Text != "" &&
        comboBox5.Text != "" &&
        linkTextBox.Text != "")
            {
                DialogResult dr = MessageBox.Show("Вы точно хотите удалить игру " + gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells[1].Value.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in gamesDataGridView.SelectedRows)
                    {
                        gamesDataGridView.Rows.Remove(row);

                    }
                    gamesBindingSource.EndEdit();
                    gamesTableAdapter.Update(steamDataSet);
                }
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            if (name_of_gameTextBox.Text != "" &&
        descriptionTextBox.Text != "" &&
        numericUpDown1.Text != "" &&
        date_of_publicationTextBox.Text != "" &&
        CPU_textbox.Text != "" &&
        RAM_textbox.Text != "" &&
        GPU_textbox.Text != "" &&
        comboBox5.Text != "" &&
        linkTextBox.Text != "")
            {
                int id = gamesDataGridView.CurrentRow.Index;
                gamesDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn2"].Value = name_of_gameTextBox.Text;
                gamesDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn3"].Value = descriptionTextBox.Text;
                gamesDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn4"].Value = numericUpDown1.Text;
                string genre = genre_comboBox.Text;
                for (int j = 0; j < genresDataGridView.Rows.Count - 1; j++)
                {
                    if (genresDataGridView.Rows[j].Cells[1].Value.ToString() == genre)
                    {
                        gamesDataGridView.Rows[id].Cells["genre"].Value = genresDataGridView.Rows[j].Cells[0].Value;
                        break;
                    }
                }
                string developer = developer_comboBox.Text;
                for (int j = 0; j < developerDataGridView.Rows.Count; j++)
                {
                    if (developerDataGridView.Rows[j].Cells[1].Value.ToString() == developer)
                    {
                        gamesDataGridView.Rows[id].Cells["razrab"].Value = developerDataGridView.Rows[j].Cells[0].Value;
                        break;
                    }
                }
                gamesDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn7"].Value = date_of_publicationTextBox.Text;
                gamesDataGridView.Rows[id].Cells["dataGridViewCheckBoxColumn1"].Value = gamepadCheckBox.Checked;
                gamesDataGridView.Rows[id].Cells["req"].Value = "CPU: " + CPU_textbox.Text + ", RAM: " + RAM_textbox.Text + ", GPU: " + GPU_textbox.Text; ;
                gamesDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn9"].Value = comboBox5.Text;
                if (IsValidHttps(linkTextBox.Text))
                {
                    gamesDataGridView.Rows[id].Cells["dataGridViewTextBoxColumn10"].Value = linkTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Ссылка неккоректна." + DateTime.Now.ToString("yyyy"), "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                gamesDataGridView.Rows[id].Cells["dataGridViewCheckBoxColumn2"].Value = exist_in_RussiaCheckBox.Checked;
                gamesDataGridView.Rows[id].Cells["dataGridViewImageColumn1"].Value = selectedImageBytes;
                gamesTableAdapter.Update(steamDataSet);

            }
            else
            {
                MessageBox.Show("Произошла ошибка. Повторите попытку", "Ошибка", MessageBoxButtons.OK);
            }
            gamesBindingSource.EndEdit();
           // gamesTableAdapter.Update(steamDataSet);
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            gamesTableAdapter.Update(steamDataSet.Games);
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
            
}

