namespace MediStoma3._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class pacjent_zatrzask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pacjent_zatrzask()
        {
            this.wizyta = new HashSet<wizyta>();
        }
    
        public int id_pac_zatrzask { get; set; }
        public int id_pac { get; set; }
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
    
        public virtual pacjent pacjent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wizyta> wizyta { get; set; }
    }
}
