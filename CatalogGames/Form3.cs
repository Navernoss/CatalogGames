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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "steamDataSet.Genres". При необходимости она может быть перемещена или удалена.
            this.genresTableAdapter.Fill(this.steamDataSet.Genres);
            // TODO: This line of code loads data into the 'steamDataSet.Tags' table. You can move, or remove it, as needed.
            this.tagsTableAdapter.Fill(this.steamDataSet.Tags);
            // TODO: This line of code loads data into the 'steamDataSet.Game_Tags' table. You can move, or remove it, as needed.
            this.game_TagsTableAdapter.Fill(this.steamDataSet.Game_Tags);
            // TODO: This line of code loads data into the 'steamDataSet.Games' table. You can move, or remove it, as needed.
            this.gamesTableAdapter.Fill(this.steamDataSet.Games);
            genresDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(88, 127, 219);
            genresDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(44, 41, 227);
            genresDataGridView.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#829FE4");
            genresDataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(44, 41, 227);
            genresDataGridView.EnableHeadersVisualStyles = false;
            genresDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
            genresDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            genresDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            genresDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            tagsDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(88, 127, 219);
            tagsDataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(44, 41, 227);
            tagsDataGridView1.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#829FE4");
            tagsDataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(44, 41, 227);
            tagsDataGridView1.EnableHeadersVisualStyles = false;
            tagsDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
            tagsDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tagsDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tagsDataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void linkLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLinkLabel.Text);
        }

        private void gamesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int index = e.RowIndex;

        }

        private void gamesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //label1.Text = "";
            //int game_id = int.Parse(gamesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            //string tags = "";
            //game_TagsBindingSource.Filter = "Game_ID = " + game_id;
            //for (int i = 0; i < game_TagsDataGridView.Rows.Count; i++) {
            //    for (int j = 0; j < tagsDataGridView.Rows.Count; j++) {
            //        if (game_TagsDataGridView.Rows[i].Cells[2].Value.ToString() == tagsDataGridView.Rows[j].Cells[0].Value.ToString()) {
            //            tags += tagsDataGridView.Rows[j].Cells[1].Value + " ";
            //        }
            //    }
            //}
            //label1.Text = tags;
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

        private void descriptionLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void gamesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
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

        private void name_of_genreLabel_Click(object sender, EventArgs e)
        {

        }

        private void name_of_genreTextBox_TextChanged(object sender, EventArgs e)
        {

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
    }
}
