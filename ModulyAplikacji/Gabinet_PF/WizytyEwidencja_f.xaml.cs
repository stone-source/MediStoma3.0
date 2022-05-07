using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MediStoma3._0.ModulyAplikacji.Gabinet_PF
{
    public partial class WizytyEwidencja_f : Page
    {
        private MEDISTOMAEntities _MSEntities;
        private v_wizyta _aktualnaWizyta = new v_wizyta();

        public WizytyEwidencja_f()
        {
            InitializeComponent();
            ZaladujDane();
        }

        private void ZaladujDane()
        {
            _MSEntities = new MEDISTOMAEntities();
            var v_wizyty = (from w in _MSEntities.v_wizyta select w);

            if (edPesel.Text != "")
            {
                v_wizyty = v_wizyty.Where(p => p.pesel.Contains(edPesel.Text));
            }

            if (edImieNazwisko.Text != "")
            {
                v_wizyty = v_wizyty.Where(p => p.imie_nazwisko.Contains(edImieNazwisko.Text));
            }

            grdWizyty.ItemsSource = v_wizyty.ToList();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRealizuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnZakoncz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnZastosujFiltr_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
