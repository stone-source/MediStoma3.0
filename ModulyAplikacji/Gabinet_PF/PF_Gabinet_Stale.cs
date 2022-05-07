namespace MediStoma3._0.ModulyAplikacji.Gabinet_PF
{
    internal class PF_Gabinet_Stale
    {
        public static string[] StatusyWizyty = { "Z", "R", "A", "K" };

        public enum StatusWizyty: int
        {
            swZarezerwowana = 0,
            swWRealizacji,
            swAnulowana,
            swZakonczona
        };
    }
}
