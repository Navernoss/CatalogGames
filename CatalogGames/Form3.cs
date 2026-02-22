using CatalogGames.SteamDataSetTableAdapters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public Form3(Form1 form1)
        {
            InitializeComponent();
            gamesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesDataGridView.MultiSelect = false;
            f1 = form1;
        }

        public void SetUserData(string login, int level)
        {
            label2.Text = login;
            label3.Text = level.ToString();
        }

        private void gamesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gamesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.steamDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'steamDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.steamDataSet.Developer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "steamDataSet.Genres". При необходимости она может быть перемещена или удалена.
            this.genresTableAdapter.Fill(this.steamDataSet.Genres);
            // TODO: This line of code loads data into the 'steamDataSet.Tags' table. You can move, or remove it, as needed.
            this.tagsTableAdapter.Fill(this.steamDataSet.Tags);
            // TODO: This line of code loads data into the 'steamDataSet.Game_Tags' table. You can move, or remove it, as needed.
            this.game_TagsTableAdapter.Fill(this.steamDataSet.Game_Tags);
            // TODO: This line of code loads data into the 'steamDataSet.Games' table. You can move, or remove it, as needed.
            this.gamesTableAdapter.Fill(this.steamDataSet.Games);
            System.Windows.Forms.Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (System.Windows.Forms.Button btn in buttons)
            {
                btn.BackColor = ColorTranslator.FromHtml("#829FE4");
                btn.ForeColor = Color.FromArgb(44, 41, 227);
                btn.Font = new Font("Arial",8f);
            }
            System.Windows.Forms.DataGridView[] datagrid = { genresDataGridView, tagsDataGridView1,developerDataGridView, gamesDataGridView };
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
            System.Windows.Forms.Label[] labels = { labeltags, labelgenre, labelnamedev, foundedLabel, founderLabel, websiteLabel, number_of_employeesLabel };
            foreach (System.Windows.Forms.Label l in labels)
            {
                l.Font = new Font("Arial", 8.25f);
                l.ForeColor = Color.FromArgb(44, 41, 227);
            }
            txtDate.ForeColor = Color.FromArgb(44, 41, 227);
            txtDate.BackColor = Color.White;
            txtDate.ReadOnly = true;

            monthCalendar1.Visible = false;
            monthCalendar1.MaxSelectionCount = 1;
        }

        private void linkLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLinkLabel.Text);
        }

        private void gamesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int index = e.RowIndex;

        }

        private void gamesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (gamesDataGridView.SelectedRows.Count > 0)
            {
                label1.Text = "";
                int game_id = int.Parse(gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
                string tags = "";
                game_TagsBindingSource.Filter = "Game_ID = " + game_id;
                for (int i = 0; i < game_TagsDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < tagsDataGridView.Rows.Count; j++)
                    {
                        if (game_TagsDataGridView.Rows[i].Cells[2].Value.ToString() == tagsDataGridView.Rows[j].Cells[0].Value.ToString())
                        {
                            tags += tagsDataGridView.Rows[j].Cells[1].Value + " ";
                        }
                    }
                }
                label1.Text = tags;
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
            bool error = false;
            if (name_of_genreTextBox.Text != "") {
                for (int i = 0; i < genresDataGridView.Rows.Count - 1; i++) {
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
                if (error == false) {
                    DataRow newRow = steamDataSet.Genres.NewRow();
                    newRow[1] = name_of_genreTextBox.Text;
                    steamDataSet.Genres.Rows.Add(newRow);
                    genresTableAdapter.Update(steamDataSet.Genres);
                    name_of_genreTextBox.Text = "";
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
            if (name_of_genreTextBox.Text != "" && genresDataGridView.CurrentRow.Index != -1) {
                bool error = false;
                int idgenre = int.Parse(genresDataGridView.Rows[genresDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
                for (int i = 0; i < gamesDataGridView.Rows.Count - 1; i++) {
                    int genre = int.Parse(gamesDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn5"].Value.ToString());
                    Console.WriteLine(genre);
                    if (idgenre == int.Parse(gamesDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn5"].Value.ToString())){
                        error = true;
                        MessageBox.Show("Такой жанр имеет связи в таблице 'Игры'. Сначала уберите этот жанр из всех строк в таблице 'Игры' и повторите попытку.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (error == false) {
                    DialogResult dr = MessageBox.Show("Вы точно хотите удалить жанр " + genresDataGridView.Rows[genresDataGridView.CurrentRow.Index].Cells[1].Value.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes) {
                        foreach (DataGridViewRow row in genresDataGridView.SelectedRows) { 
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
            genresTableAdapter.Update(steamDataSet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && tagsDataGridView1.CurrentRow.Index != -1)
            {
                bool error = false;
                int idtag = int.Parse(tagsDataGridView1.Rows[tagsDataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
                for (int i = 0; i < game_TagsDataGridView1.Rows.Count; i++)
                {
                    int tag = int.Parse(game_TagsDataGridView1.Rows[i].Cells[2].Value.ToString());
                    if (idtag == tag)
                    {
                        error = true;
                        MessageBox.Show("Такой тэг имеет связи в таблице 'Игры'. Сначала уберите этот тэг из всех строк в таблице 'Игры' и повторите попытку.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (error == false)
                {
                    DialogResult dr = MessageBox.Show("Вы точно хотите удалить тэг " + tagsDataGridView1.Rows[tagsDataGridView1.CurrentRow.Index].Cells[1].Value.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in tagsDataGridView1.SelectedRows)
                        {
                            tagsDataGridView1.Rows.Remove(row);
                            textBox1.Text = "";
                        }
                        tagsTableAdapter.Update(steamDataSet);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool error = false;
            if (textBox1.Text != "")
            {
                for (int i = 0; i < tagsDataGridView.Rows.Count - 1; i++)
                {
                    string cellValue = tagsDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                    if (cellValue != null)
                    {
                        if (textBox1.Text == tagsDataGridView.Rows[i].Cells[1].Value.ToString())
                        {
                            error = true;
                            MessageBox.Show("Такой жанр уже существует. Запрос на добавление отклонен.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }
                if (error == false)
                {
                    DataRow newRow = steamDataSet.Tags.NewRow();
                    newRow[1] = textBox1.Text;
                    steamDataSet.Tags.Rows.Add(newRow);
                    tagsTableAdapter.Update(steamDataSet);
                    textBox1.Text = "";
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = tagsDataGridView1.CurrentRow.Index;
                tagsDataGridView1.Rows[id].Cells[1].Value = textBox1.Text;
                tagsTableAdapter.Update(steamDataSet);
                tagsDataGridView1.DataSource = tagsBindingSource;
            }
            else
            {
                MessageBox.Show("Произошла ошибка. Повторите попытку", "Ошибка", MessageBoxButtons.OK);
            }
            tagsTableAdapter.Update(steamDataSet);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool error = false;
            if (name_of_developerTextBox.Text != "")
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
                    //DataRow newRow = steamDataSet.Developer.NewRow();
                    //newRow[1] = name_of_developerTextBox.Text;
                    //newRow[2] = foundedDateTimePicker.Text;
                    //newRow[3] = founderTextBox.Text;
                    //newRow[4] = websiteTextBox.Text;
                    //newRow[5] = number_of_employeesTextBox.Text;
                    //steamDataSet.Developer.Rows.Add(newRow);
                    //developerTableAdapter.Update(steamDataSet);
                    //name_of_genreTextBox.Text = "";
                    //name_of_developerTextBox.Text = "";
                    //foundedDateTimePicker.Text = "";
                    //founderTextBox.Text = "";
                    //websiteTextBox.Text = "";
                    //number_of_employeesTextBox.Text = "";
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (name_of_developerTextBox.Text != "" && developerDataGridView.CurrentRow.Index != -1)
            {
                bool error = false;
                int iddev = int.Parse(developerDataGridView.Rows[developerDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
                for (int i = 0; i < gamesDataGridView.Rows.Count - 1; i++)
                {
                    int dev = int.Parse(gamesDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
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
                            //developerDataGridView.Rows.Remove(row);
                            //name_of_developerTextBox.Text = "";
                            //foundedDateTimePicker.Text = "";
                            //founderTextBox.Text = "";
                            //websiteTextBox.Text = "";
                            //number_of_employeesTextBox.Text = "";
                        }
                        developerTableAdapter.Update(steamDataSet);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (name_of_developerTextBox.Text != "" &&
            //foundedDateTimePicker.Text != "" &&
            //founderTextBox.Text != "" &&
            //websiteTextBox.Text != "" &&
            //number_of_employeesTextBox.Text != "")
            //{
            //    int id = developerDataGridView.CurrentRow.Index;
            //    developerDataGridView.Rows[id].Cells[1].Value = name_of_developerTextBox.Text;
            //    developerDataGridView.Rows[id].Cells[2].Value = foundedDateTimePicker.Text;
            //    developerDataGridView.Rows[id].Cells[3].Value = founderTextBox.Text;
            //    developerDataGridView.Rows[id].Cells[4].Value = websiteTextBox.Text;
            //    developerDataGridView.Rows[id].Cells[5].Value = number_of_employeesTextBox.Text;
            //    developerTableAdapter.Update(steamDataSet);
            //    developerDataGridView.DataSource = developerBindingSource;
            //}
            //else
            //{
            //    MessageBox.Show("Произошла ошибка. Повторите попытку", "Ошибка", MessageBoxButtons.OK);
            //}
            //developerTableAdapter.Update(steamDataSet);
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(txtDate.Left, txtDate.Bottom);
            monthCalendar1.Visible = !monthCalendar1.Visible;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDate.Text = e.Start.ToString("dd.MM.yyyy");
            monthCalendar1.Visible = false;
        }
    }
}
