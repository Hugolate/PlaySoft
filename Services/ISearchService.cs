using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using SpotifyAPI.Web;

namespace PlaySoftBeta.Services;

public interface ISearchService
{
    public Task<SearchResponse> SearchByName(string query);

}
