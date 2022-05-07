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
using System.Windows.Shapes;
using MediStoma3._0.ModulyAplikacji.Gabinet_PF;

namespace MediStoma3._0.ModulyAplikacji.Gabinet_PF
{
    /// <summary>
    /// Logika interakcji dla klasy NowaWizytaPacjent_f.xaml
    /// </summary>
    public partial class NowaWizytaPacjent_f : Window
    {
        private MEDISTOMAEntities _MSEntities;

        public NowaWizytaPacjent_f()
        {
            InitializeComponent();
            ZaladujDane();
        }

        private void ZaladujDane()
        {
            _MSEntities = new MEDISTOMAEntities();
            var v_pacjenci = (from p in _MSEntities.v_pacjent
                              where p.wpis_czy_aktualny
                              select p);

            cmbPacjent.ItemsSource = v_pacjenci.ToList();
            cmbPacjent.DisplayMemberPath = "imie_nazwisko";
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            wizyta nowa_wizyta = new wizyta();
            nowa_wizyta.status = PF_Gabinet_Stale.StatusyWizyty[(int)PF_Gabinet_Stale.StatusWizyty.swZarezerwowana];
            nowa_wizyta.id_pac = ((v_pacjent)(cmbPacjent.SelectedItem)).id_pac;
            nowa_wizyta.data_rezerwacji_wizyty = DateTime.Now;
            _MSEntities.wizyta.Add(nowa_wizyta);
            _MSEntities.SaveChanges();
            this.Close();
        }
    }
}
