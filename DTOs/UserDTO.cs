namespace PlaySoftBeta.DTOs

{
    public class UserDTO
    {
        public string email { get; set; }
        public string username { get; set; }
        public List<PlaylistDTO> playlists { get; set; }


    }
}
