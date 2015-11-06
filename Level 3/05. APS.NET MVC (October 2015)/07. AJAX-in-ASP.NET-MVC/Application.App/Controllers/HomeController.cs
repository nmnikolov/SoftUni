using AutoMapper;
using SoftUni.Blog.App.Models.ViewModels;
using SoftUni.Blog.Data.UnitOfWork;
using SoftUni.Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftUni.Blog.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.RedirectToAction("Index", "Users");
        }
    }
}