using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Entities.Employee>> GetAllEmployeesAsync();
        Task<Entities.Employee> GetEmployeeByIdAsync(Guid id);
        Task<Entities.Employee> GetEmployeeByEmailAsync(string email);
        void AddEmployee(Entities.Employee employee);
        void DeleteEmployee(Entities.Employee employee);
        void UpdateEmployee(Entities.Employee employee);
        
        
    }
}
