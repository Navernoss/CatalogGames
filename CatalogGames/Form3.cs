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
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                usersDataGridView.Visible = false;
            }
            else {
                label3.Text = "Администратор";
                label6.Text = "Разрешения:\n" +
                    " - Просматривать таблицы\n" +
                    " - Добавлять данные в таблицы\n" +
                    " - Редактировать данные в таблицах\n" +
                    " - Удалять данные из таблиц\n";
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                usersDataGridView.Visible = true;
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
            this.tagsTableAdapter.Fill(this.steamDataSet.Tags);
            // TODO: This line of code loads data into the 'steamDataSet.Game_Tags' table. You can move, or remove it, as needed.
            this.game_TagsTableAdapter.Fill(this.steamDataSet.Game_Tags);
            // TODO: This line of code loads data into the 'steamDataSet.Games' table. You can move, or remove it, as needed.
            this.gamesTableAdapter.Fill(this.steamDataSet.Games);
            System.Windows.Forms.Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10,button11,button12, button13, button14 };
            foreach (System.Windows.Forms.Button btn in buttons)
            {
                btn.BackColor = ColorTranslator.FromHtml("#829FE4");
                btn.ForeColor = Color.FromArgb(44, 41, 227);
                btn.Font = new Font("Arial",8f);
            }
            System.Windows.Forms.DataGridView[] datagrid = { genresDataGridView, tagsDataGridView1,developerDataGridView, gamesDataGridView, usersDataGridView };
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
<<<<<<< HEAD
            System.Windows.Forms.Label[] labels = { labeltags, labelgenre, labelnamedev, foundedLabel, founderLabel, websiteLabel, number_of_employeesLabel,  };
=======
            System.Windows.Forms.Label[] labels = { labeltags, labelgenre, labelnamedev, foundedLabel, founderLabel, websiteLabel, number_of_employeesLabel };
>>>>>>> f7177e4d050590a182f15c1c76c719820d9790da

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
        }

        private void linkLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void gamesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //int index = e.RowIndex;
            //if (index < gamesDataGridView.Rows.Count - 1)
            //{
            //    int genre = int.Parse(gamesDataGridView.Rows[index].Cells["dataGridViewTextBoxColumn5"].Value.ToString());
            //    for (int i = 0; i < genresDataGridView.Rows.Count - 1; i++)
            //    {
            //        if (genre == int.Parse(genresDataGridView.Rows[i].Cells[0].Value.ToString()))
            //        {
            //            gamesDataGridView.Rows[index].Cells["genre"].Value = genresDataGridView.Rows[i].Cells[1].Value.ToString();
            //        }
            //    }
            //}
        }

        private void gamesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            developerTextBox.Text = gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells["razrab"].FormattedValue.ToString();
            genre_IDTextBox.Text = gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells["genre"].FormattedValue.ToString();
<<<<<<< HEAD
            string req = gamesDataGridView.Rows[gamesDataGridView.CurrentRow.Index].Cells["req"].Value.ToString();
            string[] reqsplit = req.Split(',');
            System.Windows.Forms.TextBox[] textBoxes = { CPU, RAM, GPU };
            for (int i = 0; i < textBoxes.Length; i++) {
                textBoxes[i].Text = reqsplit[i].TrimStart().Split(':')[1];
            }

=======
>>>>>>> f7177e4d050590a182f15c1c76c719820d9790da
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
                    if (idgenre == genre){
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
                for (int i = 0; i < usersDataGridView.Rows.Count; i++)
                {
                    string cellValue = usersDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn21"].Value?.ToString() ?? "";
                    if (cellValue != null)
                    {
                        if (name_of_developerTextBox.Text == usersDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn21"].Value.ToString())
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
                    newRow[4] = websiteTextBox.Text;
                    newRow[5] = number_of_employeesTextBox.Text;
                    steamDataSet.Developer.Rows.Add(newRow);
                    developerTableAdapter.Update(steamDataSet);
                    usersDataGridView.ClearSelection();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            developerTableAdapter.Update(steamDataSet.Developer);
            if (name_of_developerTextBox.Text != "" && usersDataGridView.CurrentRow.Index != -1)
            {
                bool error = false;
                int iddev = int.Parse(usersDataGridView.Rows[usersDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
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
                    DialogResult dr = MessageBox.Show("Вы точно хотите удалить разработчика " + usersDataGridView.Rows[usersDataGridView.CurrentRow.Index].Cells[1].Value.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in usersDataGridView.SelectedRows)
                        {
                            usersDataGridView.Rows.Remove(row);
                        }
                        developerTableAdapter.Update(steamDataSet.Developer);
                        usersDataGridView.ClearSelection();
                        int lastIndex = usersDataGridView.Rows.Count - 1;
                        usersDataGridView.Rows[lastIndex].Selected = true;
                        usersDataGridView.CurrentCell = usersDataGridView.Rows[lastIndex].Cells[0];

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
                int id = usersDataGridView.CurrentRow.Index;
                usersDataGridView.Rows[id].Cells[1].Value = name_of_developerTextBox.Text;
                var date = DateTime.Parse(txtDate.Text);
                usersDataGridView.Rows[id].Cells[2].Value = date;
                usersDataGridView.Rows[id].Cells[3].Value = founderTextBox.Text;
                usersDataGridView.Rows[id].Cells[4].Value = websiteTextBox.Text;
                usersDataGridView.Rows[id].Cells[5].Value = number_of_employeesTextBox.Text;
                developerTableAdapter.Update(steamDataSet);
                usersDataGridView.DataSource = developerBindingSource;
            }
            else
            {
                MessageBox.Show("Произошла ошибка. Повторите попытку", "Ошибка", MessageBoxButtons.OK);
            }
            developerTableAdapter.Update(steamDataSet);
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
                    usersDataGridView.Rows[e.RowIndex].Cells[3].Value = "Администратор";
                }
            }
        }

        private void usersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (int.Parse(usersDataGridView.Rows[usersDataGridView.CurrentRow.Index].Cells[4].Value.ToString()) == 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else { 
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
                    if (comboBox1.Text == "Пользователь") {
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
                usersDataGridView.Rows[id].Cells[1].Value = textBox1.Text;
                usersDataGridView.Rows[id].Cells[2].Value = textBox1.Text;
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

        private void button14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(linkLinkLabel.Text);
        }

        private void date_of_publicationLabel_Click(object sender, EventArgs e)
        {

        }

        private void date_of_publicationTextBox_TextChanged(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void minimum_system_requirementsLabel_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && comboBox2.SelectedIndex != -1)
            {
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
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("0");
                    comboBox3.Items.Add("1");
                    comboBox3.Items.Add("< 1");
                    comboBox3.Items.Add("> 1");
                    comboBox3.Items.Add("2");
                    comboBox3.Items.Add("< 2");
                    comboBox3.Items.Add("> 2");
                    comboBox3.Items.Add("3");
                    comboBox3.Items.Add("< 3");
                    comboBox3.Items.Add("> 3");
                    comboBox3.Items.Add("4");
                    comboBox3.Items.Add("< 4");
                    comboBox3.Items.Add("> 4");
                    comboBox3.Items.Add("5");
                    comboBox3.Items.Add("< 5");
                    comboBox3.Items.Add("> 5");
                    comboBox3.Items.Add("6");
                    comboBox3.Items.Add("< 6");
                    comboBox3.Items.Add("> 6");
                    comboBox3.Items.Add("7");
                    comboBox3.Items.Add("< 7");
                    comboBox3.Items.Add("> 7");
                    comboBox3.Items.Add("8");
                    comboBox3.Items.Add("< 8");
                    comboBox3.Items.Add("> 8");
                    comboBox3.Items.Add("9");
                    comboBox3.Items.Add("< 9");
                    comboBox3.Items.Add("> 9");
                    comboBox3.Items.Add("10");
                    comboBox3.Items.Add("< 10");
                }
                else if (comboBox2.SelectedIndex == 3)
                {
                    label1.Text = "Выберите разработчика:";
                    comboBox3.Items.Clear();
                    for (int i = 0; i < developerDataGridView.Rows.Count - 1; i++)
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
                else if (comboBox2.SelectedIndex == 6) {
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
                if (comboBox1.SelectedIndex == 0) { 
                    
                }
            }
            else {
                MessageBox.Show("Вы не выбрали все нужные условия для фильтрации", "Фильтрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
=======
>>>>>>> f7177e4d050590a182f15c1c76c719820d9790da
    }
}
