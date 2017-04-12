using System.Web.Mvc;
using MyInjector.Web.Services;

namespace MyInjector.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly ILookupUsers _userRetriever;

        public TestController(ILookupUsers userRetriever)
        {
            _userRetriever = userRetriever;
        }

        public ActionResult Index()
        {
            var model = _userRetriever.GetUser();
            return View(model);
        }
    }
}