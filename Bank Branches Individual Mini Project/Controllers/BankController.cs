using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Branches_Individual_Mini_Project.Controllers
{
    public class BankController : Controller
    {

        public IActionResult Index()
        {
            using (var context = new BankContext())
            {
                var data = context.BankBranches.ToList();
                return View(data);
            }
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
                using (var context = new BankContext())
                {
                    context.BankBranches.Add(newBranch);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            // If the form data is not valid, return the view with the form data to correct any validation errors
            return View(form);

        }

        public IActionResult Details(int id)
        {

            using (var context = new BankContext())
            {
                var data = context.BankBranches.ToList();
                var branch = data.SingleOrDefault(a => a.Id == id);
                if (branch == null)
                {
                    return RedirectToAction("Index");
                }
                return View(branch);
            }
        }
        public IActionResult Search(string search)
        {
            using (var context = new BankContext())
            {
                var branches = context.BankBranches.AsQueryable();

                if (!string.IsNullOrEmpty(search))
                {
                    branches = branches.Where(b => b.Name.StartsWith(search));
                }

                var data = branches.ToList();
                return View("Index", data);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var context = new BankContext())
            {
                var data = context.BankBranches.FirstOrDefault(b => b.Id == id);
                if (data == null)
                {
                    return RedirectToAction("Index");
                }
                return View(data);
            }
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
                using (var context = new BankContext())
                {
                    context.Update(data);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(data);
        }
    }

}

