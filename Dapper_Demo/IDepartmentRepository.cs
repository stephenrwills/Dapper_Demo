using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Demo
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();

        void InsertDepartment(string newDepartmentName);

        public void UpdateDepartment(int id, string newName); 

        public void DeleteDepartment(int startPosition, int endPosition);   
    }
}
