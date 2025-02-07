﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperHeroDB.Data;
using SuperHeroDB.Models;

namespace SuperHeroDB.Controllers
{
    public class SuperHeroController : Controller
    {
        private ApplicationDbContext _context;
        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CreateController
        public ActionResult Index()
        {
            var heroes = _context.SuperHeroes;
            return View(heroes);
        }

        // GET: CreateController/Details/5
        public ActionResult Details(int heroID)
        {
            var hero = _context.SuperHeroes.Where(h => h.Id == heroID).SingleOrDefault();
            return View(hero);
        }

        // GET: CreateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero hero)
        {
            try
            {
                _context.SuperHeroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details), new { heroId = hero.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateController/Edit/5
        public ActionResult Edit(int heroIndex)
        {
            var hero = _context.SuperHeroes.Where(hero => hero.Id == heroIndex).SingleOrDefault();
            return View(hero);
        }

        // POST: CreateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHero hero)
        {
            try
            {
                _context.SuperHeroes.Update(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details), new { heroId = hero.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateController/Delete/5
        public ActionResult Delete(int heroIndex)
        {
            var hero = _context.SuperHeroes.Where(hero => hero.Id == heroIndex).SingleOrDefault();
            return View(hero);
        }

        // POST: CreateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuperHero hero)
        {
            try
            {
                _context.SuperHeroes.Remove(hero);
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
