using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JY
{
    public partial class FormCheckStock : Form
    {
        private GIEXPERTCONTROLLib.GiExpertControl _gi;
        public FormCheckStock(GIEXPERTCONTROLLib.GiExpertControl gi)
        {
            InitializeComponent();

         
        }
    }
}
