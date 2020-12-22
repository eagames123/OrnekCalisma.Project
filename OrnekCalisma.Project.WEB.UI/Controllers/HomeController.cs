using OrnekCalisma.Project.Business.Abstract;
using System.Collections.Generic;
using System.Web.Mvc;
using OrnekCalisma.Project.DTO;
using OrnekCalisma.Project.Utilities;

namespace OrnekCalisma.Project.WEB.UI.Controllers
{
    public class HomeController : Controller
    {

        public readonly IMusteriService _musteriService;

        public readonly ISepetService _sepetService;

        public readonly ISepetUrunService _sepetUrunService;

        public HomeController(IMusteriService musteriService, ISepetService sepetService, ISepetUrunService sepetUrunService)
        {
            _musteriService = musteriService;
            _sepetService = sepetService;
            _sepetUrunService = sepetUrunService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult TestVerisiOlustur()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestVerisiOlustur(int musteriAdet, int sepetAdet)
        {
            MusteriSepetUrunHelper musteriSepetUrunHelper = new MusteriSepetUrunHelper(_sepetUrunService,_musteriService,_sepetService);

            musteriSepetUrunHelper.Ekle(musteriAdet,sepetAdet);

            return View();
        }
        
        public ActionResult SehirBazliAnalizYap()
        {
            SehirAnalizHelper analizHelper = new SehirAnalizHelper(_musteriService,_sepetService,_sepetUrunService);

            List<SehirAnalizDTO> list =  analizHelper.AnalizYap();

            return View(list);
        }
        
    }
}
