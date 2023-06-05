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
            _logger.LogError(e, "Error deleting playlist");
            throw;
        }
    }
    
    public void AddPlaylistToLibrary(LibraryDTO libraryDTO)
    {
        if (libraryDTO.playlistID != null)
        {
            _libraryRepository.NewLine(libraryDTO.userID, libraryDTO.playlistID);
            _libraryRepository.Save();
        }
    }
}
