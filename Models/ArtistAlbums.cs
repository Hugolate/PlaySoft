using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class ArtistAlbums
    {
        public int albumID { get; set; }
        public Album Album { get; set; }

        public int artistID { get; set; }
        public Artist Artist { get; set; }
    }
}//