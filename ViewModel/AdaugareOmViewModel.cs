using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Modern.ViewModel
{
    public class AdaugareOmViewModel:ViewModelBase
    {
        public MainWindowViewModel _mainwindowviewmodel;
       

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


        public ICommand AdgOm {get;}

        public AdaugareOmViewModel(MainWindowViewModel mainwindowviewmodel)
        {
            _mainwindowviewmodel = mainwindowviewmodel;
            AdgOm = new AdaugareOmCommand(this);
        }

    }
}
