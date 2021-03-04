﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        // GET: HeroController/Details?name={heroName}
        public ActionResult Details(string name)
        {
            return View(_mapper.cast2HeroCRVM(_heroBL.GetHeroByName(name)));
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
        public ActionResult Edit(string name)
        {
            return View(_mapper.cast2HeroEditVM(_heroBL.GetHeroByName(name)));
        }

        // POST: HeroController/Edit/
        //Model Binding: bind an action/view to a model, and apply the validation logic stated in model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HeroEditVM hero2BUpdated)
        {
            //Model state is valid literally means model data is valid
            //you're just checking if the data that you're receiving client side complies with the 
            // validation you set for the model 

            if (ModelState.IsValid)
            {
                try
                {
                    _heroBL.UpdateHero(_mapper.cast2Hero(hero2BUpdated));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: HeroController/Delete/{hero name}
        public ActionResult Delete(string name)
        {
            _heroBL.DeleteHero(_heroBL.GetHeroByName(name));
            return RedirectToAction(nameof(Index));
        }
    }
}