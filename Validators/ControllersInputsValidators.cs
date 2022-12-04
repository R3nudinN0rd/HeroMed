using HeroMed_API.Entities;

namespace HeroMed_API.Validators
{
    public class ControllersInputsValidators
    {
        #region CommonValidators
        public bool ValidateGuid(Guid guid)
        {
            Guid x;
            if (Guid.TryParse(guid.ToString(), out x) == false)
            {
                return false;
            }

            return true;
        }

        public bool ValidateString(string str)
        {
            if (str == "")
            {
                return false;
            }

            return true;
        }
        #endregion

        #region PatientValidators
        public bool ValidateResult(Patient patient)
        {
            if(patient == null)
            {
                return false;
            }

            return true;
        }

        public bool ValidateResult(IEnumerable<Patient> patients)
        {
            if(patients.Count() == 0)
            {
                return false;
            }

            return true;
        }

        public bool ValidatePatientToInsert(Patient patient)
        {
            if(patient.Id == Guid.Empty ||
               patient.SalonId == Guid.Empty)
            {
                return false;
            }

            if(patient.FirstName == "" ||
               patient.LastName == "" ||
               patient.Address == "" ||
               patient.Email == "" ||
               patient.PhoneNumber == "" ||
               patient.EmergencyContactName == "" ||
               patient.EmergencyContactPhoneNumber == "" ||
               patient.IssueDetails == "")
            {
                return false;
            }

            return true;
        }

        #endregion
        #region EmployeeValidators
        public bool ValidateResult(Employee employee)
        {
            if (employee == null)
            {
                return false;
            }

            return true;
        }

        public bool ValidateResult(IEnumerable<Employee> employees)
        {
            if (employees.Count() == 0)
            {
                return false;
            }

            return true;
        }

        public bool ValidateEmployeeToInsert(Employee employee)
        {
            if(employee.Id == Guid.Empty ||
               employee.JobId == Guid.Empty ||
               employee.SectionId == Guid.Empty)
            {
                return false;
            }

            if(employee.FirstName == "" ||
               employee.LastName == "" ||
               employee.PlaceOfBirth =="" ||
               employee.Address == "" ||
               employee.Nationality == "" ||
               employee.PhoneNumber == "" ||
               employee.Email == "" ||
               (employee.Gender != 'M' && employee.Gender!='F') ||
               employee.Salary == 0 ||
               employee.SalaryCurrency == "")
            {
                return false;
            }

            return true;
        }
        #endregion
        #region JobValidators
        public bool ValidateResult(Job job)
        {
            if (job == null)
            {
                return false;
            }

            return true;
        }

        public bool ValidateResult(IEnumerable<Job> job)
        {
            if (job.Count() == 0)
            {
                return false;
            }

            return true;
        }

        public bool ValidateJobToInsert(Job job)
        {
            if(job.Id == Guid.Empty)
            {
                return false;
            }
            if(job.Title == "" || 
               job.Description == "" ||
               job.MinBruteSalary == 0 ||
               job.MaxBruteSalary == 0 ||
               job.Currency == "" ||
               job.MinISCEDLevel == 0 ||
               job.WorkHoursPerMonth == 0||
               job.AnnualPaidLeave == 0)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
