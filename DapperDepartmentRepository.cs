using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace BestBuyBestProducts
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {

        private readonly IDbConnection _connection; // this is a field that reads from the sql table
           
        public DapperDepartmentRepository(IDbConnection connection) // this is the IDb connection
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepts()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;").ToList(); // uses the dapper method called query
        }
        public void InsertDepartment(string newDeptName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);", new { departmentName = newDeptName });
        }

    }
}
