using Microsoft.Identity.Client;
using OfficeLab.EFCoreDbContext;
using OfficeLab.Models;
using OfficeLab.ViewModels;

namespace OfficeLab.Services
{
    public class EmployeeServices
    {
        #region DbContextInjection

        private readonly OfficeLabDbContext _context;

        public EmployeeServices(OfficeLabDbContext context)
        {
            _context = context;
        }

        #endregion

        #region CreateOrEditService

        public bool CreateOrEditEmployee(CreateOrEditEmployeeViewModel createOrEdit)
        {
            if (createOrEdit.EmployeeId == 0)
            {
                var add = new Employee()
                {
                    EmployeeName = createOrEdit.EmployeeName,
                    EmployeeFamily = createOrEdit.EmployeeFamily,
                    NationalCode = createOrEdit.NationalCode,
                    PhoneNumber = createOrEdit.PhoneNumber,
                    EmployeeBirthday = createOrEdit.EmployeeBirthday,
                    StartWork = createOrEdit.StartWork
                };
                _context.Add(add);
                _context.SaveChanges();
                return true;
            }

            var employee = _context.Employees.FirstOrDefault(q => q.EmployeeId == createOrEdit.EmployeeId && !q.IsDeleted);
            if (employee == null)
            {
                return false;
            }

            employee.EmployeeName = createOrEdit.EmployeeName;
            employee.EmployeeFamily = createOrEdit.EmployeeFamily;
            employee.EmployeeBirthday = createOrEdit.EmployeeBirthday;
            employee.NationalCode = createOrEdit.NationalCode;
            employee.PhoneNumber = createOrEdit.PhoneNumber;

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return true;
        }

        #endregion

        #region FillCreateOrEditEmployeeViewModel

        public CreateOrEditEmployeeViewModel FillCreateOrEditEmployeeViewModel(int employeeId)
        {
            if (employeeId == 0)
            {
                return new CreateOrEditEmployeeViewModel()
                {
                    EmployeeId = 0
                };
            }

            var employee = _context.Employees.FirstOrDefault(q => q.EmployeeId == employeeId && !q.IsDeleted);
            
                if (employee == null)
                {
                    return null;
                }

                return new CreateOrEditEmployeeViewModel()
                {
                    EmployeeName = employee.EmployeeName,
                    EmployeeFamily = employee.EmployeeFamily,
                    NationalCode = employee.NationalCode,
                    EmployeeBirthday = employee.EmployeeBirthday,
                    StartWork = employee.StartWork,
                    EmployeeId = employee.EmployeeId,
                    PhoneNumber = employee.PhoneNumber
                };
        }
        

        #endregion

        public List<Employee> GetEmployeeList()
        {
            return _context.Employees.Where(q => !q.IsDeleted).ToList();
        }

        public bool DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(q => q.EmployeeId == employeeId && !q.IsDeleted);
            if (employee == null)
            {
                return false;
            }
            employee.IsDeleted=true;
            _context.Update(employee);
            _context.SaveChanges();
            return true;
        }
    }
}
