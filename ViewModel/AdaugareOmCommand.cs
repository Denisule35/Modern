using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Modern.Model;

namespace Modern.ViewModel
{
    public class AdaugareOmCommand : Commandbase
    {

        AdaugareOmViewModel _adaugareomviewmodel;

        public AdaugareOmCommand(AdaugareOmViewModel adaugareOmViewModel)
        {
            _adaugareomviewmodel = adaugareOmViewModel;
        }

        public override void Execute(object parameter)
        {
            if(parameter is Window wind)
            {

                 OameniViewModel om = new OameniViewModel(_adaugareomviewmodel.Username,DateOnly.FromDateTime(DateTime.Now),_adaugareomviewmodel._mainwindowviewmodel);
                Oameni bzom = new Oameni()
                {

                    Name = om.nume,
                    Abonament = om.data,
                };
                using (Bazadateconnect bazadedate = new Bazadateconnect())
                {
                    bazadedate.Oameni.Add(bzom);
                    bazadedate.SaveChanges();
                }

                _adaugareomviewmodel._mainwindowviewmodel._oameni.Add(om);

                wind.Close();

            }
        }
    }
}
