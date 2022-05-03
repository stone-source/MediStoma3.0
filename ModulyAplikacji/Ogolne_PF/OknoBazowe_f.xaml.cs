using System.Windows;
using MediStoma3._0.ModulyAplikacji.Gabinet_PF;
using MediStoma3._0.ModulyAplikacji.Pacjent_PF;

namespace MediStoma3._0.ModulyAplikacji.Ogolne_PF
{
    /// <summary>
    /// Logika interakcji dla klasy OknoBazowe_f.xaml
    /// </summary>
    public partial class OknoBazowe_f : Window
    {
        //private WizytaEwidencja_f _ctnGabinetEwidencja { get; set; }
        private PacjenciEwidencja_f _ctnPacjenciEwidencja { get; set; }

        public OknoBazowe_f()
        {
            InitializeComponent();
            PacjenciEwidencja_f _ctnPacjenciEwidencja = new PacjenciEwidencja_f();
        }

        private void btnKartoteka_Click(object sender, RoutedEventArgs e)
        {
            frmKontent.Content = new PacjenciEwidencja_f();
        }

        private void btnGabinet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMenuGlowne_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
