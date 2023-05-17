using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace PlaySoftBeta.Repository
{
    public class ArtistSongRepository : IArtistSongRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public ArtistSongRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void AddSongToArtist(ArtistInDTO artistInDTO, SongInDTO songInDTO)
        {
            var newSongArtist = new ArtistSongs
            {
                Artist = _mapper.Map<Artist>(artistInDTO),
                Song = _mapper.Map<Song>(songInDTO)
            };
            _context.ArtistSongs.Add(newSongArtist);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}