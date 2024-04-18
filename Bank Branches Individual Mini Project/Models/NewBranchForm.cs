using System.ComponentModel.DataAnnotations;

namespace Bank_Branches_Individual_Mini_Project.Models
{
    public class NewBranchForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string BranchManager { get; set; }
        [Required]
        public int EmployeeCount { get; set; }
    }
}
