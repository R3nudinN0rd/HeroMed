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

        public void AddEmployee(Entities.Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(employee));
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
                throw new ArgumentNullException(nameof(employee));
            }
        }

        public async Task<IEnumerable<Entities.Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
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
            catch(ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(employee));
            }
        }
    }
}
