namespace PlaySoftBeta.DTOs

{
    public class AlbumDTO
    {
        public int albumID { get; set; }
        public string albumName { get; set; }
        public int artistID { get; set; }
        public string? albumDescription { get; set; }
    }
}