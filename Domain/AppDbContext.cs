using System.Diagnostics;

namespace Domain
{
    using System.Data.Entity;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
            Database.Log = msg => Debug.WriteLine(msg);
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<AddressChapterRel> AddressChapter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("Common.Address");

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.Address1)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.Address2)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.City)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.County)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.Country)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.Zip5)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.Zip4)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.Longitude)
            //    .HasPrecision(9, 6);

            //modelBuilder.Entity<Address>()
            //    .Property(e => e.Latitude)
            //    .HasPrecision(9, 6);

            //modelBuilder.Entity<AddressType>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<State>()
            //    .Property(e => e.StateCode)
            //    .IsUnicode(false);

            //modelBuilder.Entity<State>()
            //    .Property(e => e.StateName)
            //    .IsUnicode(false);
        }
    }
}
