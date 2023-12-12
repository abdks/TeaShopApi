using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.Areas.UI.Controllers
{
    [Area("UI")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
