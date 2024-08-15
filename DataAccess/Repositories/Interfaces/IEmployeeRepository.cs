using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public ICollection<Employee> list();
        public Employee Add(Employee employee);
        public void Update(Employee employee);
        public Employee FindById(int id);
        public void Delete(Employee employee);
    }
}
