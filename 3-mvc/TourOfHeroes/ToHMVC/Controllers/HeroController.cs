using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToHBL;
using ToHMVC.Models;

namespace ToHMVC.Controllers
{
    public class HeroController : Controller
    {
        private IHeroBL _heroBL;
        private IMapper _mapper;
        public HeroController(IHeroBL heroBL, IMapper mapper)
        {
            _heroBL = heroBL;
            _mapper = mapper;
        }
        //Actions are public methods in controllers that respond to client requests
        //You can have specific actions respond to specific requests
        // you can also have actions, that respond to different requests
        //You just have to map the request type to the action properly
        // GET: HeroController
        public ActionResult Index()
        {
            //You have different kinds of views:
            //Strongly-typed - tied to a model
            //Weakly-typed - not tied to a model. gets data via viewbag, viewdata, tempdata, etc.
            // Dynamic - pass a model, don't tie to a view, let the view figure it out, 
                //(do some further research into this)
            //Let's create a strongly typed view:
            return View(_heroBL.GetHeroes().Select(hero => _mapper.cast2HeroIndexVM(hero)).ToList());
        }

        // GET: HeroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HeroController/Create
        public ActionResult Create()
        {
            return View("CreateHero");
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HeroCRVM newHero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _heroBL.AddHero(_mapper.cast2Hero(newHero));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }

            }
            return View();
            
        }

        // GET: HeroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
