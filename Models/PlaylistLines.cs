using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class PlaylistLines
    {

        public int playlistID { get; set; }
        public Playlist Playlist { get; set; }

        public int songID { get; set; }
        public Song Song { get; set; }
    }
}
