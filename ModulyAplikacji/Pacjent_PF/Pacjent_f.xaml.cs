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
using MediStoma3._0.ModulyAplikacji.Ogolne_PF;

namespace MediStoma3._0.ModulyAplikacji.Pacjent_PF
{
    public partial class Pacjent_f : Window
    {
        private MEDISTOMAEntities _MSEntities;
        private int? _idEdytowanegoPacjenta;
        private int _CelUruchomionegoOkna;

        public Pacjent_f(int? p_IdEdytowanegoPacjenta, int p_CelUruchomionegoOkna, MEDISTOMAEntities p_MSEntities)
        {
            _idEdytowanegoPacjenta = p_IdEdytowanegoPacjenta;
            _CelUruchomionegoOkna = p_CelUruchomionegoOkna;
            _MSEntities = p_MSEntities;

            InitializeComponent();
            ZaladujDane();
        }

        private void ZaladujDane()
        {
            if ((_idEdytowanegoPacjenta != null) && (_CelUruchomionegoOkna == (int)CelUruchomonegoOkna.coAktualizacjaDanych))
            {
                var pacjent_edycja = _MSEntities.pacjent.Where(p => p.id_pac == _idEdytowanegoPacjenta).FirstOrDefault();

                edImie.Text = pacjent_edycja.imie.ToString();
                edNazwisko.Text = pacjent_edycja.nazwisko.ToString();
                edNazwiskoRodowe.Text = pacjent_edycja.nazwisko_pan.ToString();
                edPesel.Text = pacjent_edycja.pesel.ToString();

                edUlica.Text = pacjent_edycja.ulica.ToString();
                edNrDomu.Text = pacjent_edycja.nr_domu.ToString();
                edNrLokalu.Text = pacjent_edycja.nr_lokalu.ToString();
                edKodPocztowy.Text = pacjent_edycja.kod_poczt.ToString();
                edMiasto.Text = pacjent_edycja.miasto.ToString();
            }
        }

        private void WprowadzDanePacjenta(ref pacjent p_Pacjent)
        {
            p_Pacjent.imie = edImie.Text;
            p_Pacjent.nazwisko = edNazwisko.Text;
            p_Pacjent.nazwisko_pan = edNazwiskoRodowe.Text;
            p_Pacjent.pesel = edPesel.Text;

            p_Pacjent.ulica = edUlica.Text;
            p_Pacjent.nr_domu = edNrDomu.Text;
            p_Pacjent.nr_lokalu = edNrLokalu.Text;
            p_Pacjent.kod_poczt = edKodPocztowy.Text;
            p_Pacjent.miasto = edMiasto.Text;
        }

        private void WalidujDane()
        {

        }

        private void ZapiszDane()
        {
            if ((_idEdytowanegoPacjenta == null) && (_CelUruchomionegoOkna == (int)CelUruchomonegoOkna.coAktualizacjaDanych))
            {
                pacjent nowy_pacjent = new pacjent();
                nowy_pacjent.imie = edImie.Text;
                nowy_pacjent.nazwisko = edNazwisko.Text;
                nowy_pacjent.nazwisko_pan = edNazwiskoRodowe.Text;
                nowy_pacjent.pesel = edPesel.Text;
                nowy_pacjent.nr_dokumentu = edNrDokumentu.Text;

                nowy_pacjent.ulica = edUlica.Text;
                nowy_pacjent.nr_domu = edNrDomu.Text;
                nowy_pacjent.nr_lokalu = edNrLokalu.Text;
                nowy_pacjent.kod_poczt = edKodPocztowy.Text;
                nowy_pacjent.miasto = edMiasto.Text;
                _MSEntities.pacjent.Add(nowy_pacjent);
                _MSEntities.SaveChanges();
            }
            else
            {
                var pacjent_edycja = _MSEntities.pacjent.Where(p => p.id_pac == _idEdytowanegoPacjenta).FirstOrDefault();
                pacjent_edycja.imie = edImie.Text;
                pacjent_edycja.nazwisko = edNazwisko.Text;
                pacjent_edycja.nazwisko_pan = edNazwiskoRodowe.Text;
                pacjent_edycja.pesel = edPesel.Text;
                pacjent_edycja.nr_dokumentu = edNrDokumentu.Text;

                pacjent_edycja.ulica = edUlica.Text;
                pacjent_edycja.nr_domu = edNrDomu.Text;
                pacjent_edycja.nr_lokalu = edNrLokalu.Text;
                pacjent_edycja.kod_poczt = edKodPocztowy.Text;
                pacjent_edycja.miasto = edMiasto.Text;
                _MSEntities.SaveChanges();
            }
        }

        private void ZamknijOkno()
        {
            this.Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Ogolne_Funkcje.DopuscTylkoZnakiNumeryczne(sender, e);
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            WalidujDane();
            ZapiszDane();
            ZamknijOkno();
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            if (Ogolne_Pytania.Pytanie(PF_Ogolne_Powiadomienia.c_Ogolne_CzyPrzerwacEdycje))
            {
                ZamknijOkno();
            }
        }
    }
}
