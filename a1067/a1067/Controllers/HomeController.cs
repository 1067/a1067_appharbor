using System.Web.Mvc;
using AppHarbor.Web;

namespace a1067.Controllers
{
    [AhRequireHttps]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
