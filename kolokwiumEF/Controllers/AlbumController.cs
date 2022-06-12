using kolokwium_s22006.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace kolokwium_s22006.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {

        private readonly IAlbumsDbService _albumsDbService;
        public AlbumsController(IAlbumsDbService albumsDbService)
        {
            _albumsDbService = albumsDbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbumy(int idAlbumu)
        {
            try
            {
                if (idAlbumu < 0)
                    return BadRequest("ID Albumu nie może być mniejsze od 0");
                if (!await _albumsDbService.DoesAlbumExist(idAlbumu))
                    return NotFound("Album o podanym id nie istnieje");
                return Ok(await _albumsDbService.GetAlbum(idAlbumu));
            }
            catch (System.Exception)
            {
                return Conflict();
            }

        }
    }
}
