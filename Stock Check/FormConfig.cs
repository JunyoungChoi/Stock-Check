using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JY.Stock
{
    public partial class FormConfig : Form
    {
        public FormConfig()
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
    }
}
