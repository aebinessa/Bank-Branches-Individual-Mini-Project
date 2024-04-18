using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Branches_Individual_Mini_Project.Controllers
{
    public class BankController : Controller
    {
         static List<BankBranch> bankBranches = [
            new BankBranch {Id = 1, Name = "Khaldiya", Location = "https://maps.app.goo.gl/s2aCpoGSUFZHa4KS8", BranchManager = "Majed", EmployeeCount = 4 },
            new BankBranch {Id = 2, Name = "Mansouriya", Location = "https://maps.app.goo.gl/N1AwujroTFMhVbVj9", BranchManager = "Ahmad", EmployeeCount = 3 },
            new BankBranch {Id = 3, Name = "Mubarak alabdullah", Location = "https://maps.app.goo.gl/tj68JVQLDMpV5qy36", BranchManager = "Yousef", EmployeeCount = 5 },
            new BankBranch {Id = 4, Name = "Bayan", Location = "https://maps.app.goo.gl/ZSjtp3nd7osXhrnj6", BranchManager = "Khaled", EmployeeCount = 2 },
            new BankBranch {Id = 5, Name = "Alkhairan", Location = "https://maps.app.goo.gl/Vs8SvonaeaJUsqNn8", BranchManager = "Hamad", EmployeeCount = 7 },

            ];
        public IActionResult Index()
        {
            return View(bankBranches);
        }
        [HttpGet]
        public IActionResult AddBranch() {  
            return View(); 
        }
        [HttpPost]
        public IActionResult AddBranch(NewBranchForm form)
        {
            if (ModelState.IsValid)
            {
                bankBranches.Add(new BankBranch {Id= bankBranches.Max(r=> r.Id)+1, Name = form.Name, Location = form.Location, BranchManager = form.BranchManager, EmployeeCount = form.EmployeeCount });
            }
            else
            {
                return View(form);
            }

                return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {


            var branch = bankBranches.SingleOrDefault(a => a.Id == id);
            if (branch == null)
            {
                return RedirectToAction("Index");
            }
            return View(branch);

        }
    }
}
