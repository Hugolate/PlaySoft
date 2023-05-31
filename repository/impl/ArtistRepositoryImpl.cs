using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;

namespace PlaySoftBeta.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public ArtistRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ArtistOutDTO> GetAllArtists(int pageNumber)
        {
            return _mapper.Map<List<ArtistOutDTO>>(_context.Artist.OrderBy(a => a.artistID).Skip((pageNumber - 1) * 10).Take(10));
        }
        public void DeleteArtist(int artistID)
        {
            try
            {
                _context.Artist.Remove(_context.Artist.FirstOrDefault(artist => artist.artistID.Equals(artistID)));
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public ArtistOutDTO GetArtistBySpotifyID(string spotifyArtistID)
        {
            var artist = _context.Artist.FirstOrDefault(Artist => Artist.spotifyArtistID.Equals(spotifyArtistID));
            if (artist != null)
            {
                return _mapper.Map<ArtistOutDTO>(artist);
            }
            return null;
        }

        public void PostArtist(ArtistInDTO artistInDTO)
        {
            _context.Artist.Add(_mapper.Map<Artist>(artistInDTO));
        }

        public int CountArtists()
        {
            return _context.Artist.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}