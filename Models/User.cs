using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlaySoftBeta.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UKID { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public IList<Library> Libraries { get; set; }
        public IList<Playlist> Playlists { get; set; }
    }
}
