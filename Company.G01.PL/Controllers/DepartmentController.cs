using Company.G01.BLL.interfaces;
using Company.G01.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.G01.PL.Controllers
{
    public class DepartmentController : Controller
    {


        private readonly IDepartmentRepository _departmentRepository; //NULL --> GetAll دي عشان اجيب منها الميثود اللي اسمها property انا عملت ال
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentRepository departmentRepository , IWebHostEnvironment environment) // ASK CLR To Create Object From DepartmentRepository
        {
            _departmentRepository = departmentRepository;
            _environment = environment;
        }




        //Data base مع ال connection فلازم افتح Data base ده هعرض فيه كل حاجه موجوده في ال view ال
        public IActionResult Index()
        {
            var department = _departmentRepository.GetAll();
            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentRepository.Add(model);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
                return View(model);          
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
          var department =  _departmentRepository.Get(id.Value);
            if (department is null) return NotFound();
                   return View(department);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
                return View(department);

            try
            {
                _departmentRepository.Update(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty,ex.Message);
                } 
                else
                {
                    ModelState.AddModelError(string.Empty, " An Error Occured During Update Department");
                }

            }
            return View(department);

        }

        public IActionResult Delete(int? id)
        {
            return Details(id);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            try
            {
                _departmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, " An Error Occured During Deleting Department");
                }
                return View(department);
            }

        }
    }
}
