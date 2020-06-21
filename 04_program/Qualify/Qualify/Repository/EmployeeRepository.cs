using Microsoft.EntityFrameworkCore;
using Qualify.Models;
using Qualify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Repository
{
    public class EmployeeRepository
    {
        private readonly QualifyContext _context = null;
        public EmployeeRepository(QualifyContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = new List<Employee>();
            var allEmployees = await _context.Employees.ToListAsync();
            if (allEmployees?.Any() == true)
            {
                foreach (var employee in allEmployees)
                {
                    employees.Add(new Employee()
                    {
                        ID = employee.ID,
                        Name = employee.Name,
                        DepartmentID = employee.DepartmentID,
                        Position = employee.Position
                    });
                }
            }
            return employees;
        }

        //public async Task<Employee> GetEmployeeNameByActionId(int id)
        //{
        //    var claim = await _context.Claims.Where(x => x.ID == id).FirstOrDefaultAsync();
        //    int currentClientId = claim.ClientID;
        //    return await _context.Clients.Where(x => x.ID == currentClientId).FirstOrDefaultAsync();
        //}

    }
}
