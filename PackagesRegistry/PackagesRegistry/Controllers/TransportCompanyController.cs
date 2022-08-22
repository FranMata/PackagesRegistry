using Microsoft.AspNetCore.Mvc;
using PackagesRegistry.Models;
using PackagesRegistry.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagesRegistry.Controllers
{
    public class TransportCompanyController : Controller
    {
        private readonly PackagesRegistryContext _context;
        public TransportCompanyController(PackagesRegistryContext context) => _context = context;

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(TransportCompanyViewModel transportCompany)
        {
            bool isCompanyExists = _context.TransportCompanies.FirstOrDefault(e => e.Name == transportCompany.Name) != null;

            if (!ModelState.IsValid || isCompanyExists)
                return View(transportCompany);

            TransportCompany transportCompanyEF = new TransportCompany()
            {
                Name = transportCompany.Name
            };

            _context.Add(transportCompanyEF);
            _context.SaveChanges();

            return View();
        }
    }
}
