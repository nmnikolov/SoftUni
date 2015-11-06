namespace SoftUni.Blog.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;

    public class TownsController : BaseController
    {
        public TownsController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTowns(string search)
        {
            var towns = this.Data.Towns.All().Where(t => t.Name.Contains(search)).Select(TownViewModel.Create);

            return this.PartialView("_SearchResultPartial", towns);
        }
    }
}