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
    public partial class Registration : Form
    {
        DataBase database = new DataBase();
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
            closePasswordPictureBox.Visible = false;
            loginTextBox.MaxLength = 50;
            passwordTextBox.MaxLength = 50;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var loginUs = loginTextBox.Text;
            var passwordUs = passwordTextBox.Text;

            string queryStr = $"insert into Data(login, password) values('{loginUs}', ('{passwordUs}'))";

            SqlCommand command = new SqlCommand(queryStr, database.getConnection());

            database.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаут создан, придумайте пинкод", "Аккаунт создан");
                PinCodeRegistration mp = new PinCodeRegistration();
                this.Hide();
                mp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан");
            }
            database.closeConnection();
        }

        private Boolean checkUser()
        {
            var loginuser = loginTextBox.Text;
            var passworduser = passwordTextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string querystring = $"select id, login, password from UserData where login = '{loginuser}' and password = '{passworduser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                return true;
            }
            else
            {
                return false;
            }
;
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

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
