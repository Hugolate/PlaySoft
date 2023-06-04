namespace PlaySoftBeta.DTOs
{
    public class SongOutDTO
    {

        public int songID { get; set; }
        public string songName { get; set; }
        public string uri {get; set;}
        public int durationMs { get; set; }
        public string spotifySongID { get; set; }
        public AlbumOutDTO Album {get; set;}
        public IEnumerable<ArtistOutDTO> ArtistSongs  {get; set;} 
    }
}   