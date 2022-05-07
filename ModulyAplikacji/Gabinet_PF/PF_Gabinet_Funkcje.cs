namespace MediStoma3._0.ModulyAplikacji.Gabinet_PF
{
    internal class PF_Gabinet_Funkcje
    {
        public static void RozpocznijWizyte(in int p_IdWizyty)
        {
            ZmienStatusWizyty(p_IdWizyty, PF_Gabinet_Stale.StatusWizyty.swWRealizacji);
        }

        public static void AnulujWizyte(in int p_IdWizyty)
        {
            ZmienStatusWizyty(p_IdWizyty, PF_Gabinet_Stale.StatusWizyty.swAnulowana);
        }

        public static void ZakonczWizyte(in int p_IdWizyty)
        {
            ZmienStatusWizyty(p_IdWizyty, PF_Gabinet_Stale.StatusWizyty.swZakonczona);
        }

        public static void ZmienStatusWizyty(in int p_IdWizyty, PF_Gabinet_Stale.StatusWizyty p_StatusWizyty)
        {

        }
    }
}
