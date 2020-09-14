using ASPDOTMVCStepByStep.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDOTMVCStepByStep.Filters
{
    public class EmployeeExceptionFilter:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            FileLogger logger = new FileLogger();
            logger.RuntimeExceptionLog(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}