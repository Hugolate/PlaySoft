using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

public interface ILibraryRepository
{
    void NewLine(int userID, int playlistID);
    void Save();

}
