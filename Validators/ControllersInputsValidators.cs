using HeroMed_API.Entities;
using HeroMed_API.Models;
using HeroMed_API.Models.InsertDTOs;
using Microsoft.AspNetCore.Connections.Features;

namespace HeroMed_API.Validators
{
    public class ControllersInputsValidators
    {
        #region CommonValidators
        public bool ValidateGuid(Guid guid)
        {
            if (Guid.TryParse(guid.ToString(), out _) == false)
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

        #region EntitiesValidator
            #region PatientValidators
        public bool ValidateResult(Patient patient)
        {
            if (patient == null)
            {
                return false;
            }

            return true;
        }

        public bool ValidateResult(IEnumerable<Patient> patients)
        {
            if (patients.Count() == 0)
            {
                return false;
            }

            return true;
        }

        public bool ValidatePatientToInsert(InsertPatientDTO patient)
        {
            if (patient.SalonId == Guid.Empty)
            {
                return false;
            }

            if (patient.FirstName == "" ||
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

        public bool ValidateEmployeeToInsert(InsertEmployeeDTO employee)
        {
            if (employee.JobId == Guid.Empty ||
               employee.SectionId == Guid.Empty)
            {
                return false;
            }

            if (employee.FirstName == "" ||
               employee.LastName == "" ||
               employee.PlaceOfBirth == "" ||
               employee.Address == "" ||
               employee.Nationality == "" ||
               employee.PhoneNumber == "" ||
               employee.Email == "" ||
               (employee.Gender != 'M' && employee.Gender != 'F'))
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

        public bool ValidateJobToInsert(InsertJobDTO job)
        {
            if (job.Title == "" ||
               job.Description == "" ||
               job.MinBruteSalary == 0 ||
               job.MaxBruteSalary == 0 ||
               job.Currency == "" ||
               job.MinISCEDLevel == 0 ||
               job.WorkHoursPerMonth == 0 ||
               job.AnnualPaidLeave == 0)
            {
                return false;
            }

            return true;
        }
        #endregion
            #region SectionValidators
        public bool ValidateResult(Section section)
        {
            if (section == null)
            {
                return false;
            }
            return true;
        }

        public bool ValidateResult(IEnumerable<Section> sections)
        {
            if (sections.Count() == 0)
            {
                return false;
            }

            return true;
        }

        public bool ValidateSectionToInsert(InsertSectionDTO section)
        {
            if (section.Title == "" ||
                section.Description == "" ||
                section.MaximumEmployeesNo == 0)
            {
                return false;
            }

            return true;
        }
        #endregion
            #region UserValidators
        public bool ValidateResult(IEnumerable<User> users)
        {
            if(users.Count() == 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateResult(User user)
        {
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public bool ValidateUserToInsert(InsertUserDTO user)
        {
            if(user.EmployeeId == Guid.Empty)
            {
                return false;
            }



            if(user.Username == "" ||
               user.Password == "")
            {
                return false;
            }

            return true;
        }
        #endregion
            #region SalonValidators
        public bool ValidateResult(IEnumerable<Entities.Salon> salons)
        {
            if(salons.Count() == 0)
            {
                return false;
            }

            return true;
        }

        public bool ValidateResult(Entities.Salon salon)
        {
            if(salon == null)
            {
                return false;
            }
            return true;
        } 

        public bool ValidateSalonToInsert(Entities.Salon salon)
        {
            if(salon.Id == Guid.Empty ||
               salon.SectionId == Guid.Empty)
            {
                return false;
            }
            if(!int.TryParse(salon.Floor.ToString(), out _) ||
               !int.TryParse(salon.Beds.ToString(), out _) ||
               !bool.TryParse(salon.Available.ToString(), out _))

            {
                return false;
            }

            return true;
        }
        #endregion
            #region PatientEmployeeValidators
        public bool ValidateResult(Entities.RelationsEntity.PatientEmployee relation)
        {
            if(relation == null)
            {
                return false;
            }
            return true;
        }

        public bool ValidateResult(IEnumerable<Entities.RelationsEntity.PatientEmployee> relations)
        {
            if(relations.Count() == 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateRelationToInsert(Models.PatientEmployeeDTO relation)
        {
            if(!ValidateGuid(relation.PatientId) ||
               !ValidateGuid(relation.EmployeeId) ||
               relation.PatientId == Guid.Empty || 
               relation.EmployeeId == Guid.Empty)
            {
                return false;
            }

            return true;
        }
            #endregion
        #endregion

    }
}
