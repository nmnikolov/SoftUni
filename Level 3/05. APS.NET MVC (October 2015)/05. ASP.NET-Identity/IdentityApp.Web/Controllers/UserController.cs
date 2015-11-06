namespace IdentityApp.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}