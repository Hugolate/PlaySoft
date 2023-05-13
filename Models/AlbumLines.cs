using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class AlbumLines
    {

        public int albumID { get; set; }
        public Album Album { get; set; }

        public int songID { get; set; }
        public Song Song { get; set; }
    }
}
