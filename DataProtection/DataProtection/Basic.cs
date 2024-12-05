using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataProtection
{
    public partial class Basic : Form
    {
        System.IO.StreamReader ReadFile;
        public Basic()
        {
            InitializeComponent();
        }


        void importFile()
        {
            var Encoding = System.Text.Encoding.GetEncoding(65001);

            try
            {
                using (var ReadFile = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + @"\info.txt", Encoding))
                {
                    infoTextBox.Text = ReadFile.ReadToEnd();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не был создан");
            }
        }

        private void Basic_Load(object sender, EventArgs e)
        {
            importFile();
        }

        private void infoTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
