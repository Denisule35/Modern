using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Modern.Model;

namespace Modern.ViewModel
{
    public class MainWindowViewModel:ViewModelBase

    {
        private readonly ObservableCollection<OameniViewModel> _oameni;
        public ICollectionView Oameni { get; }

        private string _filtrare=string.Empty;

        public string Filtru
        {
            get { return _filtrare; }

            set
            {
                _filtrare = value;
                OnPropertyChanged(nameof(Filtru));
                Oameni.Refresh();
            }


        }

        public MainWindowViewModel()
        {

            _oameni = new ObservableCollection<OameniViewModel>();

            IaOameniDinBD();

            Oameni = CollectionViewSource.GetDefaultView(_oameni);
            Oameni.Filter = FiltrareOameni;
        }

        private bool FiltrareOameni(object obj)
        {
            if(obj is OameniViewModel oamenii)
            {
                return oamenii.nume.Contains(Filtru,StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }
        

        public void IaOameniDinBD()
        {
            using (Bazadateconnect bz = new Bazadateconnect())
            {

                foreach (var om in bz.Oameni)
                {
                    var nou = new OameniViewModel(om.Name, om.Abonament);
                    _oameni.Add(nou);
                    
                }

                

            }
        }
         

    }
}
