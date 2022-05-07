namespace MediStoma3._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class v_pacjent
    {
        public int id_pac { get; set; }
        public string imie_nazwisko { get; set; }
        public string nazwisko_pan { get; set; }
        public string pesel { get; set; }
        public string plec { get; set; }
        public string nr_dokumentu { get; set; }
        public string miejsce_zamieszkania { get; set; }
        public System.DateTime wpis_data_dodania { get; set; }
        public System.DateTime wpis_data_aktualizacji { get; set; }
        public bool wpis_czy_aktualny { get; set; }
    }
}
