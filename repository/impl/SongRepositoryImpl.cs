using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;

namespace PlaySoftBeta.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public SongRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public SongOutDTO GetSong(int songID)
        {
            return _mapper.Map<SongOutDTO>(_context.Songs?.Find(songID));
        }


        public List<SearchSongOutDTO> GetSongListByName(string songName)
        {
            var songList = _context.Songs.Where(song => song.songName.Contains(songName)).ToList();
            return _mapper.Map<List<SearchSongOutDTO>>(songList);
        }

        public SongOutDTO GetSongBySpotifyID(string spotifyArtistID)
        {
            var song = _context.Artist.Where(album => album.spotifyArtistID.Equals(spotifyArtistID));
            return _mapper.Map<SongOutDTO>(song);
        }

        public void PostSong(SongInDTO SongOutDTO)
        {
            _context.Songs.Add(_mapper.Map<Song>(SongOutDTO));
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}