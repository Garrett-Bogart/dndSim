﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dndSim.Models.Heroes.Barbarians;

namespace dndSim.Controllers
{
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCharacters()
        {
            List<Barbarian> barbs = new List<Barbarian>();
            barbs.Add(new Barbarian());
            barbs.Add(new Barbarian());
            barbs.Add(new Barbarian());

            return View(barbs);
        }
    }
}