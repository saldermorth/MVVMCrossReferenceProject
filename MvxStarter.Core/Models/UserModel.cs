using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxStarter.Core.Models
{

    public class UserModel
    {
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _textColor;

        public string TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;

            }
        }

        private bool _isLoggedIn;

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; }
        }


        private string _alias;

        public string MyProperty
        {
            get { return _alias; }
            set { _alias = value; }
        }
    }
}

