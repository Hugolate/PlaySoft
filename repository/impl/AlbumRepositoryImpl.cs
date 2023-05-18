using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;

namespace PlaySoftBeta.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public AlbumRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AlbumOutDTO GetAlbumBySpotifyID(string spotifyAlbumID)
        {
            var album = _context.Album.FirstOrDefault(album => album.spotifyAlbumID.Equals(spotifyAlbumID));
            if (album != null)
            {
                return _mapper.Map<AlbumOutDTO>(album);
            }
            return null;

        }

        public void PostAlbum(AlbumInDTO albumInDTO)
        {
            _context.Album.Add(_mapper.Map<Album>(albumInDTO));
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}