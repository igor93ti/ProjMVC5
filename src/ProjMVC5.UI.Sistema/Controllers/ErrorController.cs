using System.Web.Mvc;

namespace ProjMVC5.UI.Sistema.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }
    }
}