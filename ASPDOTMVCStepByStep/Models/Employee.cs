using ASPDOTMVCStepByStep.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPDOTMVCStepByStep.Models
{
    public class Employee
    {
        [FirstNameValidation]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(5,ErrorMessage = "Last Name length should not be bigger than 5")]
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}