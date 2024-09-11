using Company.G01.BLL.interfaces;
using Company.G01.DAL.Data.Contexts;
using Company.G01.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G01.BLL.Repositories
{
    //NOTE : The Create New = CLR
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context; // Default Value = NULL

        //منه object فلازم اعمل Database عشان دي اللي بتتعمامل مع الAppDbContext  مع ال connection من دول لازم افتحfuncation انا لما اعمل اي 

        public DepartmentRepository(AppDbContext context) //ASK CLR Create Object From AppDbContext  --> AppDbContext من create object انه ي CLR هنا طلبت من ال 
        {
            _context = context;
        }
        // NOTE : Constractor بتنفذ ال class من ال create object لما بت


        public IEnumerable<Department> GetAll()
        {
           return _context.Departments.ToList();
        }
        public Department Get(int? id)
        {
            //return _context.Departments.FirstOrDefault(D => D.Id == id);
          return _context.Departments.Find(id);
        }
        public int Add(Department Entity)
        {
             _context.Departments.Add(Entity);
            return _context.SaveChanges();
        }
        public int Update(Department Entity)
        {
            _context.Departments.Update(Entity);
            return _context.SaveChanges();
        }
        public int Delete(Department Entity)
        {
            _context.Departments.Remove(Entity);
            return _context.SaveChanges();
        }
    }
}
