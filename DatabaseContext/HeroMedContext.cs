using HeroMed_API.Entities;
using HeroMed_API.Entities.RelationsEntity;
using HeroMed_API.Repositories.Job;
using Microsoft.EntityFrameworkCore;

namespace HeroMed_API.DatabaseContext
{
    public class HeroMedContext:DbContext
    {
        public HeroMedContext(DbContextOptions<HeroMedContext> options):base(options)
        {
        }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientEmployee> PatientEmployee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SectionData
            modelBuilder.Entity<Section>().HasData(
                    new Section()
                    {
                        Id = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb82"),
                        Title = "Cardiology",
                        Description = "This section deals with diseas related to the heart.",
                        MaximumEmployeesNo = 5
                    },
                    new Section()
                    {
                        Id = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb83"),
                        Title = "Neurology",
                        Description = "This section deals with diseases related to the nervous system.",
                        MaximumEmployeesNo = 3
                    },
                     new Section()
                     {
                         Id = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb84"),
                         Title = "Pneumology",
                         Description = "This section deals with diseases related to the respiratory system.",
                         MaximumEmployeesNo = 6
                     },
                     new Section()
                     {
                         Id = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb85"),
                         Title = "Radiology",
                         Description = "This section deals with radiographs.",
                         MaximumEmployeesNo = 9
                     }
                );
            #endregion
            #region JobData
            modelBuilder.Entity<Job>().HasData(
                    new Job()
                    {
                        Id = Guid.Parse("cdb98091-c8c1-4774-9612-57c4e6fb81f2"),
                        Title = "Nurse",
                        Description = "It usually assists the higher grades and leads to the fulfillment of easy tasks (harvests, vaccines, etc.)",
                        MinBruteSalary = 7094,
                        MaxBruteSalary = 12368,
                        Currency = "RON",
                        MinISCEDLevel = 6,
                        WorkHoursPerMonth = 180,
                        AnnualPaidLeave = 22
                    },
                    new Job()
                    {
                        Id = Guid.Parse("cdb98091-c8c1-4774-9612-57c4e6fb81f3"),
                        Title = "Chemist",
                        Description = "He deals with the inventory and distribution of medicines inside unit.",
                        MinBruteSalary = 4227,
                        MaxBruteSalary = 12614,
                        Currency = "RON",
                        MinISCEDLevel = 6,
                        WorkHoursPerMonth = 180,
                        AnnualPaidLeave = 22
                    },
                    new Job()
                    {
                        Id = Guid.Parse("cdb98091-c8c1-4774-9612-57c4e6fb81f4"),
                        Title = "Primary doctor",
                        Description = "He takes care of heavy tasks. It usually represents the penultimate grade after the department head.",
                        MinBruteSalary = 7000,
                        MaxBruteSalary = 26986,
                        Currency = "RON",
                        MinISCEDLevel = 8,
                        WorkHoursPerMonth = 180,
                        AnnualPaidLeave = 22
                    },
                    new Job()
                    {
                        Id = Guid.Parse("cdb98091-c8c1-4774-9612-57c4e6fb81f5"),
                        Title = "Head of department",
                        Description = "He coordinates the whole department.",
                        MinBruteSalary = 28795,
                        MaxBruteSalary = 29795,
                        Currency = "RON",
                        MinISCEDLevel = 8,
                        WorkHoursPerMonth = 180,
                        AnnualPaidLeave = 22
                    }
                );
            #endregion
            #region EmployeeData
            modelBuilder.Entity<Employee>().HasData(
                    new Employee()
                    {
                        Id = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b620"),
                        FirstName = "Mihai",
                        LastName = "Calugar",
                        Birthdate = new DateTimeOffset(new DateTime(day: 23, month: 3, year: 1978)),
                        EmploymentDate = new DateTimeOffset(new DateTime(day: 20, month: 5, year: 2007)),
                        PlaceOfBirth = "Arges, Pitesti, Strada Mioarei Nr. 1",
                        Nationality = "Romanian",
                        Address = "Arges, Pitesti, Strada Mioarei Nr1",
                        PhoneNumber = "+40712345678",
                        Email = "unemail@gmail.com",
                        Gender = 'M',
                        Salary = 7200,
                        SalaryCurrency = "RON",
                        JobId = Guid.Parse("cdb98091-c8c1-4774-9612-57c4e6fb81f2"),
                        SectionId = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb82"),
                        SeniorityYears = 4,
                        DocumentsPath = "X://ToCompute"
                    },
                    new Employee()
                    {
                        Id = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b621"),
                        FirstName = "George",
                        LastName = "Patrar",
                        Birthdate = new DateTimeOffset(new DateTime(day: 23, month: 3, year: 1968)),
                        EmploymentDate = new DateTimeOffset(new DateTime(day: 20, month: 5, year: 2000)),
                        PlaceOfBirth = "Bucurest, Sectorul 1, O strada nr 3",
                        Nationality = "Romanian",
                        Address = "Arges, Pitesti, Strada Mioarei Nr1",
                        PhoneNumber = "+40723456789",
                        Email = "altemail@gmail.com",
                        Gender = 'M',
                        Salary = 29000,
                        SalaryCurrency = "RON",
                        JobId = Guid.Parse("cdb98091-c8c1-4774-9612-57c4e6fb81f2"),
                        SectionId = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb83"),
                        SeniorityYears = 22,
                        DocumentsPath = "X://ToCompute"
                    },
                    new Employee()
                    {
                        Id = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b622"),
                        FirstName = "Mihai",
                        LastName = "Calugar",
                        Birthdate = new DateTimeOffset(new DateTime(day: 23, month: 3, year: 1978)),
                        EmploymentDate = new DateTimeOffset(new DateTime(day: 20, month: 5, year: 2007)),
                        PlaceOfBirth = "Arges, Pitesti, Strada Mioarei Nr. 1",
                        Nationality = "Romanian",
                        Address = "Arges, Pitesti, Strada Mioarei Nr1",
                        PhoneNumber = "+40712345678",
                        Email = "unemail@gmail.com",
                        Gender = 'M',
                        Salary = 7200,
                        SalaryCurrency = "RON",
                        JobId = Guid.Parse("cdb98091-c8c1-4774-9612-57c4e6fb81f3"),
                        SectionId = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb84"),
                        SeniorityYears = 4,
                        DocumentsPath = "X://ToCompute"
                    },
                    new Employee()
                    {
                        Id = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b600"),
                        FirstName = "admin",
                        LastName = "admin",
                        Birthdate = new DateTimeOffset(new DateTime(day: 1, month: 1, year:2000)),
                        EmploymentDate = new DateTimeOffset(new DateTime(day: 1, month: 1, year: 2000)),
                        PlaceOfBirth = " ",
                        Nationality = " ",
                        Address = " ",
                        PhoneNumber = "+40751862506",
                        Email = "remusene69@gmail.com",
                        Gender = ' ',
                        Salary = 0,
                        SalaryCurrency = "RON",
                        JobId = Guid.Parse("cdb98091-c8c1-4774-9612-57c4e6fb81f3"),
                        SectionId = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb84"),
                        SeniorityYears = 10,
                        DocumentsPath = "X://ToCompute"
                    }
                );
            #endregion
            #region UserData
            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = Guid.Parse("1fdbe311-ac30-4a06-be2c-0fcc779b9246"),
                        Username = "admin",
                        Password = "admin",
                        CreatedDate = DateTimeOffset.Now,
                        Admin = true,
                        EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b600")
                    },
                    new User()
                    {
                        Id = Guid.Parse("1fdbe311-ac30-4a06-be2c-0fcc779b9247"),
                        Username = "UnUSername",
                        Password = "OParola",
                        CreatedDate = DateTimeOffset.Now,
                        Admin = false,
                        EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b620")
                    }, 
                    new User()
                    {
                        Id = Guid.Parse("1fdbe311-ac30-4a06-be2c-0fcc779b9248"),
                        Username = "AltUSername",
                        Password = "AltaParola",
                        CreatedDate = DateTimeOffset.Now,
                        Admin = false,
                        EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b621")
                    }
                );
            #endregion
            #region SalonData
            modelBuilder.Entity<Salon>().HasData(
                new Salon()
                {
                    Id = Guid.Parse("46589e47-e79f-417f-9e1a-410dd719f0e6"),
                    Floor = 2,
                    Beds = 4,
                    Available = true,
                    SectionId = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb82"),
                },
                new Salon()
                {
                    Id = Guid.Parse("46589e47-e79f-417f-9e1a-410dd719f0e7"),
                    Floor = 1,
                    Beds = 3,
                    Available = true,
                    SectionId = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb83") 
                },
                new Salon()
                {
                    Id = Guid.Parse("46589e47-e79f-417f-9e1a-410dd719f0e8"),
                    Floor = 1,
                    Beds = 4,
                    Available = true,
                    SectionId = Guid.Parse("10261ba6-d3f9-48bb-b48f-12bf7a43bb83")
                }
                );
            #endregion
            #region PatientData
            modelBuilder.Entity<Patient>().HasData(
                new Patient()
                {
                    Id = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08742"),
                    FirstName = "Mircea",
                    LastName = "Popa",
                    BirthDate = new DateTimeOffset(new DateTime(year: 1999, month: 6, day: 13)),
                    Address = "Str. Nicolae Balcescu, Nr. 189, Blc. L6, Sc. A, Ap. 20",
                    Email = "mircea.popa@gmail.com",
                    PhoneNumber = "0751234567",
                    EmergencyContactName = "Rares Popa",
                    EmergencyContactPhoneNumber = "0752345678",
                    SalonId = Guid.Parse("46589e47-e79f-417f-9e1a-410dd719f0e8"),
                    IssueDetails = "Some disease details.",
                    EnrolledDate = new DateTimeOffset(new DateTime(year: 2022, month:11, day:28)),
                    DischargeDate = new DateTimeOffset(new DateTime(year: 2022, month:12, day: 3))
                },
                new Patient()
                {
                    Id = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08743"),
                    FirstName = "Radu",
                    LastName = "Voicu",
                    BirthDate = new DateTimeOffset(new DateTime(year: 1997, month: 3, day: 11)),
                    Address = "Str. Nicolae Balcescu, Nr. 1, Blc. L4, Sc. B, Ap. 14",
                    Email = "mircea.popa@gmail.com",
                    PhoneNumber = "0752234567",
                    EmergencyContactName = "Rares Voicu",
                    EmergencyContactPhoneNumber = "0752345123",
                    SalonId = Guid.Parse("46589e47-e79f-417f-9e1a-410dd719f0e8"),
                    IssueDetails = "Some disease details. 2",
                    EnrolledDate = new DateTimeOffset(new DateTime(year: 2022, month: 11, day: 28)),
                    DischargeDate = new DateTimeOffset(new DateTime(year: 2022, month: 12, day: 3))
                },
                new Patient()
                {
                    Id = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08744"),
                    FirstName = "Mircea2",
                    LastName = "Popa2",
                    BirthDate = new DateTimeOffset(new DateTime(year: 2001, month: 6, day: 13)),
                    Address = "Str. Nicolae Balcescu, Nr. 189, Blc. L6, Sc. A, Ap. 20",
                    Email = "mircea.popa@gmail.com",
                    PhoneNumber = "0751232222",
                    EmergencyContactName = "Rares Popa",
                    EmergencyContactPhoneNumber = "0758765432",
                    SalonId = Guid.Parse("46589e47-e79f-417f-9e1a-410dd719f0e8"),
                    IssueDetails = "Some disease details.",
                    EnrolledDate = new DateTimeOffset(new DateTime(year: 2022, month: 11, day: 28)),
                    DischargeDate = new DateTimeOffset(new DateTime(year: 2022, month: 12, day: 3))
                }
                );
            #endregion
            #region PatientEmployeeData
            modelBuilder.Entity<PatientEmployee>()
                .HasKey(pe => new { pe.PatientId, pe.EmployeeId });
            
            modelBuilder.Entity<PatientEmployee>()
                .HasOne(pe => pe.Patient)
                .WithMany(e => e.PatientEmployees)
                .HasForeignKey(pe => pe.PatientId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<PatientEmployee>()
                .HasOne(pe => pe.Employee)
                .WithMany(p => p.EmployeePatients)
                .HasForeignKey(pe => pe.EmployeeId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<PatientEmployee>().HasData(
                new PatientEmployee()
                {
                    EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b620"),
                    PatientId = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08742")
                },
                new PatientEmployee()
                {
                    EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b621"),
                    PatientId = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08742")
                },
                new PatientEmployee()
                {
                    EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b622"),
                    PatientId = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08742")
                },
                new PatientEmployee()
                {
                    EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b621"),
                    PatientId = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08743")
                },
                new PatientEmployee()
                {
                    EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b620"),
                    PatientId = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08743")
                },
                new PatientEmployee()
                {
                    EmployeeId = Guid.Parse("0b273992-95bd-4baf-b298-92355f67b620"),
                    PatientId = Guid.Parse("7b7e16ec-2672-4360-ad3d-4941d5d08744")
                }
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
