using MediStoma3._0.ModulyAplikacji.Ogolne_PF;
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
            NowaWizytaPacjent_f form = new NowaWizytaPacjent_f();
            form.ShowDialog();
            ZaladujDane();
        }

        private void btnDane_Click(object sender, RoutedEventArgs e)
        {
            if (SprawdzCzyZaznaczonoWizyte())
            {
                Wizyta_f form = new Wizyta_f(_aktualnaWizyta.id_wiz, _MSEntities);
                form.ShowDialog();
            }
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (SprawdzCzyZaznaczonoWizyte())
            {
                PF_Gabinet_Funkcje.UsunWizyte(_MSEntities, _aktualnaWizyta.id_wiz);
                ZaladujDane();
            }
        }

        private void btnRealizuj_Click(object sender, RoutedEventArgs e)
        {
            if (SprawdzCzyZaznaczonoWizyte())
            {
                PF_Gabinet_Funkcje.RozpocznijWizyte(_MSEntities, _aktualnaWizyta.id_wiz);
                ZaladujDane();
            }
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            if (SprawdzCzyZaznaczonoWizyte())
            {
                PF_Gabinet_Funkcje.AnulujWizyte(_MSEntities, _aktualnaWizyta.id_wiz);
                ZaladujDane();
            }
        }

        private void btnZakoncz_Click(object sender, RoutedEventArgs e)
        {
            if (SprawdzCzyZaznaczonoWizyte())
            {
                PF_Gabinet_Funkcje.ZakonczWizyte(_MSEntities, _aktualnaWizyta.id_wiz);
                ZaladujDane();
            }
        }

        private void btnZastosujFiltr_Click(object sender, RoutedEventArgs e)
        {
            ZaladujDane();
        }

        private bool SprawdzCzyZaznaczonoWizyte()
        {
            _aktualnaWizyta = (v_wizyta)grdWizyty.SelectedItem;
            bool czyZaznaczonaWizyta = _aktualnaWizyta != null;
            if (!czyZaznaczonaWizyta)
            {
                Ogolne_Informacja.Informacja(PF_Gabinet_Powiadomienia.c_Wizyta_NieZaznaczono);
            }
            return czyZaznaczonaWizyta;
        }

        private void pgWizytyEwidencja_Loaded(object sender, RoutedEventArgs e)
        {
            ZaladujDane();
        }
    }
}
