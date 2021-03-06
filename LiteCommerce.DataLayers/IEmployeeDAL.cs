﻿using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IEmployeeDAL
    {
        List<Employee> List(int page, int pageSize, string searchValue);
        int Count(string searchValue);
        Employee Get(int EmployeeID);
        int Add(Employee data);
        bool Update(Employee data);
        int Detele(int[] employeeIDs);
        bool ChangePassword(int id, string password, string nPassword, string nlPassword);
    }
}