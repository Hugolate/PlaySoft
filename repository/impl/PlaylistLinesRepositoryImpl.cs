using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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
            var query = _context.PlaylistLines
                .Where(pl => pl.playlistID == 1)
                .Include(pl => pl.Song)
                    .ThenInclude(s => s.Album)
                .Include(pl => pl.Song)
                    .ThenInclude(s => s.ArtistSongs)
                        .ThenInclude(a => a.Artist);
            if(order.Equals("ASC")){
                
            }
            var orderedQuery = query.OrderBy(orderKey +" "+ order);


            return _mapper.Map<List<SongIDSongOutDTO>>(orderedQuery);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}