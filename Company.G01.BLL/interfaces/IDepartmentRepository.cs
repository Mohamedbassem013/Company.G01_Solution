﻿using Company.G01.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G01.BLL.interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(); //Department دي بتجيب كل ال
        Department Get(int? id); //بتاعه id من خلال ال Department دي بتجيب كل ال

        int Add(Department Entity);
        int Update (Department Entity);
        int Delete(Department Entity);
    }
}
