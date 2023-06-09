using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PlaySoftBeta.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public UserRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SearchUserDTO> GetUserListByUsername(string username)
        {
            var userList = _context.Users.Where(user => user.username.Contains(username)).ToList();
            return _mapper.Map<List<SearchUserDTO>>(userList);
        }

        public void DeleteUser(int userID)
        {
            _context.Users.Remove(_context.Users.SingleOrDefault(user => user.UKID.Equals(userID)));

        }


        public UserLibraryPlaylistsDTO GetUser(int ukid)
        {
            var user = _context.Users
            .Include(user => user.Libraries.Where(lb => lb.userID == ukid))
                .ThenInclude(lb => lb.Playlist)
            .FirstOrDefault(u => u .UKID == ukid);

            return _mapper.Map<UserLibraryPlaylistsDTO>(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
