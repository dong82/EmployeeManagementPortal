﻿using System;
using System.Collections.Generic;

namespace EMP.DbScaffold.Models.Employees
{
    public partial class DeptEmpCurrent
    {
        public int EmpNo { get; set; }
        public string DeptNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
