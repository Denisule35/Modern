using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Modern.Model;

namespace Modern.ViewModel
{
    class RenoireAbonamentCommand : Commandbase
    {

        OameniViewModel _omviewmodel;

        public RenoireAbonamentCommand(OameniViewModel oameniviewmodel)
        {
            _omviewmodel = oameniviewmodel;
        }
        public override void Execute(object parameter)
        {


            _omviewmodel.data = DateOnly.FromDateTime(DateTime.Now);
            _omviewmodel.expirat = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D8A25E"));


            using (Bazadateconnect bz = new Bazadateconnect())
            {
                Oameni om = bz.Oameni.FirstOrDefault(o => o.Name == _omviewmodel.nume);

                if (om != null)
                {
                    om.Abonament = DateOnly.FromDateTime(DateTime.Now);
                }
                bz.SaveChanges();
            }

        }
    }
}
