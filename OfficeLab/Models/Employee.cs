namespace OfficeLab.Models
{
    public class Employee
    {
        public Employee(string employeeName, string employeeFamily, int nationalCode, int phoneNumber, DateTime employeeBirthday)
        {
            EmployeeName = employeeName;
            EmployeeFamily = employeeFamily;
            NationalCode = nationalCode;
            PhoneNumber = phoneNumber;
            EmployeeBirthday = employeeBirthday;
            StartWork = DateTime.Now;
            IsDeleted=false;
        }

        public int EmployeeId { get; private set; }
        public string EmployeeName { get; private set; }
        public string EmployeeFamily { get; private set; }
        public DateTime StartWork { get; private set; }
        public bool IsDeleted { get; private set; }
        public int NationalCode { get; private set; }
        public int PhoneNumber { get; private set; }
        public DateTime EmployeeBirthday { get; private set; }

    }
}
