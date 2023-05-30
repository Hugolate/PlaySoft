using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            return _mapper.Map<SongOutDTO>(_context.Songs?
            .Include(s => s.Album)
            .Include(s => s.ArtistSongs).ThenInclude(a => a.Artist)
            .FirstOrDefault(s => s.songID == songID));
        }

        public List<SongOutDTO> GetAllSongs(int pageNumber)
        {

            return _mapper.Map<List<SongOutDTO>>(_context.Songs.OrderBy(s => s.songID).Skip((pageNumber - 1) * 10).Take(10));

        }

        public void DeleteSong(int songID)
        {
            if (songID != null)
            {
                _context.Songs.Remove(_context.Songs.FirstOrDefault(song => song.songID.Equals(songID)));
            }
        }
        public List<SearchSongOutDTO> GetSongListByName(string songName)
        {
            var songList = _context.Songs.Where(song => song.songName.Contains(songName)).ToList();
            return _mapper.Map<List<SearchSongOutDTO>>(songList);
        }

        public SongOutDTO GetSongBySpotifyID(string spotifyArtistID)
        {
            var song = _context.Songs.FirstOrDefault(song => song.spotifySongID.Equals(spotifyArtistID));
            return _mapper.Map<SongOutDTO>(song);
        }

        public void PostSong(SongInDTO SongOutDTO)
        {
            _context.Songs.Add(_mapper.Map<Song>(SongOutDTO));
        }

        public int CountSongs()
        {
            return _context.Artist.Count();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}