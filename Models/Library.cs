using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class Library
    {

        public int userID { get; set; }
        public User User { get; set; }

        public int playlistsID { get; set; }
        public Playlist Playlist { get; set; }
    }
}
