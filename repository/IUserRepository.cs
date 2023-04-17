using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

    public interface IUserRepository
    {
        List<SearchUserDTO> GetUserListByUsername(string username);
        UserDTO GetUser(int ukid);
        void Save();
    }
