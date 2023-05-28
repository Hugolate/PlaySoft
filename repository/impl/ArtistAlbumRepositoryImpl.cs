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

        public void DeleteArtistAlbum(int albumID)
        {
            var linesList = _context.ArtistAlbums.Where(artistAlbum => artistAlbum.albumID == albumID).ToList();
            if (linesList.Any() && linesList != null)
            {
                _context.ArtistAlbums.RemoveRange(linesList);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}