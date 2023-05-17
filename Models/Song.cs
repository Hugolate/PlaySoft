namespace PlaySoftBeta.Models
{
    public class Song
    {
        public int songID { get; set; }
        public string spotifySongID { get; set; }
        public string songName { get; set; }

        public int durationMs { get; set; }
        public DateTime publicationDate { get; set; }

        public IList<PlaylistLines> PlaylistLines { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }

    }
}
