﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.Payroll;

public class CreatePayrollDto
{
    public int EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PayDate { get; set; }
}
