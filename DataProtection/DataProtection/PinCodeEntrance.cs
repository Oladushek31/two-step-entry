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
    public partial class PinCodeEntrance : Form
    {
        DataBase dataBase = new DataBase();
        public PinCodeEntrance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pincodeTextBox.TextLength < 4) pincodeTextBox.Text += ((Button)sender).Text;
        }

        private void Creaturebutton_Click(object sender, EventArgs e)
        {
            if (pincodeTextBox.TextLength == 4)
            {
                int pincodeUser = Convert.ToInt32(pincodeTextBox.Text);

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();

                string queryString = $"select pin_code from Data where pin_code = '{pincodeUser}'";

                SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вход выполнен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Basic basic = new Basic();
                    this.Hide();
                    basic.ShowDialog();
                }
                else MessageBox.Show("Данного аккаунта не существует", "Аккаунт не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ErasingButton_Click(object sender, EventArgs e)
        {

        }
    }
}
