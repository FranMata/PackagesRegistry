using Microsoft.AspNetCore.Mvc;
using PackagesRegistry.Models;
using PackagesRegistry.Models.ViewModels;
using System.Linq;

namespace PackagesRegistry.Controllers
{
    public class ClientController : Controller
    {
        private readonly PackagesRegistryContext _context;
        public ClientController(PackagesRegistryContext context) => _context = context;
        public IActionResult Index() => View();
        
        [HttpPost]
        public IActionResult Index(ClientViewModel client)
        {
            bool isClientExist = _context.Clients.FirstOrDefault(e => e.Name == client.Name) != null;

            if (!ModelState.IsValid || isClientExist)
                return View();

            Client clientEF = new Client()
            {
                Name = client.Name,
                DocumentId = client.DocumentId,
                BirthDate = client.BirthDate.ToShortDateString()
            };

            _context.Add(clientEF);
            _context.SaveChanges();
            return View();
        }
    }
}