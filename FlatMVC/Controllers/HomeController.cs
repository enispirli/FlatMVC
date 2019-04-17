﻿using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatMVC.Controllers
{
    public class HomeController : Controller
    {
        FlatContext db = new FlatContext();
        General _settings;

        public HomeController()
        {
            _settings = db.General.FirstOrDefault();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Menu()
        {
            return View(_settings);
        }

        public ActionResult _Header()
        {
            return View(_settings);
        }

        public ActionResult _LatestWorks()
        {
           
            return View(db.Works.ToList());
        }

        public ActionResult _CTA1()
        {
            return View();
        }

        public ActionResult _WhatWeDo()
        {
            return View();
        }

        public ActionResult _CTA2()
        {
            return View();
        }

        public ActionResult _Contact()
        {
            return View();
        }

        public ActionResult _Footer()
        {
            return View();
        }
    }
}