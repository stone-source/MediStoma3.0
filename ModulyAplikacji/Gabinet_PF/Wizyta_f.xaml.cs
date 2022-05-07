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

namespace MediStoma3._0.ModulyAplikacji.Gabinet_PF
{
    public partial class Wizyta_f : Window
    {
        private MEDISTOMAEntities _MSEntities;
        private int _idWizyty;

        public Wizyta_f(int p_IdWizyty, MEDISTOMAEntities p_MSEntities)
        {
            _idWizyty = p_IdWizyty;
            _MSEntities = p_MSEntities;

            InitializeComponent();
            ZaladujDane();
        }

        private void ZaladujDane()
        {

            var wizyta = _MSEntities.v_wizyta.Where(w => w.id_wiz == _idWizyty).FirstOrDefault();

            edImie.Text = wizyta.imie.ToString();
            edNazwisko.Text = wizyta.nazwisko.ToString();
            edNazwiskoRodowe.Text = wizyta.nazwisko_pan.ToString();
            edPesel.Text = wizyta.pesel.ToString();
            edUlica.Text = wizyta.ulica.ToString();
            edNrDomu.Text = wizyta.nr_domu.ToString();
            edNrLokalu.Text = wizyta.nr_lokalu.ToString();
            edKodPocztowy.Text = wizyta.kod_poczt.ToString();
            edMiasto.Text = wizyta.miasto.ToString();

            edImieZatrzask.Text = wizyta.imie_zatrzask.ToString();
            edNazwiskoZatrzask.Text = wizyta.nazwisko_zatrzask.ToString();
            edNazwiskoRodoweZatrzask.Text = wizyta.nazwisko_pan_zatrzask.ToString();
            edPeselZatrzask.Text = wizyta.pesel_zatrzask.ToString();
            edUlicaZatrzask.Text = wizyta.ulica_zatrzask.ToString();
            edNrDomuZatrzask.Text = wizyta.nr_domu_zatrzask.ToString();
            edNrLokaluZatrzask.Text = wizyta.nr_lokalu_zatrzask.ToString();
            edKodPocztowyZatrzask.Text = wizyta.kod_poczt_zatrzask.ToString();
            edMiastoZatrzask.Text = wizyta.miasto_zatrzask.ToString();
        }
    }
}
