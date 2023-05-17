using AutoMapper;
using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
public class PlaysoftProfile : Profile
{
    public PlaysoftProfile()
    {
        CreateMap<AuhtRegisterUserDTO, User>();
        CreateMap<User, AuthLoginOutDTO>();

        CreateMap<User, UserDTO>();

        CreateMap<Playlist, PlaylistDTO>();
        CreateMap<PlaylistDTO, Playlist>();
        CreateMap<EditPLaylistDTO, Playlist>();

        CreateMap<Song, SongOutDTO>();
        CreateMap<SongInDTO, Song>();
        CreateMap<Song, SearchSongOutDTO>();

        CreateMap<PlaylistLinesDTO, PlaylistLines>();
        CreateMap<PlaylistLines, SongIDSongOutDTO>();

        CreateMap<PlaylistLines, SongIDSongOutDTO>();

        CreateMap<User, SearchUserDTO>();

        CreateMap<AlbumInDTO, Album>();
        CreateMap<Album, AlbumOutDTO>();

        CreateMap<ArtistInDTO, Artist>();
        CreateMap<Artist, ArtistOutDTO>();
        // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
    }
}

