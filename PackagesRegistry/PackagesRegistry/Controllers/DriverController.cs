using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackagesRegistry.Models;
using PackagesRegistry.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagesRegistry.Controllers
{
    public class DriverController : Controller
    {
        private readonly PackagesRegistryContext _context;
        public DriverController(PackagesRegistryContext context) => _context = context;

        public IActionResult Index()
        {
            ViewData["TransportCompanies"] = new SelectList(_context.TransportCompanies, "Id", "Name");
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(DriverViewModel driver)
        {
            if (!ModelState.IsValid)
                return View();

            Driver driverEF = new Driver()
            {
                CompanyId = driver.CompanyId
            };

            _context.Add(driverEF);
            _context.SaveChanges();
            return View();            
        }
    }
}
