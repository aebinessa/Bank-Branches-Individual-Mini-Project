using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank_Branches_Individual_Mini_Project.Controllers
{
    public class BankController : Controller
    {
        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            var data = _context.BankBranches.ToList();
            return View(data);

        }
        [HttpGet]
        public IActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBranch(NewBranchForm form)
        {
            if (ModelState.IsValid)
            {
                // Create a new BankBranch object with data from the form
                var newBranch = new BankBranch
                {
                    Name = form.Name,
                    Location = form.Location,
                    BranchManager = form.BranchManager,
                    EmployeeCount = form.EmployeeCount
                };

                // Add the new branch to the database


                _context.BankBranches.Add(newBranch);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }

            // If the form data is not valid, return the view with the form data to correct any validation errors
            return View(form);

        }

        public IActionResult Details(int id)
        {



            var data = _context.BankBranches.ToList();
            var employee = _context.BankBranches.Include(r => r.Employees).SingleOrDefault(a => a.Id == id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);

        }
        public IActionResult Search(string search)
        {

            var branches = _context.BankBranches.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                branches = branches.Where(b => b.Name.StartsWith(search));
            }

            var data = branches.ToList();
            return View("Index", data);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {


            var data = _context.BankBranches.FirstOrDefault(b => b.Id == id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(int id, BankBranch data)
        {
            if (id != data.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {

                _context.Update(data);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(data);
        }

        [HttpGet]
        public IActionResult AddEmployee(int id)
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(int id, AddEmployeeForm employeeForm)
        {
            if (ModelState.IsValid)
            {

                if (_context.Employees.Any(e => e.CivilId == employeeForm.CivilId))
                {
                    ModelState.AddModelError("CivilId", "Employee with this Civil ID already exists.");
                    return View(employeeForm);
                }
                var branch = _context.BankBranches.Find(id);
                var newEmployee = new Employee();
                newEmployee.Name = employeeForm.Name;
                newEmployee.Position = employeeForm.Position;
                newEmployee.CivilId = employeeForm.CivilId;
                branch.Employees.Add(newEmployee);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(employeeForm);
        }
    }
}



