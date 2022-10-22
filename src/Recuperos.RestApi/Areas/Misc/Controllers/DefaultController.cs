using System.Web.Mvc;

namespace Recuperos.RestApi.Areas.Misc.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}