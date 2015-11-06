using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.Web.Controllers
{
    using Data;

    public class BaseController : Controller
    {
        public BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        public ITwitterData Data { get; set; }
    }
}