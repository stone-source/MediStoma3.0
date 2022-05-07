namespace MediStoma3._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class v_wizyta
    {
        public string imie_nazwisko { get; set; }
        public string nazwisko { get; set; }
        public string nazwisko_pan { get; set; }
        public string imie { get; set; }
        public string pesel { get; set; }
        public string plec { get; set; }
        public string nr_dokumentu { get; set; }
        public string miasto { get; set; }
        public string kod_poczt { get; set; }
        public string ulica { get; set; }
        public string nr_domu { get; set; }
        public string nr_lokalu { get; set; }
        public string imie_nazwisko_zatrzask { get; set; }
        public string nazwisko_zatrzask { get; set; }
        public string nazwisko_pan_zatrzask { get; set; }
        public string imie_zatrzask { get; set; }
        public string pesel_zatrzask { get; set; }
        public string plec_zatrzask { get; set; }
        public string nr_dokumentu_zatrzask { get; set; }
        public string miasto_zatrzask { get; set; }
        public string kod_poczt_zatrzask { get; set; }
        public string ulica_zatrzask { get; set; }
        public string nr_domu_zatrzask { get; set; }
        public string nr_lokalu_zatrzask { get; set; }
        public int id_wiz { get; set; }
        public string status_wizyty { get; set; }
        public System.DateTime data_rezerwacji_wizyty { get; set; }
        public Nullable<System.DateTime> data_anulowania_wizyty { get; set; }
        public Nullable<System.DateTime> data_rozpoczecia_wizyty { get; set; }
        public Nullable<System.DateTime> data_zakonczenia_wizyty { get; set; }
    }
}
