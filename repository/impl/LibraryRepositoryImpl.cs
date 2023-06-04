using PlaySoftBeta.Models;
using PlaySoftBeta.DTOs;
using AutoMapper;

namespace PlaySoftBeta.Repository
{
    public class LibraryRepositoryImpl : ILibraryRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public LibraryRepositoryImpl(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void NewLine(int userID, int playlistID)
        {
            var line = new Library
            {
                playlistsID = playlistID,
                userID = userID
            };
            _context.Library.Add(line);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
