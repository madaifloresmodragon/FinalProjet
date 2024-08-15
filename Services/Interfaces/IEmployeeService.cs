using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        public ICollection<Employee> List();
        public Employee Add(Employee employee);
        public void Update(Employee employee);
        public Employee FindById(int id);
        public void Delete(int id);
    }
}
