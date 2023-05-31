using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace PlaySoftBeta.Repository
{
    public class ArtistAlbumRepositoryImpl : IArtistAlbumRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public ArtistAlbumRepositoryImpl(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddAlbumToArtist(int artistID, int albumID)
        {
            var newAlbumArtist = new ArtistAlbums
            {
                albumID = albumID,
                artistID = artistID
            };

            _context.ArtistAlbums.Add(newAlbumArtist);
        }

        public bool CheckIfExist(int artistID, int albumID)
        {
            if (_context.ArtistAlbums.Any(x => x.albumID == albumID && x.artistID == artistID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool getLineByAlbumID(int albumID)
        {
            try
            {
                if (_context.ArtistAlbums.FirstOrDefault(a => a.albumID == albumID) != null)
                {
                    return false;
                }
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public List<AlbumOutDTO> GetAlbumByArtistID(int artistId)
        {
            try
            {
                return _mapper.Map<List<AlbumOutDTO>>(_context.Album.Include(a => a.ArtistAlbums.Where(aa => aa.artistID == artistId)).ToList());

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}