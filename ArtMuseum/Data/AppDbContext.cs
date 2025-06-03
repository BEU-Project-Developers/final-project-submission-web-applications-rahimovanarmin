using Microsoft.EntityFrameworkCore;

namespace ArtMuseum.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Artist> Artist { get; set; }
        public DbSet<Artwork> Artwork { get; set; }
        public DbSet<ArtStyle> ArtStyle { get; set; }
        public DbSet<ArtworkArtStyle> ArtworkArtStyle { get; set; }
		public DbSet<Blog> Blog { get; set; }
		public DbSet<Exhibition> Exhibition { get; set; }
		public DbSet<Event> Event { get; set; }
		public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artwork>()
                .HasOne(a => a.Artist)
                .WithMany(artist => artist.Artworks)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ArtworkArtStyle>()
                .HasKey(aas => new { aas.ArtWorkId, aas.ArtStyleId });

            modelBuilder.Entity<ArtworkArtStyle>()
                .HasOne(aas => aas.Artwork)
                .WithMany(a => a.ArtworkArtStyles)
                .HasForeignKey(aas => aas.ArtWorkId);

            modelBuilder.Entity<ArtworkArtStyle>()
                .HasOne(aas => aas.ArtStyle)
                .WithMany(s => s.ArtworkArtStyles)
                .HasForeignKey(aas => aas.ArtStyleId);
        }

    }

}
