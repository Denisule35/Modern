using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Modern.Model;

namespace Modern.ViewModel
{
    public class MainWindowViewModel:ViewModelBase

    {
        public  ObservableCollection<OameniViewModel> _oameni;
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

        private Brush _gri= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#343131"));
        public Brush Gri
        {
            get => _gri;
            set
            {
                _gri = value;
                OnPropertyChanged(nameof(Gri));
            }
        }


        private Brush _galben= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D8A25E"));
        public Brush Galben
        {
            get => _galben;
            set
            {
                _galben = value;
                OnPropertyChanged(nameof(Galben));
            }
        }

        private Brush _negru = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#242222"));
        public Brush Negru
        {
            get => _negru;
            set
            {
                _negru = value;
                OnPropertyChanged(nameof(Negru));
            }
        }

        private Brush _rosu = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A04747"));
        public Brush Rosu
        {
            get => _rosu;
            set
            {
                _rosu = value;
                OnPropertyChanged(nameof(Rosu));
            }
        }


        public ICommand DeschidereAdgOm {  get; }
        public ICommand SchimbareTema {  get; }

        public ICommand DeschidereAdgAdmin { get; }
        public ICommand DeschidereStergereAdmin { get; }




        public bool elight = false;

        public MainWindowViewModel()
        {

            _oameni = new ObservableCollection<OameniViewModel>();

            IaOameniDinBD();

            Oameni = CollectionViewSource.GetDefaultView(_oameni);
            Oameni.Filter = FiltrareOameni;
            DeschidereAdgOm=new DeschidereAdaugareOmCommand(this);
            SchimbareTema = new SchimbareTemaCommand(this);
            DeschidereAdgAdmin= new DeschidereAdaugareAdminCommand(this);
            DeschidereStergereAdmin = new DeschidereStergereAdminCommand(this);
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
                    var nou = new OameniViewModel(om.Name, om.Abonament,this);
                    _oameni.Add(nou);
                    
                }

                

            }
        }
         

    }
}
