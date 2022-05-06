using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
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

        private bool WalidujDane()
        {
            bool bladWalidacji = false;
            if (!bladWalidacji && (edImie.Text.Length == 0))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjnt_BrakImienia);
                edImie.Focus();
            }

            if (!bladWalidacji && (edNazwisko.Text.Length == 0))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjent_BrakNazwiska);
                edNazwisko.Focus();
            }

            if (!bladWalidacji && (edPesel.Text.Length == 0))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjnt_BrakPeselu);
                edPesel.Focus();

            }
            else if (!bladWalidacji && !PF_Pacjent_Funkcje.WalidujPesel(edPesel.Text))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjent_PeselNieprawidlowy);
                edPesel.Focus();
            }

            if (!bladWalidacji && (edNrDokumentu.Text.Length == 0))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjent_BrakNrDokumentu);
                edNrDokumentu.Focus();
            }

            if (!bladWalidacji && (edUlica.Text.Length == 0))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjent_BrakUlicy);
                edUlica.Focus();
            }

            if (!bladWalidacji && (edNrDomu.Text.Length == 0))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjent_BrakNumruDomu);
                edNrDomu.Focus();
            }

            if (!bladWalidacji && (edKodPocztowy.Text.Length == 0))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjent_BrakKoduPocztowego);
                edKodPocztowy.Focus();
            }

            if (!bladWalidacji && (edMiasto.Text.Length == 0))
            {
                bladWalidacji = Ogolne_Walidacje.Walidacja(PF_Pacjent_Powiadomienia.c_Pacjent_BrakMiasta);
                edMiasto.Focus();
            }

            return bladWalidacji;
        }

        private void ZapiszDane()
        {
            if (_CelUruchomionegoOkna == (int)CelUruchomonegoOkna.coNoweDane)
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
                nowy_pacjent.wpis_data_dodania = DateTime.Now;
                nowy_pacjent.wpis_data_aktualizacji = DateTime.Now;
                nowy_pacjent.plec = PF_Pacjent_Funkcje.WyznaczPlec(edPesel.Text);
                nowy_pacjent.wpis_czy_aktualny = true;
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
            if (!WalidujDane())
            {
                ZapiszDane();
                ZamknijOkno();
            }
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
