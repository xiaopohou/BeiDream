﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Demo.Service;

namespace BeiDream.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ITaskMange TaskMange;
        public HomeController(ITaskMange taskMang)
        {
            TaskMange = taskMang;
        }

        public ActionResult Index()
        {
            string cc = TaskMange.TaskSave("aa");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}