using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository //implementing the interace, meaning we have to implement all of the methods that exist in it
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task GetDetailsAsync(Employee employeeWithDetails)
        {
            var employee = await _context.Employees.FindAsync(employeeWithDetails.Id);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id); //returns the employee from the EmployeesDbSet that has a matching ID
        }

        //Implement GetEmployeesAsync method from our IEmployeeRepository interface
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }


    }
}
