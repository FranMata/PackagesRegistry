using System.ComponentModel.DataAnnotations;

namespace PackagesRegistry.Models.ViewModels
{
    public class PackagesRetiredViewModel
    {
        [Display(Name = "Id del paquete")]
        public int Id { get; set; }
        [Display(Name = "Codigo del conductor")]
        public int? DriverId { get; set; }    
        [Display(Name = "Numero de Tracking")]
        [RegularExpression("[0-9a-zA-Z]{18}",
            ErrorMessage = "El numero de tracking no cumple con la longitud de 18 carecteres")]
        public string TrackingId { get; set; }
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Display(Name = "Codigo del cliente")]
        public int? ClientId { get; set; }
        [Display(Name = "Fecha de ingreso")]
        public string ReiredDate { get; set; }
    }
}
