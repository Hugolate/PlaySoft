using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;

namespace PlaySoftBeta.Repository;

    public interface IUserRepository
    {
        List<SearchUserDTO> GetUserListByUsername(string username);
        UserLibraryPlaylistsDTO GetUser(int ukid);
        void DeleteUser (int playlistID);
        void Save();
    }
