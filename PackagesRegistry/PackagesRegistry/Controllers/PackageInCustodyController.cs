using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PackagesRegistry.Models;
using PackagesRegistry.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagesRegistry.Controllers
{
    public class PackageInCustodyController : Controller
    {
        private readonly PackagesRegistryContext _context;
        public PackageInCustodyController(PackagesRegistryContext context) => _context = context;

        public IActionResult Index()
        {
            ViewData["DriversCode"] = new SelectList(_context.Drivers, "Id", "Id");
            ViewData["ClientsCode"] = new SelectList(_context.Clients, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Index(PackagesInCustodyViewModel packagesInCustody)
        {
            if (!ModelState.IsValid)
            {
                ViewData["DriversCode"] = new SelectList(_context.Drivers, "Id", "Id", packagesInCustody.DriverId);
                ViewData["ClientsCode"] = new SelectList(_context.Clients, "Id", "Name", packagesInCustody.ClientId);
                return View(packagesInCustody);
            }

            PackagesInCustody packagesInCustodyEF = new PackagesInCustody()
            {
                DriverId = packagesInCustody.DriverId,
                TrackingId = packagesInCustody.TrackingId,
                Description = packagesInCustody.Description,
                Weight = packagesInCustody.Weight,
                Price = packagesInCustody.Price,
                ClientId = packagesInCustody.ClientId,
                Date = packagesInCustody.Date.ToShortDateString()
            };

            _context.Add(packagesInCustodyEF);
            _context.SaveChanges();
            return View();
        }

        public IActionResult PackagesInCustodyList()
        {
            List<PackagesInCustody> packages = _context
                .PackagesInCustodies
                .Include(e => e.Client)
                .ToList();
            return View(packages);
        }        
    }
}
