namespace PlaySoftBeta.DTOs

{
    public class ArtistDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<AlbumDTO> albums { get; set; }
    }
}