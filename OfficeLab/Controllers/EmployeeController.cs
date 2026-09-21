using Microsoft.AspNetCore.Mvc;
using OfficeLab.Services;
using OfficeLab.ViewModels;

namespace OfficeLab.Controllers
{
    public class EmployeeController : Controller
    {
        #region ServicesInjection

        private readonly EmployeeServices _employeeServices;

        public EmployeeController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }


        #endregion

        public IActionResult Index()
        {
            var employee = _employeeServices.GetEmployeeList();
            return View(employee);
        }
        [HttpGet("load-employee-modal-body")]
        public IActionResult LoadEmployeeModalBody(int employeeId)
        {
            var result = _employeeServices.FillCreateOrEditEmployeeViewModel(employeeId);
            return PartialView("_EmployeeMpdalPartial",result);
        }
        [HttpPost("submit-employee-modal")]
        public IActionResult SubmitEmployeeModal(CreateOrEditEmployeeViewModel employeeViewModel)
        {
            var result = _employeeServices.CreateOrEditEmployee(employeeViewModel);
            if (result)
            {
                return new JsonResult(new { status = "Success" });
            }
            return new JsonResult(new { status = "Error" });
        }
        [HttpGet("delete-employee")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            var result = _employeeServices.DeleteEmployee(employeeId);
            if (result)
            {
                return new JsonResult(new { status = "Success" });
            }
            return new JsonResult(new { status = "Error" });
        }
    }
}
