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
    public partial class FormLogIn : Form
    {
        GiController _indi;
        InfoLogIn _infoLogIn;

        public static string ModuleLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public FormLogIn()
        {
            InitializeComponent();

            _indi = new GiController(this.axGiExpertControl);

            loadInfoLogIn();
        }

        private void loadInfoLogIn()
        {
            _infoLogIn = new InfoLogIn();

            string iniPath = Path.Combine(ModuleLocation, "Config", "Config.ini");

            IniStock ini = new IniStock(iniPath);

            _infoLogIn.ID = ini.IniReadValue("LogIn", "ID");

            bool saveID = false;

            if (bool.TryParse(ini.IniReadValue("LogIn", "Save ID"), out saveID))
            {
                _infoLogIn.SaveID = saveID;
            }

            _infoLogIn.IndiPath = ini.IniReadValue("Login", "Indi Path");
        }

        private void saveInfoLogIn()
        {
            string iniPath = Path.Combine(ModuleLocation, "Config", "Config.ini");

            IniStock ini = new IniStock(iniPath);

            ini.IniWriteValue("LogIn", "ID", _infoLogIn.ID);
            ini.IniWriteValue("LogIn", "Save ID", _infoLogIn.SaveID.ToString());
            ini.IniWriteValue("LogIn", "Indi Path", _infoLogIn.IndiPath);
        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {
            if (_infoLogIn.SaveID)
            {
                textBox_ID.Text = _infoLogIn.ID;
                checkBox_SaveId.Checked = _infoLogIn.SaveID;
            }

        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {

            bool logInResult;
            try
            {
                logInResult = _indi.LogIn(textBox_ID.Text, textBox_PW.Text, _infoLogIn.IndiPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return;
            }

            if (logInResult)
            {
                _infoLogIn.ID = textBox_ID.Text;
                _infoLogIn.SaveID = checkBox_SaveId.Checked;

                saveInfoLogIn();
            }
            else
            {
                MessageBox.Show("로그인 실패");
            }
        }
    }
}
