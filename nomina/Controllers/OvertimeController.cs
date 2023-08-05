using nomina.Models.DAO;
using System.Web.Mvc;



namespace nomina.Controllers
{
    public class OvertimeController : Controller
    {



        private OvertimeDAO overtimeRepository = new OvertimeDAO();
        public ActionResult ReadOvertime()
        {



            return View(overtimeRepository.ReadOvertime());
        }





    }
}