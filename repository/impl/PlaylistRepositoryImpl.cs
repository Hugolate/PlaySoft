using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PlaySoftBeta.Repository
{
    public class PlaylistRepository : IPLaylistRepository
    {

        private readonly RepositoryContext _context;

        private readonly IMapper _mapper;

        public PlaylistRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int CreatePlaylist(PlaylistDTO playlist)
        {
            var model = _mapper.Map<Playlist>(playlist);
            _context.Playlists.Add(model);
            Save();
            return model.playlistID;

        }

        public List<PlaylistDTO> GetPLaylistList(string name)
        {
            var userList = _context.Playlists.Include(pl => pl.User).Where(user => user.playListName.Contains(name) || user.User.username.Contains(name)).Where(pl => pl.privacity == false).ToList();
            return _mapper.Map<List<PlaylistDTO>>(userList);
        }

        public void EditPLaylist(EditPLaylistDTO editPLaylistDTO)
        {
            int id = editPLaylistDTO.playlistID.GetValueOrDefault();

            var playlist = _context.Playlists.SingleOrDefault(playlist => playlist.playlistID == id);
            Console.WriteLine(playlist);
            if (editPLaylistDTO.playListName != null)
            {
                playlist.playListName = editPLaylistDTO.playListName;
            }
            if (editPLaylistDTO.playlistDescription != null)
            {
                playlist.playlistDescription = editPLaylistDTO.playlistDescription;
            }
            playlist.privacity = editPLaylistDTO.privacity;

            Console.WriteLine(playlist.playlistDescription, playlist.playListName, playlist.privacity);
            Save();
        }

        public void DeletePlaylist(int playlistID)
        {

            _context.Playlists.Remove(_context.Playlists.SingleOrDefault(playlist => playlist.playlistID.Equals(playlistID)));

        }

        public List<PlaylistDTO> getOwnPlaylist(int userUKID)
        {
            var playlistlist = _context.Playlists.Where(playlist => playlist.UserUKID.Equals(userUKID)).ToList();
            return _mapper.Map<List<PlaylistDTO>>(playlistlist);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}