using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Services;

public interface IlibraryService
{
    public bool AddPlaylistToLibrary(LibraryDTO libraryDTO);
    public bool DeleteFromLibrary(int playlistID);

}
