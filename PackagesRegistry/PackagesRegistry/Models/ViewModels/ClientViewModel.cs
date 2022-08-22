using System;
using System.ComponentModel.DataAnnotations;

namespace PackagesRegistry.Models.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Cedula")]
        [RegularExpression("[0-9]{9}",
            ErrorMessage = "El numero de cedula no cumple con la loingitud de 9 digitos")]
        public int? DocumentId { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime BirthDate { get; set; }
    }
}
