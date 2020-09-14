using ASPDOTMVCStepByStep.Filters;
using ASPDOTMVCStepByStep.Models;
using ASPDOTMVCStepByStep.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDOTMVCStepByStep.Controllers
{
    
    public class EmployeeController : Controller
    {
        //[Authorize]
        [HeaderFooterFilter]
        public ActionResult Index()
        {            
            EmployeeListViewModel vmEmpLstView = new EmployeeListViewModel();
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            List<Employee> empList = ebl.GetEmployees();
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();
            foreach(Employee emp in empList)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                empViewModel.SalaryColor = emp.Salary > 50000 ? "yellow" : "green";
                empViewModels.Add(empViewModel);
            }
            vmEmpLstView.Employees = empViewModels;
            //vmEmpLstView.UserName = User.Identity.Name; //"Admin";
            //vmEmpLstView.FooterData = new FooterViewModel();
            //vmEmpLstView.FooterData.CompanyName = "Thinkers Inc.";
            //vmEmpLstView.FooterData.Year = DateTime.Now.Year.ToString();
            return View("Index", vmEmpLstView);
        }
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel objCEVM = new CreateEmployeeViewModel();
            //objCEVM.FooterData = new FooterViewModel();
            //objCEVM.FooterData.CompanyName = "Thinkers Inc.";
            //objCEVM.FooterData.Year = DateTime.Now.Year.ToString();
            return View("CreateEmployee", objCEVM);
        }
        [ChildActionOnly]
        public ActionResult GetAddNewLink()
        {
            if(Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(Employee e, string btnSave)
        {
            switch(btnSave)
            {
                case "Save Employee":
                    if(ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBusLyr = new EmployeeBusinessLayer();
                        empBusLyr.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        //vm.FooterData = new FooterViewModel();
                        //vm.FooterData.CompanyName = "Thinkers Inc.";
                        //vm.FooterData.Year = DateTime.Now.Year.ToString();
                        return View("CreateEmployee",vm);
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}