using System;
using System.Configuration;
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
    public partial class Form2 : Form
    {
        private Form f1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            f1 = form1;
        }

        private TextBox textBox1;
        private Label label1;
        private LinkLabel linkLabel1;
        private Label label3;
        private Button buttonlogin;
        private TextBox textBoxpassword;
        private Label password;
        private TextBox textBoxlogin;
        private Label label2;
        private Label regmain;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonlogin = new System.Windows.Forms.Button();
            this.textBoxpassword = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.textBoxlogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.regmain = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.steamDataSet = new CatalogGames.SteamDataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new CatalogGames.SteamDataSetTableAdapters.UsersTableAdapter();
            this.tableAdapterManager = new CatalogGames.SteamDataSetTableAdapters.TableAdapterManager();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.steamDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 238);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(238, 20);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(80, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Повторите пароль";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(227)))));
            this.linkLabel1.Location = new System.Drawing.Point(197, 330);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 15);
            this.linkLabel1.TabIndex = 27;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Войдите сейчас!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(227)))));
            this.label3.Location = new System.Drawing.Point(111, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Есть аккаунт?";
            // 
            // buttonlogin
            // 
            this.buttonlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(127)))), ((int)(((byte)(219)))));
            this.buttonlogin.CausesValidation = false;
            this.buttonlogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(88)))), ((int)(((byte)(219)))));
            this.buttonlogin.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonlogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(227)))));
            this.buttonlogin.Location = new System.Drawing.Point(97, 279);
            this.buttonlogin.Name = "buttonlogin";
            this.buttonlogin.Size = new System.Drawing.Size(214, 48);
            this.buttonlogin.TabIndex = 25;
            this.buttonlogin.Text = "Зарегистрироваться";
            this.buttonlogin.UseVisualStyleBackColor = false;
            this.buttonlogin.Click += new System.EventHandler(this.buttonlogin_Click);
            // 
            // textBoxpassword
            // 
            this.textBoxpassword.Location = new System.Drawing.Point(84, 180);
            this.textBoxpassword.Name = "textBoxpassword";
            this.textBoxpassword.PasswordChar = '*';
            this.textBoxpassword.Size = new System.Drawing.Size(238, 20);
            this.textBoxpassword.TabIndex = 24;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(227)))));
            this.password.Location = new System.Drawing.Point(80, 157);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(57, 20);
            this.password.TabIndex = 23;
            this.password.Text = "Пароль";
            // 
            // textBoxlogin
            // 
            this.textBoxlogin.Location = new System.Drawing.Point(84, 124);
            this.textBoxlogin.Name = "textBoxlogin";
            this.textBoxlogin.Size = new System.Drawing.Size(238, 20);
            this.textBoxlogin.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(227)))));
            this.label2.Location = new System.Drawing.Point(80, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Логин";
            // 
            // regmain
            // 
            this.regmain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regmain.AutoSize = true;
            this.regmain.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regmain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(227)))));
            this.regmain.Location = new System.Drawing.Point(119, 50);
            this.regmain.Name = "regmain";
            this.regmain.Size = new System.Drawing.Size(183, 32);
            this.regmain.TabIndex = 20;
            this.regmain.Text = "Регистрация";
            this.regmain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(219)))));
            this.label4.Location = new System.Drawing.Point(81, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Пароли не совпадают";
            // 
            // steamDataSet
            // 
            this.steamDataSet.DataSetName = "SteamDataSet";
            this.steamDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.steamDataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DeveloperTableAdapter = null;
            this.tableAdapterManager.GamesTableAdapter = null;
            this.tableAdapterManager.GenresTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = CatalogGames.SteamDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = this.usersTableAdapter;
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AutoGenerateColumns = false;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.usersDataGridView.DataSource = this.usersBindingSource;
            this.usersDataGridView.Location = new System.Drawing.Point(294, 360);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.Size = new System.Drawing.Size(300, 220);
            this.usersDataGridView.TabIndex = 31;
            this.usersDataGridView.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "login";
            this.dataGridViewTextBoxColumn2.HeaderText = "login";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "password";
            this.dataGridViewTextBoxColumn3.HeaderText = "password";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "level of access";
            this.dataGridViewTextBoxColumn4.HeaderText = "level of access";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(405, 401);
            this.Controls.Add(this.usersDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonlogin);
            this.Controls.Add(this.textBoxpassword);
            this.Controls.Add(this.password);
            this.Controls.Add(this.textBoxlogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regmain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Каталог компьютерных игр \"Пар\" - Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.steamDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == textBoxpassword.Text) && (textBox1.Text != "" && textBoxpassword.Text != "") && textBoxlogin.Text != "")
            {
                var ds = new SteamDataSet();
                DataRow dr = ds.Users.NewRow();
                dr[1] = textBoxlogin.Text;
                dr[2] = textBoxpassword.Text;
                dr[3] = 0;
                ds.Users.Rows.Add(dr);
                usersTableAdapter.Update(ds);
                MessageBox.Show("Вы успешно зарегистрировались!", "Регистрация", MessageBoxButtons.OK);
                this.Visible = false;
                f1.Visible = true;

            }
            else {
                MessageBox.Show("Произошла ошибка при регистрации. Проверьте введенные данные и попробуйте еще раз", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text == textBoxpassword.Text && textBox1.Text.Length > 0) || (textBox1.Text.Length == 0 || textBoxpassword.Text.Length == 0))
            {
                label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#58A9DB");
            }
            else {
                label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2C29E3");
            }
        }

        private Label label4;
        private SteamDataSet steamDataSet;
        private BindingSource usersBindingSource;
        private IContainer components;
        private SteamDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private SteamDataSetTableAdapters.TableAdapterManager tableAdapterManager;

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.steamDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'steamDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.steamDataSet.Users);

        }

        private DataGridView usersDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            f1.Close();
        }
    }
}
