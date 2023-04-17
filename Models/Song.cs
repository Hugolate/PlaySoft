namespace PlaySoftBeta.Models
{
    public class Song
    {
        public int songID { get; set; }
        public string songName { get; set; }
        //public decimal duration { get; set; }
        public DateTime publicationDate { get; set; }

        public IList<PlaylistLines> PlaylistLines { get; set; }
    }
}
