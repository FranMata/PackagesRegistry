using System.ComponentModel.DataAnnotations;

namespace PackagesRegistry.Models.ViewModels
{
    public class TransportCompanyViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
