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
        private int? _idEdytowanegoPacjenta;
        private int _CelUruchomionegoOkna;

        public Pacjent_f(int? p_IdEdytowanegoPacjenta, int p_CelUruchomionegoOkna)
        {
            _idEdytowanegoPacjenta = p_IdEdytowanegoPacjenta;
            _CelUruchomionegoOkna = p_CelUruchomionegoOkna;

            InitializeComponent();
            f();
        }

        private void f()
        {
            _idEdytowanegoPacjenta = 5;
            _CelUruchomionegoOkna = 2;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Ogolne_Funkcje.DopuscTylkoZnakiNumeryczne(sender, e);
        }
    }
}
