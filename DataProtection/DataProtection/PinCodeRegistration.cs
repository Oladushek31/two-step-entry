using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataProtection
{
    public partial class PinCodeRegistration : Form
    {
        DataBase database = new DataBase();
        public PinCodeRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pincodeTextBox.TextLength < 4) pincodeTextBox.Text += ((Button)sender).Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Creaturebutton_Click(object sender, EventArgs e)
        {
            if (pincodeTextBox.TextLength == 4)
            {
                int pincodeUs = Convert.ToInt32(pincodeTextBox.Text);


                string queryStr = $"insert into Data(pin_code) values('{pincodeUs}')";

                SqlCommand command = new SqlCommand(queryStr, database.getConnection());

                database.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаут успешно создан", "Аккаунт создан");
                    Basic basic = new Basic();
                    this.Hide();
                    basic.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Аккаунт не создан");
                }
                database.closeConnection();
            } else MessageBox.Show("Пин-код имеет менее 4 символов", "Ошибка при создание пин-кода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void ErasingButton_Click(object sender, EventArgs e)
        {
            if (pincodeTextBox.Text.Length > 0)
            {
                pincodeTextBox.Text = pincodeTextBox.Text.Remove(pincodeTextBox.Text.Length - 1);
            }
        }
    }
}
