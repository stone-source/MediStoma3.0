//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediStoma3._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class wizyta
    {
        public int id_wiz { get; set; }
        public int id_pac { get; set; }
        public Nullable<int> id_pac_zatrzask { get; set; }
        public string status { get; set; }
        public System.DateTime data_rezerwacji_wizyty { get; set; }
        public Nullable<System.DateTime> data_anulowania_wizyty { get; set; }
        public Nullable<System.DateTime> data_rozpoczecia_wizyty { get; set; }
        public Nullable<System.DateTime> data_zakonczenia_wizyty { get; set; }
    
        public virtual pacjent pacjent { get; set; }
        public virtual pacjent_zatrzask pacjent_zatrzask { get; set; }
    }
}
