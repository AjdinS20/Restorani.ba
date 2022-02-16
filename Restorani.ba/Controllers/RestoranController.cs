using Microsoft.AspNetCore.Mvc;
using Restorani.ba.Data;
using Restorani.ba.Models;
using System.Collections;
using System.Collections.Generic;

namespace Restorani.ba.Controllers
{
    public class RestoranController : Controller
    {

        private readonly ApplicationDbContext _db;
        public RestoranController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Restoran> objList = _db.Restorani;

            return View(objList);
        }

        //Create-GET
        public IActionResult Create() { return View(); }
        //Create-POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Restoran obj) {
            _db.Restorani.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
