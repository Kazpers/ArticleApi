using System.IO.Pipes;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApi.Controllers
{
    [Route("")]
    public class DocumentationController : Controller
    {
        /// <summary>
        /// This will get the documentation file
        /// </summary>
        /// <returns></returns>
        [HttpGet("readme")]
        public ActionResult Readme()
        {
            return File("~/README.html", "text/html");
        }
    }
}