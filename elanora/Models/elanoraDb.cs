namespace elanora.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class elanoraDb : DbContext
    {
        public elanoraDb()
            : base("name=elanoraDb")
        {
        }

        public virtual DbSet<Etiketler> Etiketlers { get; set; }
        public virtual DbSet<Kategoriler> Kategorilers { get; set; }
        public virtual DbSet<Makaleler> Makalelers { get; set; }
        public virtual DbSet<Uyeler> Uyelers { get; set; }
        public virtual DbSet<Yetkiler> Yetkilers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiketler>()
                .HasMany(e => e.Makalelers)
                .WithMany(e => e.Etiketlers)
                .Map(m => m.ToTable("EtiketMakale").MapLeftKey("Etiketid").MapRightKey("Makaleid"));

            modelBuilder.Entity<Kategoriler>()
                .HasMany(e => e.Makalelers)
                .WithRequired(e => e.Kategoriler)
                .HasForeignKey(e => e.KategoriId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Uyeler>()
                .Property(e => e.Uadi)
                .IsUnicode(false);

            modelBuilder.Entity<Uyeler>()
                .Property(e => e.Sifre)
                .IsUnicode(false);

            modelBuilder.Entity<Uyeler>()
                .Property(e => e.UAd)
                .IsUnicode(false);

            modelBuilder.Entity<Uyeler>()
                .Property(e => e.USoyad)
                .IsUnicode(false);

            modelBuilder.Entity<Yetkiler>()
                .HasMany(e => e.Uyelers)
                .WithRequired(e => e.Yetkiler)
                .WillCascadeOnDelete(false);
        }
    }
}
