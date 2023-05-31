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

        public List<ArtistOutDTO> GetAllArtists()
        {
            return _mapper.Map<List<ArtistOutDTO>>(_context.Artist);
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}