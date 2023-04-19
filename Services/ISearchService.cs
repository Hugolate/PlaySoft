using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface ISearchService
{
    public SearchDTO SearchByName(string query);

}
