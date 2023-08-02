
using nomina.Models.DAO;
using nomina.Models.DTO;
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

        public ActionResult RolesList()
        {
            // Devuelve la vista Index con la lista de usuarios
            return View(userRepository.ReadRoles());
        }

        public ActionResult CreateUser()
        {
            // Obtener los roles disponibles
            var roles = userRepository.ReadRoles().ToList();
            ViewBag.Roles = new SelectList(roles, "id", "Description");
            return View();
        }


        // POST: User/Create
        [HttpPost]
        public ActionResult CreateUser(UserDTO user)
        {
            try
            {
                // Intenta insertar un nuevo usuario utilizando el método InsertUser del repositorio UserDAO
                string result = userRepository.InsertUser(user);
                Console.WriteLine("User added: " + result);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                        
                return View(user);
            }


        }




    }


  
}
