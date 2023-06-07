namespace PlaySoftBeta.DTOs
{
    public class EditPLaylistDTO
    {
        public int? playlistID { get; set; }
        public string? playListName { get; set; }
        public string? playlistDescription { get; set; }
        public bool privacity { get; set; }
    }
}