using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace PlaySoftBeta.Repository
{
    public class PlaylistLinesRepositoryImpl : IPlaylistLinesRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public PlaylistLinesRepositoryImpl(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddSong(PlaylistLinesDTO playlistLinesDTO)
        {
            _context.PlaylistLines.Add(_mapper.Map<PlaylistLines>(playlistLinesDTO));
        }

        public List<SongIDSongOutDTO> GetSongsId(int playlistID, string? orderKey, string? order)
        {
            var query = $"SELECT s.songID, p.playlistID FROM PlaylistLines p INNER JOIN Songs s ON s.songID = p.songID WHERE playlistID = {playlistID}";

            if (!string.IsNullOrEmpty(orderKey) && !string.IsNullOrEmpty(order))
            {
                query += $" ORDER BY s.{orderKey} {order} OFFSET 0 ROWS";
            }

            var playlistLines = _context.PlaylistLines
                .FromSqlRaw(query)
                .Include(playlistLines => playlistLines.Song)
                .ToList();

            return _mapper.Map<List<SongIDSongOutDTO>>(playlistLines);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
