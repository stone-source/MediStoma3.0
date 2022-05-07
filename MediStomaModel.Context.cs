namespace MediStoma3._0
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MEDISTOMAEntities : DbContext
    {
        public MEDISTOMAEntities()
            : base("name=MEDISTOMAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<pacjent> pacjent { get; set; }
        public virtual DbSet<v_pacjent> v_pacjent { get; set; }
        public virtual DbSet<v_wizyta> v_wizyta { get; set; }
        public virtual DbSet<pacjent_zatrzask> pacjent_zatrzask { get; set; }
        public virtual DbSet<wizyta> wizyta { get; set; }
    }
}
