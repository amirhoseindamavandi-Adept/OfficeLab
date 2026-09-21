namespace OfficeLab.ViewModels
{
    public class CreateOrEditEmployeeViewModel
    {
        public int EmployeeId { get;  set; }
        public string EmployeeName { get;  set; }
        public string EmployeeFamily { get;  set; }
        public DateOnly StartWork { get;  set; }
        public int NationalCode { get;  set; }
        public int PhoneNumber { get;  set; }
        public DateOnly EmployeeBirthday { get;  set; }
    }
}
