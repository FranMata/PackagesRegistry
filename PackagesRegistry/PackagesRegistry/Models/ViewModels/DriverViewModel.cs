using System.ComponentModel.DataAnnotations;

namespace PackagesRegistry.Models.ViewModels
{
    public class DriverViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Codigo de la compania")]
        public int CompanyId { get; set; }
    }
}
