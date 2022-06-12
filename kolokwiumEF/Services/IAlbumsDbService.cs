using kolokwium_s22006.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kolokwium_s22006.Services
{
    public interface IAlbumsDbService
    {
        Task<IEnumerable<SomeKindOfAlbum>> GetAlbum(int idAlbumu);
        Task<bool> DoesAlbumExist(int albumID);
    }
}
