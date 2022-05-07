using MediStoma3._0.ModulyAplikacji.Ogolne_PF;
using System;
using System.Linq;

namespace MediStoma3._0.ModulyAplikacji.Gabinet_PF
{
    internal class PF_Gabinet_Funkcje
    {
        public static void UsunWizyte(MEDISTOMAEntities p_entity, int p_IdWizyty)
        {
            if (Ogolne_Pytania.Pytanie(PF_Gabinet_Powiadomienia.c_Wizyta_CzyUsunac))
            {
                try
                {
                    var wiz_usun = (from w in p_entity.wizyta
                                    where w.id_wiz == p_IdWizyty
                                    select w).First();

                    if (wiz_usun != null)
                    {
                        p_entity.wizyta.Remove(wiz_usun);
                        p_entity.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw new Exception(PF_Gabinet_Powiadomienia.c_Wizyta_BladUsuwania);
                }
            }
        }

        public static void RozpocznijWizyte(MEDISTOMAEntities p_entity, in int p_IdWizyty)
        {
            if (Ogolne_Pytania.Pytanie(PF_Gabinet_Powiadomienia.c_Wizyta_CzyRozpoczac))
            {
                ZmienStatusWizyty(p_entity, p_IdWizyty, PF_Gabinet_Stale.StatusWizyty.swWRealizacji);
            }
        }

        public static void AnulujWizyte(MEDISTOMAEntities p_entity, in int p_IdWizyty)
        {
            if (Ogolne_Pytania.Pytanie(PF_Gabinet_Powiadomienia.c_Wizyta_CzyAnulowac))
            {
                ZmienStatusWizyty(p_entity, p_IdWizyty, PF_Gabinet_Stale.StatusWizyty.swAnulowana);
            }
        }

        public static void ZakonczWizyte(MEDISTOMAEntities p_entity, in int p_IdWizyty)
        {
            if (Ogolne_Pytania.Pytanie(PF_Gabinet_Powiadomienia.c_Wizyta_CzyZakonczyc))
            {
                ZmienStatusWizyty(p_entity, p_IdWizyty, PF_Gabinet_Stale.StatusWizyty.swZakonczona);
            }
        }

        public static void ZmienStatusWizyty(MEDISTOMAEntities p_entity, int p_IdWizyty, PF_Gabinet_Stale.StatusWizyty p_StatusWizyty)
        {
            try
            {
                var wiz_zmiana = (from w in p_entity.wizyta
                                  where w.id_wiz == p_IdWizyty
                                  select w).FirstOrDefault();

                if (wiz_zmiana != null)
                {
                    wiz_zmiana.status = PF_Gabinet_Stale.StatusyWizyty[(int)p_StatusWizyty];
                    p_entity.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception(PF_Gabinet_Powiadomienia.c_Wizyta_BladUsuwania);
            }
        }
    }
}
