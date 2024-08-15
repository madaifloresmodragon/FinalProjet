using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<Product> Get()
        {
            var products = _productService.List();

            return Ok(products);
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }
            var newProduct = _productService.Add(product);

            return Created("api/product", newProduct);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> GetById(int id) 
        {
            var product = _productService.FindById(id);

            return Ok(product);
        }

        [HttpPatch]
        public ActionResult<Product> Update([FromBody] Product product) 
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }
            _productService.Update(product);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {
                throw new ApplicationException("El producto no puede ser eliminado", exception);
            }
        }
    }
}
