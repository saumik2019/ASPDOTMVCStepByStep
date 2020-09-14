using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDOTMVCStepByStep.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            Exception exp = new Exception("Invalid controller or/and action name");
            HandleErrorInfo errorInfo = new HandleErrorInfo(exp, "Unknown", "Unknown");
            return View("Error",errorInfo);
        }
    }
}