using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MediStoma3._0.ModulyAplikacji.Gabinet_PF;
using MediStoma3._0.ModulyAplikacji.Pacjent_PF;

namespace MediStoma3._0.ModulyAplikacji.Ogolne_PF
{
    public partial class OknoBazowe_f : Window
    {
        private enum formatkaBazowa : int
        {
            fbPusta = 0,
            fbKartoteka,
            fbGabinet
        };

        Dictionary<formatkaBazowa, Page> _formatkiBazowe = new Dictionary<formatkaBazowa, Page>();

        public OknoBazowe_f()
        {
            _formatkiBazowe.Add(formatkaBazowa.fbPusta, new Pusta_f());
            _formatkiBazowe.Add(formatkaBazowa.fbGabinet, new WizytyEwidencja_f());
            _formatkiBazowe.Add(formatkaBazowa.fbKartoteka, new PacjenciEwidencja_f());

            InitializeComponent();
            UstawWlasciwosciFormatki();
        }

        private void btnKartoteka_Click(object sender, RoutedEventArgs e)
        {
            UstawAktywneOkno(formatkaBazowa.fbKartoteka);
        }

        private void btnGabinet_Click(object sender, RoutedEventArgs e)
        {
            UstawAktywneOkno(formatkaBazowa.fbGabinet);
        }

        private void btnAutor_Click(object sender, RoutedEventArgs e)
        {
            Ogolne_Funkcje.WyswietlInformacjeOAutorze();
        }

        private void UstawWlasciwosciFormatki()
        {
            UstawAktywneOkno(formatkaBazowa.fbPusta);
        }

        private void UstawAktywneOkno(in formatkaBazowa p_OknoBazowe)
        {
            frmKontent.Content = _formatkiBazowe[p_OknoBazowe];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (frmKontent.Content == _formatkiBazowe[formatkaBazowa.fbPusta])
            {
                Ogolne_Funkcje.WyswietlInformacjeOAutorze();
            }
        }
    }
}
