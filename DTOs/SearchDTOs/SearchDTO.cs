using PlaySoftBeta.DTOs;
using SpotifyAPI.Web;

namespace PlaySoftBeta.DTOs

{
    public class SearchDTO
    {

        public Task<SearchResponse> spotifyResponse{ get; set; }
        public List<PlaylistDTO> playlist { get; set; }
        
    }
}