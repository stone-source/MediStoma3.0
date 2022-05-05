using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MediStoma3._0.ModulyAplikacji.Gabinet_PF;
using MediStoma3._0.ModulyAplikacji.Pacjent_PF;

namespace MediStoma3._0.ModulyAplikacji.Ogolne_PF
{
    /// <summary>
    /// Logika interakcji dla klasy OknoBazowe_f.xaml
    /// </summary>
    public partial class OknoBazowe_f : Window
    {
        private enum formatkaBazowa : int
        {
            fbKartoteka = 0,
            fbGabinet
        };

        Dictionary<formatkaBazowa, Page> _formatkiBazowe = new Dictionary<formatkaBazowa, Page>();

        public OknoBazowe_f()
        {
            InitializeComponent();
            WyswietlInformacjeOAutorze();

            _formatkiBazowe.Add(formatkaBazowa.fbGabinet, new WizytyEwidencja_f());
            _formatkiBazowe.Add(formatkaBazowa.fbKartoteka, new PacjenciEwidencja_f());
        }

        private void btnKartoteka_Click(object sender, RoutedEventArgs e)
        {
            UstawAktywneOkno(formatkaBazowa.fbKartoteka);
        }

        private void btnGabinet_Click(object sender, RoutedEventArgs e)
        {
            UstawAktywneOkno(formatkaBazowa.fbGabinet);
        }

        private void btnMenuGlowne_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void UstawAktywneOkno(in formatkaBazowa p_OknoBazowe)
        {

            frmKontent.Content = _formatkiBazowe[p_OknoBazowe];
        }

        private void WyswietlInformacjeOAutorze()
        {
            OknoStartowe_f form = new OknoStartowe_f();
            form.ShowDialog();
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {

        }
    }
}
