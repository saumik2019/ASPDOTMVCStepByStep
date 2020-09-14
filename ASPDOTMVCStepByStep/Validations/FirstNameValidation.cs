using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPDOTMVCStepByStep.Validations
{
    public class FirstNameValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            if(value == null)
            {
                return new ValidationResult("Please provide first name.");
            }
            else
            {
                if(value.ToString().Contains("@"))
                {
                    return new ValidationResult("First name should not contain @.");
                }
            }
            return ValidationResult.Success;
        }
    }
}