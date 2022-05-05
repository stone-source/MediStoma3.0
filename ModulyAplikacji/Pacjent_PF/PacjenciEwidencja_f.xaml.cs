using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediStoma3._0.ModulyAplikacji.Pacjent_PF;

namespace MediStoma3._0.ModulyAplikacji.Pacjent_PF
{
    /// <summary>
    /// Logika interakcji dla klasy PacjenciEwidencja_f.xaml
    /// </summary>
    public partial class PacjenciEwidencja_f : Page
    {
        private MEDISTOMAEntities _MSEntities = new MEDISTOMAEntities();
        private pacjent _aktualnyPacjent = new pacjent();

        public PacjenciEwidencja_f()
        {
            InitializeComponent();
            ZaladujDane();
        }

        private void ZaladujDane()
        {
            var pacjenci = from p in _MSEntities.pacjent select p;
            grdPacjenci.ItemsSource = pacjenci.ToList();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            _aktualnyPacjent = (pacjent)grdPacjenci.SelectedItem;
            Pacjent_f form = new Pacjent_f();
            form._idEdytowanegoPacjenta = _aktualnyPacjent.id_pac;
            
        }
    }
}
