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

        public void AddAlbumToArtist(ArtistInDTO artistInDTO, AlbumInDTO albumInDTO)
        {
            var newAlbumArtist = new ArtistAlbums
            {
                Album = _mapper.Map<Album>(albumInDTO),
                Artist = _mapper.Map<Artist>(artistInDTO)
            };

            _context.ArtistAlbums.Add(newAlbumArtist);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}