using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace Dapper_Demo
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void DeleteDepartment(int startPosition, int endPosition)
        {
            _connection.Execute("DELETE FROM DEPARTMENTS WHERE DepartmentID BETWEEN @start and @end;", new {start = startPosition, end = endPosition});
        }

        public IEnumerable<Department> GetAllDepartments()
        {
           return _connection.Query<Department>("SELECT * FROM departments;");
        }


        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);", new { departmentName = newDepartmentName });
        }

        public void UpdateDepartment(int id, string newName)
        {
            _connection.Execute("UPDATE DEPARTMENTS SET Name = @name WHERE DepartmentID = @id;", new { name = newName, id = id });
        }


    }
}
