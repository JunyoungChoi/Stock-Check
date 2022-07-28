using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxGIEXPERTCONTROLLib;
namespace JY.StockChecker
{
    public partial class FormStockFunction : Form
    {
        AxGiExpertControl _indi;

        public FormStockFunction(AxGiExpertControl indi)
        {
            InitializeComponent();

            this._indi = indi;
        }

        private void FormStockFunction_Load(object sender, EventArgs e)
        {
            label_Function4.Text = string.Empty;
        }

        private void button_CheckStockPrice_Click(object sender, EventArgs e)
        {
            if (bringToFrontForm(typeof()) == false)
            {
                FormSearchConditionStock form = new FormSearchConditionStock();

                form.Show();
            }
        }

        private void button_SearchStockCondition_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

            if (bringToFrontForm(typeof(FormSearchConditionStock)) == false)
            {
                FormSearchConditionStock form = new FormSearchConditionStock();

                form.Show();
            }
        }

        private bool bringToFrontForm(Type formType)
        {
            bool result = false;

            var openForms = Application.OpenForms;

            foreach (Form form in openForms)
            {
                if (form.GetType() == formType)
                {
                    form.Activate();
                    form.BringToFront();

                    result = true;
                }
            }

            return result;
        }

        private void button_AlarmStockPrice_Click(object sender, EventArgs e)
        {
            if (bringToFrontForm(typeof(FormRTCheck)) == false)
            {
                FormRTCheck form = new FormRTCheck();

                form.Show();
            }
        }
    }
}
