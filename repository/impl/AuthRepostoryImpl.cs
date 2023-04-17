using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;

namespace PlaySoftBeta.Repository
{
    public class AuthRepository : IAuthRepositoy
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthLoginOutDTO GetUserByEmail(string userEmail)
        {
            var user = _context.Users?.SingleOrDefault(user => user.email.Equals(userEmail));
            if (user != null)
            {
                return _mapper.Map<AuthLoginOutDTO>(user);
            }
            return null;
        }

        public void RegisterUser(AuhtRegisterUserDTO authDTO)
        {
            _context.Users.Add(_mapper.Map<User>(authDTO));
        }

        public Boolean CheckEmail(string userEmail)
        {
            if (_context.Users.Any(user => user.email == userEmail))
            {
                return true;
            }
            return false;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
