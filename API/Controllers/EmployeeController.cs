using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Security.Principal;

namespace API.Controllers
{
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<Employee> Get()
        {
            var persona = _employeeService.List();
            return Ok(persona);
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody]Employee employee)
        {
            var newEmployee = _employeeService.Add(employee);
            return Created("Employee Crated", newEmployee);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return Ok(_employeeService.FindById(id));
        }


        [HttpPatch]
        [Route("")]
        public ActionResult<Employee> Update([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }

            _employeeService.Update(employee);

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _employeeService.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {
                throw new ApplicationException("El empleado no puede ser eliminado", exception);
            }
        }

    }



}
