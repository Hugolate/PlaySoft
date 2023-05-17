using Microsoft.EntityFrameworkCore;
using PlaySoftBeta.Models;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlaylistLines>().HasKey(pl => new { pl.playlistID, pl.songID });
        modelBuilder.Entity<ArtistAlbums>().HasKey(al => new { al.albumID, al.artistID });
        modelBuilder.Entity<ArtistSongs>().HasKey(al => new { al.songID, al.artistID });


    }
    public DbSet<User> Users { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<PlaylistLines> PlaylistLines { get; set; }
    //Added new models - 13/05/23
    public DbSet<Artist> Artist { get; set; }
    public DbSet<Album> Album { get; set; }
    public DbSet<ArtistSongs> ArtistSongs { get; set; }
    public DbSet<ArtistAlbums> ArtistAlbums { get; set; }
}
