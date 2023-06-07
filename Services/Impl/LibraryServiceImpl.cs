using PlaySoftBeta.DTOs;
using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;


namespace PlaySoftBeta.Services;

public class LibraryServiceImpl : IlibraryService
{
    private readonly ILogger<LibraryServiceImpl> _logger;
    private readonly ILibraryRepository _libraryRepository;

    public LibraryServiceImpl(ILibraryRepository libraryRepository, ILogger<LibraryServiceImpl> logger)
    {
        _libraryRepository = libraryRepository;
        _logger = logger;
    }
    public bool DeleteFromLibrary(int playlistID)
    {
        try
        {
            _libraryRepository.Deleteline(playlistID);
            _libraryRepository.Save();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error on delete");
            return false;
        }
    }

    public bool AddPlaylistToLibrary(LibraryDTO libraryDTO)
    {
        try
        {
            _libraryRepository.NewLine(libraryDTO.userID, libraryDTO.playlistID);
            _libraryRepository.Save();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(this.GetType().Name, e, "Error adding playlist to library");
            return false;
        }

    }
}
