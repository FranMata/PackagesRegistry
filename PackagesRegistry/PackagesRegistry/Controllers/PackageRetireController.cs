using Microsoft.AspNetCore.Mvc;
using PackagesRegistry.Models;
using PackagesRegistry.Models.ViewModels;
using System;
using System.Linq;

namespace PackagesRegistry.Controllers
{
    public class PackageRetireController : Controller
    {
        private readonly PackagesRegistryContext _context;
        public PackageRetireController(PackagesRegistryContext context) => _context = context;

        public IActionResult Index() => View();
        
        private PackagesInCustody _GetPackagesInCustody(int id) => _context.PackagesInCustodies.FirstOrDefault(e => e.Id == id);

        [HttpGet]
        public IActionResult GetPackage(int id)
        {
            PackagesInCustody packagesInCustody = _GetPackagesInCustody(id);

            if (packagesInCustody == null)
                return StatusCode(404);

            PackagesRetiredViewModel packageToRetire = new PackagesRetiredViewModel()
            {
                DriverId = (int)packagesInCustody.DriverId,
                TrackingId = packagesInCustody.TrackingId,
                Description = packagesInCustody.Description,
                ClientId = (int)packagesInCustody.ClientId,
                ReiredDate = DateTime.Now.ToShortDateString()
            };
            return Json(packageToRetire);
        }

        [HttpPost]
        public IActionResult Index(PackagesRetiredViewModel packagesRetired)
        {
            PackagesInCustody packagesInCustody = _GetPackagesInCustody(packagesRetired.Id);

            PackagesRetired packagesRetiredEF = new PackagesRetired()
            {
                DriverId = (int)packagesRetired.DriverId,
                TrackingId = packagesRetired.TrackingId,
                Description = packagesRetired.Description,
                ClientId = (int)packagesRetired.ClientId,
                ReiredDate = DateTime.Now.ToShortDateString()
            };

            _context.Remove(packagesInCustody);
            _context.Add(packagesRetiredEF);
            _context.SaveChanges();
            return View();
        }
    }
}
