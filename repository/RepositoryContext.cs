using Microsoft.EntityFrameworkCore;
using PlaySoftBeta.Models;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlaylistLines>().HasKey(pl => new { pl.playlistID, pl.songID });
        modelBuilder.Entity<ArtistAlbums>().HasKey(a => new { a.albumID, a.artistID });
        modelBuilder.Entity<ArtistSongs>().HasKey(a => new { a.songID, a.artistID });
        modelBuilder.Entity<Library>().HasKey(l => new { l.userID, l.playlistsID });
        modelBuilder.Entity<User>()
            .HasMany(u => u.Libraries)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.userID)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Playlist>()
            .HasMany(p => p.Libraries)
            .WithOne(l => l.Playlist)
            .HasForeignKey(l => l.playlistsID)
            .OnDelete(DeleteBehavior.Cascade);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<PlaylistLines> PlaylistLines { get; set; }
    public DbSet<Library> Library { get; set; }
    public DbSet<Artist> Artist { get; set; }
    public DbSet<Album> Album { get; set; }
    public DbSet<ArtistSongs> ArtistSongs { get; set; }
    public DbSet<ArtistAlbums> ArtistAlbums { get; set; }
}
