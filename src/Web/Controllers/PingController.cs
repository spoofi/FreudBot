using System.Web.Mvc;
using Spoofi.FreudBot.Logic.Bot;

namespace Spoofi.FreudBot.Web.Controllers
{
    public class PingController : Controller
    {
        public JsonResult Index()
        {
            return Json(new
            {
                InitDate = Bot.StartedAtUtc.ToString("yyyy-MM-dd HH:mm:ss")
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
