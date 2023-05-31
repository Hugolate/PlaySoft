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


        public void AddSongToArtist(int artistID, int songID)
        {
            var newSongArtist = new ArtistSongs
            {
                artistID = artistID,
                songID = songID
            };
            _context.ArtistSongs.Add(newSongArtist);
        }

        public bool CheckIfExist(int artistID, int songID)
        {

            if (_context.ArtistSongs.Any(x => x.songID == songID && x.artistID == artistID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}