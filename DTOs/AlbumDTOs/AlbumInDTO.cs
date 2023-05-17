namespace PlaySoftBeta.DTOs

{
    public class AlbumInDTO
    {
        public string spotifyAlbumID { get; set; }
        public string albumName { get; set; }
        public DateTime releaseDate { get; set; }
        public string image { get; set; }
        public int totalTracks { get; set; }
        public enum albumType
        {
            Single,
            Ep,
            Album
        }
    }
}
