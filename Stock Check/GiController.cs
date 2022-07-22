using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxGIEXPERTCONTROLLib;
using GIEXPERTCONTROLLib;

namespace JY.GIController
{
    class GiController
    {
        private bool _isLogin = false;


        private GiExpertControl _giControl;


        public bool IsLogin { get { return _isLogin; } }
        public GiExpertControl Controller { get { return _giControl; } }


        public GiController()
        {
            _giControl = new GiExpertControl();
        }

        public bool LogIn(string id, string password, string authPassword, string path)
        {
            if (_isLogin)
            {
                _giControl.CloseIndi();
            }

            _isLogin = _giControl.StartIndi(id, password, authPassword, path);

            return _isLogin;
        }

        public bool LogOut()
        {
            return this.Close();
        }

        public bool Close()
        {
            return _giControl.CloseIndi();
        }

        public void 
    }
}
