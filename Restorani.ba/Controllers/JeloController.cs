using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restorani.ba.Data;
using Restorani.ba.Models;
using Restorani.ba.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Restorani.ba.Controllers
{
    public class JeloController : Controller
    {
        private readonly ApplicationDbContext _db;
        public JeloController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Stranica sa listom jela
        public IActionResult Index()
        {
            IEnumerable<Jelo> objList = _db.Jela;
            foreach(var obj in objList)
            {
                obj.Restoran = _db.Restorani.FirstOrDefault(u => u.Id == obj.RestoranId);
            }

            return View(objList);
        }

        //Create-GET
        public IActionResult Create()
        {
            JeloVM jeloVM = new JeloVM()
            {
                Jelo = new Jelo(),
                NameDropDown = _db.Restorani.Select(i => new SelectListItem { 
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(jeloVM);
        }

        //Create-POST
        public IActionResult CreatePost(JeloVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Jela.Add(obj.Jelo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
