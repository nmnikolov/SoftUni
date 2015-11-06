using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.Web.Controllers
{
    using Data;

    public class TestController : BaseController
    {
        public TestController()
            : this(new TwitterData(new TwitterContext()))
        {
        }

        public TestController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult aaa()
        {
            return View();
        }
    }
}