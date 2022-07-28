using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using AxGIEXPERTCONTROLLib;

namespace JY.StockChecker.Example
{
    public partial class FormExample : Form
    {
        GiController _indi;

        public FormExample()
        {
            InitializeComponent();

        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.DefaultExt = "exe";

            if (Directory.Exists(@"C:\SHINHAN - i\indi"))
            {
                ofd.InitialDirectory = @"C:\SHINHAN-i\indi";
                ofd.FileName = @"giexpertstarter.exe";
            }
            else if (Directory.Exists(@"C:\Program Files\SHINHAN - i\indi"))
            {
                ofd.InitialDirectory = @"C:\Program Files\SHINHAN-i\indi";
                ofd.FileName = @"giexpertstarter.exe";
            }
            else if (Directory.Exists(@""))
            {
                ofd.InitialDirectory = @"C:\Program Files (x86)\SHINHAN-i\indi";
                ofd.FileName = @"giexpertstarter.exe";
            }

            if (ofd.ShowDialog() == DialogResult.Yes)
            {
                textBox_IndiPath.Text = ofd.FileName;
            }
        }

        private void FormExample_Load(object sender, EventArgs e)
        {
            _indi = new GiController(this.axGiExpertControl);
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            try
            {
                _indi.LogIn(textBox_ID.Text, textBox_PW.Text, textBox_IndiPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return;
            }

            if (_indi.IsLogin)
            {
                MessageBox.Show("로그인 성공");
            }

            else
            {
                MessageBox.Show("로그인 실패");
            }

        }
    }
}
