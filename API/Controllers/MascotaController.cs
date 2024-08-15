using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/v1/mascota")]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public MascotaController(IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpGet]
        public ActionResult<Mascota> Get()
        {
            var mascotas = _mascotaService.List();

            return Ok(mascotas);
        }

        [HttpPost]
        public ActionResult<Mascota> Post([FromBody] Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }
            var newMascota = _mascotaService.Add(mascota);

            return Created("api/mascota", newMascota);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Mascota> GetById(int id) 
        {
            var mascota = _mascotaService.FindById(id);

            return Ok(mascota);
        }

        [HttpPatch]
        public ActionResult<Mascota> Update([FromBody] Mascota mascota) 
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }
            _mascotaService.Update(mascota);

            return Ok(mascota);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _mascotaService.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {
                throw new ApplicationException("La mascota no puede ser eliminado", exception);
            }
        }
    }
}
