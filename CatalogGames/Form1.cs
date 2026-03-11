using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogGames
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        private Form3 form3;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(this) { Visible = false };
            form3 = new Form3(this) { Visible = false };
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.steamDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'steamDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.steamDataSet.Users);
            
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            if (textBoxlogin.Text != "" && textBoxpassword.Text != "")
            {
                bool exist = false;
                for (int i = 0; i < usersDataGridView.Rows.Count; i++) {
                    //Console.WriteLine(usersDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString() + " " + usersDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn3"].Value.ToString());
                    if (textBoxlogin.Text == usersDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString() && textBoxpassword.Text == usersDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn3"].Value.ToString())
                    {
                        
                            form3.Visible = true;
                            form3.SetUserData(usersDataGridView.Rows[i].Cells[1].Value.ToString(), int.Parse(usersDataGridView.Rows[i].Cells[3].Value.ToString()));
                            this.Visible = false;
                            exist = true;
                            break;
                        
                    }
                }
                if (exist == false) {
                    MessageBox.Show("Такого пользователя не существует. Попробуйте еще раз", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Вы не ввели необходимые данные","Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form2.Show();
            this.Visible = false;
        }
    }
}
