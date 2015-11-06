namespace IdentityApp.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}