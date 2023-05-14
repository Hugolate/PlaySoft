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
        public SongDTO GetSong(int songID)
        {
            return _mapper.Map<SongDTO>(_context.Songs?.Find(songID));
        }


        public List<SearchSongDTO> GetSongListByName(string songName)
        {
            var songList = _context.Songs.Where(song => song.songName.Contains(songName)).ToList();
            return _mapper.Map<List<SearchSongDTO>>(songList);
        }
        public void PostSong(SongInDTO songDTO)
        {
            _context.Songs.Add(_mapper.Map<Song>(songDTO));
        }
    }
}