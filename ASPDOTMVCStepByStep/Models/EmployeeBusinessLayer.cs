using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ASPDOTMVCStepByStep.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL obj = new SalesERPDAL();
            DataSet ds = obj.GetEmployees();
            List<Employee> employees = new List<Employee>();
            Employee emp;
            if(ds != null)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    emp = new Employee();
                    emp.FirstName = dr["FirstName"].ToString();
                    emp.LastName = dr["LastName"].ToString();
                    emp.Salary = Convert.ToInt32(dr["Salary"]);
                    employees.Add(emp);
                }
            }
            return employees;
        }  
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL obj = new SalesERPDAL();
            obj.SaveEmployee(e.FirstName,e.LastName,e.Salary);
            return e;
        }
        public bool IsValidUser(UserDetails u)
        {
            if(u.UserName == "Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UserStatus GetUserValidity(UserDetails user)
        {
            if (user.UserName == "Admin" && user.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (user.UserName == "Saumik" && user.Password == "Saumik")
            {
                return UserStatus.AuthenticatedUser;
            }
            else
                return UserStatus.NonAuthenticatedUser;
        }
        public void UploadEmployees(List<Employee> employees)
        {

        }
    }
}