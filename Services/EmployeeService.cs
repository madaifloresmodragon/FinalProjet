using DataAccess.Repositories.Interfaces;
using Entities;
using Services.Interfaces;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Add(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public void Delete(int id)
        {
            var employee = _employeeRepository.FindById(id);

            if (employee != null)
            {
                _employeeRepository.Delete(employee);
            }
        }

        public Employee FindById(int id)
        {
            var employee = _employeeRepository.FindById(id);

            return employee;
        }

        public ICollection<Employee> List()
        {
            return _employeeRepository.list();
        }

        public void Update(Employee employee)
        {
            var result = _employeeRepository.FindById(employee.Id);

            if (result != null)
            {
                _employeeRepository.Update(employee);
            }
        }
    }
}
