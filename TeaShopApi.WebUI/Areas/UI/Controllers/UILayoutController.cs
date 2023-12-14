using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.Areas.UI.Controllers
{
    [Area("UI")]
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialBook()
        {
            return PartialView();
        }
      
        public PartialViewResult PartialChef()
        {
            return PartialView();
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialEvent()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialGallery()
        {
            return PartialView();
        }
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
       
        public PartialViewResult PartialMain()
        {
            return PartialView();
        }
        public PartialViewResult PartialMenu()
        {
            return PartialView();
        }
        public PartialViewResult PartialStats()
        {
            return PartialView();
        }
        public PartialViewResult PartialTestimonial()
        {
            return PartialView();
        }
        public PartialViewResult PartialWhy()
        {
            return PartialView();
        }
    }
}
