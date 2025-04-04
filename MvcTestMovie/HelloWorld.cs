using Microsoft.AspNetCore.Mvc;

namespace MvcTestMovie
{
    public class HelloWorld : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

    }
}
