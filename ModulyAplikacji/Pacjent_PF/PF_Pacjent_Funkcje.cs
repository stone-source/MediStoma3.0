using MediStoma3._0.ModulyAplikacji.Ogolne_PF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoma3._0.ModulyAplikacji.Pacjent_PF
{
    internal class PF_Pacjent_Funkcje
    {
        public static string WyznaczPlec(in string p_Pesel)
        {
            int indexKontrolny = (int)p_Pesel[10];
            return (indexKontrolny % 2 == 0) ? "K" : "M";
        }

        public static void UsunPacjenta(MEDISTOMAEntities p_entity, int p_idPac) 
        {
            if (Ogolne_Pytania.Pytanie(PF_Pacjent_Powiadomienia.c_Pacjent_CzyUsunac))
            {
                try
                {
                    var pac_usun = (from p in p_entity.pacjent
                                    where p.id_pac == p_idPac
                                    select p).First();

                    if (pac_usun != null)
                    {
                        pac_usun.wpis_czy_aktualny = false;
                        p_entity.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw new Exception(PF_Pacjent_Powiadomienia.c_Pacjent_BladUsuwania);
                }
            }
        }
    }
}
