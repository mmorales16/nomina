
using nomina.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nomina.Controllers
{
    public class UserController : Controller
    {
        private UserDAO userRepository = new UserDAO();
        // GET: User
        public ActionResult Index()
        {

            // Devuelve la vista Index con la lista de usuarios
            return View(userRepository.ReadUsers());
        }


    }
}
