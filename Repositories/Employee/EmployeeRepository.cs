using HeroMed_API.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
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

        public async Task<Entities.Employee> AddEmployeeAsync(Entities.Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (SqlException ex)
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
            catch(SqlException ex) 
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Entities.Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<IEnumerable<Entities.Employee>> GetEmployeesBySectionIdAsync(Guid sectionId)
        {
            return await _context.Employees.Where(e => e.SectionId == sectionId).ToListAsync();
        }
        public async Task<Entities.Employee> GetEmployeeByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync<Entities.Employee>(e => e.Email == email);
        }

        public async Task<Entities.Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employees.FirstOrDefaultAsync<Entities.Employee>(e => e.Id == id);
        }

        public async Task<IEnumerable<Entities.Employee>> GetEmployeesWithoutAccount()
        {
            var employees = await _context.Employees.ToListAsync();
            var users = await _context.Users.ToListAsync();

            List<Entities.Employee> results = new List<Entities.Employee>();

            foreach(var employee in employees)
            {
                bool found = false;
                foreach(var user in users)
                {
                    if(employee.Id == user.EmployeeId)
                    {
                        found = true;
                        break;
                    }
                }
                if(found == false)
                {
                    results.Add(employee);
                }
            }

            return results;
        }


        public void UpdateEmployee(Entities.Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }


    }
}
