using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/v1/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServive _categoryServive;
        public  CategoryController(ICategoryServive categoryServive) 
        { 
            _categoryServive = categoryServive;
        }

        [HttpGet]
        public ActionResult<Category> Get()
        {
            var category = _categoryServive.List();
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }
            var newCategory= _categoryServive.Add(category);
            return Created("Category Crated", newCategory);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return Ok(_categoryServive.FindById(id));
        }


        [HttpPatch]
        [Route("")]
        public ActionResult<Category> Update([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }

            _categoryServive.Update(category);

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryServive.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {
                throw new ApplicationException("La categoria no puede ser eliminada", exception);
            }
        }
    }
}
