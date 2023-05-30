namespace PlaySoftBeta.DTOs

{
    public class SongArtistAlbumDTO
    {
        public SongInDTO songInDTO { get; set; }
        public AlbumInDTO albumInDTO { get; set; }
        public List<ArtistInDTO> artistInDTO { get; set; }
    }
}
