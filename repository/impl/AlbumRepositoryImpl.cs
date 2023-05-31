using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PlaySoftBeta.Repository
{
    public class AlbumRepositoryImpl : IAlbumRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public AlbumRepositoryImpl(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AlbumOutDTO> GetAllAlbums()
        {
            return _mapper.Map<List<AlbumOutDTO>>(_context.Album);
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

        public void DeleteAlbum(int albumID)
        {
            if (albumID != null)
            {
                _context.Album.Remove(_context.Album.FirstOrDefault(album => album.albumID.Equals(albumID)));
            }
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