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
using MediStoma3._0.ModulyAplikacji.Ogolne_PF;
using static MediStoma3._0.ModulyAplikacji.Ogolne_PF.PF_Ogolne_Stale;

namespace MediStoma3._0.ModulyAplikacji.Pacjent_PF
{
    public partial class PacjenciEwidencja_f : Page
    {
        private MEDISTOMAEntities _MSEntities;
        private v_pacjent _aktualnyPacjent = new v_pacjent();

        public PacjenciEwidencja_f()
        {
            InitializeComponent();
            ZaladujDane();
        }

        private void ZaladujDane()
        {
            _MSEntities = new MEDISTOMAEntities();
            var v_pacjenci = from p in _MSEntities.v_pacjent select p;
            grdPacjenci.ItemsSource = v_pacjenci.ToList();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Pacjent_f form = new Pacjent_f(null, (int)CelUruchomonegoOkna.coNoweDane, _MSEntities);
            form.ShowDialog();
            ZaladujDane();
        }

        private void btnDane_Click(object sender, RoutedEventArgs e)
        {
            if (SprawdzCzyZaznaczonoPacjenta())
            {
                _aktualnyPacjent = (v_pacjent)grdPacjenci.SelectedItem;
                Pacjent_f form = new Pacjent_f(_aktualnyPacjent.id_pac, (int)CelUruchomonegoOkna.coAktualizacjaDanych, _MSEntities);
                form.ShowDialog();
                ZaladujDane();
            }    
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {     
            if (SprawdzCzyZaznaczonoPacjenta())
            {
                PF_Pacjent_Funkcje.UsunPacjenta(_MSEntities, _aktualnyPacjent.id_pac);
                ZaladujDane();
            }
        }

        private bool SprawdzCzyZaznaczonoPacjenta()
        {
            _aktualnyPacjent = (v_pacjent)grdPacjenci.SelectedItem;
            bool czyZaznaczonyPacjent = _aktualnyPacjent != null;
            if (!czyZaznaczonyPacjent)
            {
                Ogolne_Informacja.Informacja(PF_Pacjent_Powiadomienia.c_Pacjent_NieZaznaczono);
            }
            return czyZaznaczonyPacjent;
        }
    }
}
