﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPDOTMVCStepByStep.ViewModels;
namespace ASPDOTMVCStepByStep.ViewModels
{
    public class EmployeeListViewModel:BaseViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }
}