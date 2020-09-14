using ASPDOTMVCStepByStep.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDOTMVCStepByStep.Filters
{
    public class HeaderFooterFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                ViewResult viewResult = (ViewResult)filterContext.Result;
                if (viewResult.Model is BaseViewModel)
                {
                    BaseViewModel bvm = (BaseViewModel)viewResult.Model;
                    bvm.UserName = HttpContext.Current.User.Identity.Name;
                    bvm.FooterData = new FooterViewModel
                    {
                        CompanyName = "Chakraborty & Co.",
                        Year = DateTime.Now.Year.ToString()
                    };
                }
            }
        }
    }
}