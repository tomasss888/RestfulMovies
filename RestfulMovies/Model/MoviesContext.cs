using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestfulMovies.Model
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Filmas> Filmas { get; set; }
        public virtual DbSet<Peržiurėti> Peržiurėti { get; set; }
        public virtual DbSet<StebėjimoSąrašas> StebėjimoSąrašas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:tomasserver.database.windows.net,1433;Initial Catalog=Movies;Persist Security Info=False;User ID=tomas;Password=?kC&9#V1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peržiurėti>(entity =>
            {
                entity.Property(e => e.Komentaras).IsUnicode(false);

                entity.HasOne(d => d.Filmas)
                    .WithMany(p => p.Peržiurėti)
                    .HasForeignKey(d => d.FilmasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Peržiurėt__Filma__571DF1D5");
            });

            modelBuilder.Entity<StebėjimoSąrašas>(entity =>
            {
                entity.HasOne(d => d.Filmas)
                    .WithMany(p => p.StebėjimoSąrašas)
                    .HasForeignKey(d => d.FilmasId)
                    .HasConstraintName("FK__Stebėjimo__Filma__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
