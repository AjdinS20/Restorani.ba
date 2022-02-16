using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restorani.ba.Data;
using Restorani.ba.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Restorani.ba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var jela = _db.Jela.ToList();
            if(jela.Count == 0)
            {
                return View();
            }
            else { 
            List<int> pozicije = new List<int>();
            for(int i=0; i<jela.Count; i++)
            {
                pozicije.Add(jela[i].Id);
            }
            Random rand = new Random();
            var pozicija = rand.Next(pozicije.Count);
            var jelo = _db.Jela.Find(pozicije[pozicija]);
            var Restoran = _db.Restorani.Find(jelo.RestoranId);
            Jelo obj = new Jelo();
            obj.Id = jelo.Id;
            obj.Name = jelo.Name;
            obj.Price = jelo.Price;
            obj.Restoran = jelo.Restoran;
            return View(obj);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
