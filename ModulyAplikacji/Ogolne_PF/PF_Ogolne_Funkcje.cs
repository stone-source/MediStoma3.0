using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace MediStoma3._0.ModulyAplikacji.Ogolne_PF
{
    internal static class Ogolne_Funkcje
    {
        public static void WyswietlInformacjeOAutorze()
        {
            OknoStartowe_f form = new OknoStartowe_f();
            form.ShowDialog();
        }
    }

    internal static class Ogolne_Walidacje
    {
        public static bool Walidacja(in string p_Wiadomosc)
        {
            System.Windows.MessageBox.Show(p_Wiadomosc, "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
             
        }
    }

    internal static class Ogolne_Ostrzezenia
    {
        public static bool Ostrzezenie(in string p_Wiadomosc) 
        {
            return System.Windows.MessageBox.Show(p_Wiadomosc, "Uwaga!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }
    }

    internal static class Ogolne_Pytania
    {
        public static bool Pytanie(in string p_Wiadomosc)
        {
            return System.Windows.MessageBox.Show(p_Wiadomosc, "Czy chcesz?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }
    }

    internal static class Ogolne_Informacja
    {
        public static bool Informacja(in string p_Wiadomosc)
        {
            return System.Windows.MessageBox.Show(p_Wiadomosc, "Informacja", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK;
        }
    }
}
