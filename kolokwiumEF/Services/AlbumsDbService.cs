using kolokwium_s22006.Models;
using kolokwium_s22006.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_s22006.Services
{
    public class AlbumsDbService : IAlbumsDbService
    {
        private readonly MainDbContext _mainDbContext;

        public AlbumsDbService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<bool> DoesAlbumExist(int albumID)
        {
            var album = await _mainDbContext.Album.Where(e => e.IdAlbum == albumID).FirstOrDefaultAsync();
            if (album is null) return false;
            return true;
        }

        public async Task<IEnumerable<SomeKindOfAlbum>> GetAlbum(int idAlbumu)
        {
            return await _mainDbContext.Album.Where(e => e.IdAlbum == idAlbumu)
                .Select(e => new SomeKindOfAlbum
                {
                    IdAlbum = e.IdAlbum,
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    MusicLabel = new MusicLabel
                    {
                        Name = e.MusicLabel.Name,
                    },
                    Tracks = e.Track.Select(e => new SomeKindOfTrack
                    {
                        TrackName = e.TrackName,
                        Duration = e.Duration,
                    })
                }).ToListAsync();
        }
    }
}
