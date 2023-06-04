using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class Playlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int playlistID { get; set; }
        public string playListName { get; set; }
        public string? playlistDescription { get; set; }
        public Boolean privacity { get; set; }
        public IList<PlaylistLines> PlaylistLines { get; set; }
        public IList<Library> Libraries { get; set; }
        public int UserUKID { get; set; }
        public User User { get; set; }
    }
}