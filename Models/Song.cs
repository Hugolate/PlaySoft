namespace PlaySoftBeta.Models
{
    public class Song
    {
        public int songID { get; set; }
        public int spotifySongID { get; set; }
        public string songName { get; set; }
        public int duration { get; set; }
        public DateTime publicationDate { get; set; }

        public IList<PlaylistLines> PlaylistLines { get; set; }
    }
}
