using HeroMed_API.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Remoting;

namespace HeroMed_API.Repositories.Employee
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly HeroMedContext _context;

        public EmployeeRepository(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool EmployeeExists(Guid employeeId)
        {
            if (_context.Employees.FirstOrDefault(e => e.Id == employeeId) != null)
                return true;

            return false;
        }

        public void AddEmployee(Entities.Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEmployee(Entities.Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            catch(Exception) 
            {
                throw new Exception(nameof(employee));
            }
        }

        public async Task<IEnumerable<Entities.Employee>> GetAllEmployeesAsync()
        {
            var entity = await _context.Employees.ToListAsync();
            return entity;
        }

        public async Task<Entities.Employee> GetEmployeeByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync<Entities.Employee>(e => e.Email == email);
        }

        public async Task<Entities.Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employees.FirstOrDefaultAsync<Entities.Employee>(e => e.Id == id);
        }

        public void UpdateEmployee(Entities.Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw new Exception(nameof(employee));
            }
        }

    }
}
