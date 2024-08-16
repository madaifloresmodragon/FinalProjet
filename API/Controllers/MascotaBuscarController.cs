using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/v1/mascota/buscar")]
    public class MascotaBuscarController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public MascotaBuscarController(IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

 

        [HttpPost]
        public ActionResult<Mascota> FindByRazas([FromBody] List<String> razas)
        {
            var mascotas = _mascotaService.FindByRazas(razas);
            return Ok(mascotas);

        }


    }
}
