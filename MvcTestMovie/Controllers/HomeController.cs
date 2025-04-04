using Microsoft.AspNetCore.Mvc;
// using System.Text.Encodings.Web;

namespace MvcTestMovie.Controllers;

public class HelloWorldController : Controller
{
    // 控制器中的每个 public 方法均可作为 HTTP 终结点调用
    // GET: /HelloWorld/
    public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}