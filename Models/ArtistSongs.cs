using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class ArtistSongs
    {

        public int artistID { get; set; }
        public Artist Artist { get; set; }

        public int songID { get; set; }
        public Song Song { get; set; }
    }
}
