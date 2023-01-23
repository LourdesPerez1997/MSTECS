using Microsoft.AspNetCore.Mvc;
using MSTECS.Models;
using MSTECS.Models.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace MSTECS.Controllers
{
    public class HomeController : Controller
    {
        private readonly MstecsContext _DBContext;

        public HomeController(MstecsContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Client> list = _DBContext.Clients.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Client_Detail(int ClientId)
        {
            ClientVM oClientVM = new ClientVM()
            {
                oClient = new Client()

            };

            if (ClientId != 0)
            {
                oClientVM.oClient = _DBContext.Clients.Find(ClientId);
            }
            return View(oClientVM);
        }

        [HttpPost]
        public IActionResult Client_Detail1(ClientVM oClientVM)
        {
            if (oClientVM.oClient.ClientId == 0)
            {
                _DBContext.Clients.Add(oClientVM.oClient);
            }
            else
            {
                _DBContext.Clients.Update(oClientVM.oClient);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int ClientId)
        {
            Client oClient = _DBContext.Clients.Where(e => e.ClientId == ClientId).FirstOrDefault();
            return View(oClient);
        }

        [HttpPost]
        public IActionResult Eliminar(Client oClient)
        {
            _DBContext.Clients.Remove(oClient);
            _DBContext.SaveChanges();
            return View(oClient);
        }
        public IActionResult Invoice()
        {

            return View();
        }
        public IActionResult Products()
        {

            return View();
        }
    }
}