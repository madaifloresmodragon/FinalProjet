using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IdentityDbContext _dbContext;
        public EmployeeRepository(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee Add(Employee employee)
        {
            _dbContext.Set<Employee>().Add(employee);
            _dbContext.SaveChanges();

            return employee;
        }

        public void Delete(Employee employee)
        {
            _dbContext.Set<Employee>().Remove(employee);
            _dbContext.SaveChanges();
        }

        public Employee FindById(int id)
        {
            return _dbContext.Set<Employee>().First(e => e.Id == id);
        }

        public ICollection<Employee> list()
        {
            return _dbContext.Set<Employee>().ToList();
        }

        public void Update(Employee employee)
        {
            var employeeToUpdate = FindById(employee.Id);

            employeeToUpdate.Address = employee.Address;
            employeeToUpdate.PhoneNumber = employee.PhoneNumber;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.CI = employee.CI;
            employeeToUpdate.Name = employee.Name;

            _dbContext.SaveChanges();
        }
    }
}
