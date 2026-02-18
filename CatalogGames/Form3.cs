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

        }

        private void name_of_genreLabel_Click(object sender, EventArgs e)
        {

        }

        private void name_of_genreTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
