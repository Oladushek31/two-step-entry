using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataProtection
{
    public partial class Entrance : Form
    {
        DataBase dataBase = new DataBase();

        public Entrance()
        {
            InitializeComponent();
        }

        private void Entrance_Load(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
            closePasswordPictureBox.Visible = false;
            loginTextBox.MaxLength = 50;
            passwordTextBox.MaxLength = 50;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var loginUser = loginTextBox.Text;
            var passwordUser = passwordTextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id, login, password from Data where login = '{loginUser}' and password = '{passwordUser}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вход выполнен, введите пин-код", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PinCodeEntrance mp = new PinCodeEntrance();
                this.Hide();
                mp.ShowDialog();
            }
            else MessageBox.Show("Данного аккаунта не существует", "Аккаунт не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void RecoveryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void openPasswordPictureBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;
            closePasswordPictureBox.Visible = true;
            openPasswordPictureBox.Visible = false;
        }

        private void closePasswordPictureBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = false;
            closePasswordPictureBox.Visible = false;
            openPasswordPictureBox.Visible = true;
        }
    }
}
