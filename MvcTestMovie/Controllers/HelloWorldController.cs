using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcTestMovie.Controllers;

public class HelloWorldController : Controller
{
    // 控制器中的每个 public 方法均可作为 HTTP 终结点调用
    // GET: /HelloWorld/
    public string Index()
    {
        return "This is my default action...";
    }

    // GET: /HelloWorld/Welcome/ 
    // Requires using System.Text.Encodings.Web;
    // 使用 C# 可选参数功能指示，未为 numTimes 参数传递值时该参数默认为 1
    // public string Welcome(string name, int numTimes = 1)
    // {
    //     // return "This is the Welcome action method...";
    //     
    //     // 使用 HtmlEncoder.Default.Encode 防止恶意输入（例如通过 JavaScript）损害应用。
    //     return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    //     // 访问 URL：https://localhost:{PORT}/HelloWorld/Welcome?name=Rick&numtimes=4，输出：Hello Rick, NumTimes is: 4
    // }
    public string Welcome(string name, int ID = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
    }
}