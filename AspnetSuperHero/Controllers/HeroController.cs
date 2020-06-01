using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetSuperHero.Data;
using AspnetSuperHero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AspnetSuperHero.Controllers
{
    public class HeroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hero
        public ActionResult Index()
        {
            var hero = _context.Heros.ToList();
            return View(hero);
        }

        // GET: Hero/Details/5
        public ActionResult Details(int id)
        {
            var hero = _context.Heros.Where(h => h.Id == id).SingleOrDefault();
            return View(hero);
        }

        // GET: Hero/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Hero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero hero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Heros.Add(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            var hero = _context.Heros.Where(h => h.Id == id).SingleOrDefault();
            return View(hero);
        }

        // POST: Hero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero hero)
        {
            try
            {
                // TODO: Add update logic here
                var superHeroFromDb = _context.Heros.Where(s => s.Id == id).SingleOrDefault();
                superHeroFromDb.Name = hero.Name;
                superHeroFromDb.AlterEgo = hero.AlterEgo;
                superHeroFromDb.PrimaryAbility = hero.PrimaryAbility;
                superHeroFromDb.SecondaryAbility = hero.SecondaryAbility;
                superHeroFromDb.CatchPhrase = hero.CatchPhrase;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            var hero = _context.Heros.Where(h => h.Id == id).SingleOrDefault();
            return View(hero);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero hero)
        {
            try
            {
                // TODO: Add delete logic here
                
                _context.Heros.Remove(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}