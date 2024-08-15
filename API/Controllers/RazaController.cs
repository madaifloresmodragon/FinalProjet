using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/v1/raza")]
    public class RazaController : ControllerBase
    {
        private readonly IRazaServive _razaServive;
        public  RazaController(IRazaServive razaServive) 
        { 
            _razaServive = razaServive;
        }

        [HttpGet]
        public ActionResult<Raza> Get()
        {
            var raza = _razaServive.List();
            return Ok(raza);
        }

        [HttpPost]
        public ActionResult<Raza> Post([FromBody] Raza raza)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }
            var newRaza= _razaServive.Add(raza);
            return Created("Raza Crated", newRaza);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Raza> Get(int id)
        {
            return Ok(_razaServive.FindById(id));
        }


        [HttpPatch]
        [Route("")]
        public ActionResult<Raza> Update([FromBody] Raza raza)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }

            _razaServive.Update(raza);

            return Ok(raza);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _razaServive.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {
                throw new ApplicationException("La raza no puede ser eliminada", exception);
            }
        }
    }
}
