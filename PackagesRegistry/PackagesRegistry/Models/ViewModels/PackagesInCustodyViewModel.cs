using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PackagesRegistry.Models.ViewModels
{
    public class PackagesInCustodyViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Codigo del conductor")]
        public int? DriverId { get; set; }
        [Required]
        [Display(Name = "Numero de Tracking")]
        [RegularExpression("[0-9a-zA-Z]{18}",
            ErrorMessage = "El numero de tracking no cumple con la longitud de 18 carecteres")]
        public string TrackingId { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Peso en kilogramos")]
        public double? Weight { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public double? Price { get; set; }
        [Required]
        [Display(Name = "Codigo del cliente")]
        public int? ClientId { get; set; }
        [Required]
        [Display(Name = "Fecha de ingreso")]
        public DateTime Date { get; set; }
    }
}
