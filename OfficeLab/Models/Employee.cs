namespace OfficeLab.Models
{
    public class Employee
    {
        public Employee(string employeeName, string employeeFamily, int nationalCode, int phoneNumber, DateOnly employeeBirthday)
        {
            EmployeeName = employeeName;
            EmployeeFamily = employeeFamily;
            NationalCode = nationalCode;
            PhoneNumber = phoneNumber;
            EmployeeBirthday = employeeBirthday;
            StartWork = DateOnly.FromDateTime(DateTime.Now);
            IsDeleted=false;
        }

        public Employee()
        {
        }

        public int EmployeeId { get;  set; }
        public string EmployeeName { get;  set; }
        public string EmployeeFamily { get;  set; }
        public DateOnly StartWork { get;  set; }
        public bool IsDeleted { get;  set; }
        public int NationalCode { get;  set; }
        public int PhoneNumber { get;  set; }
        public DateOnly EmployeeBirthday { get;  set; }

    }
}
