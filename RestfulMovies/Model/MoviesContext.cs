using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Seen> Seen { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }

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
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Genre).IsUnicode(false);

                entity.Property(e => e.Length).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Seen>(entity =>
            {
                entity.Property(e => e.Comment).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Seen)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Seen__Movie_ID__68487DD7");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.Date).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Wishlist__Movie___619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
