using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Modern.ViewModel
{
    public class AdaugareAdminVIewModel:ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }


        }

        private string _password;

        public string Password
        {
            get { return _password; }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }


        }




        public ICommand AdgAdmin { get; }

        public AdaugareAdminVIewModel()
        {
            AdgAdmin = new AdaugareAdminCommand(this);
        }
    }
}
