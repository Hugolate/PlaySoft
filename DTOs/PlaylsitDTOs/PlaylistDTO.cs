namespace PlaySoftBeta.DTOs
{
    public class PlaylistDTO
    {
        public int playlistID { get; set; }
        public string playListName { get; set; }
        public int userUKID { get; set; }
        public string? playlistDescription { get; set; }
        public bool? owner { get; set; }
    }
}