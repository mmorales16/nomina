
using nomina.Models.DAO;
using nomina.Models.DTO;
using System;
using System.Linq;
using System.Web.Mvc;

namespace nomina.Controllers
{
    public class UserController : Controller
    {
        private UserDAO userRepository = new UserDAO();
        // GET: User
        public ActionResult Index(string searchKeyword)
        {
            // Devuelve la vista Index con la lista de usuarios
            return View(userRepository.ReadUsers(searchKeyword));
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
                string result = userRepository.InsertUser(user);

                if (result == "Success")
                {
                    // Redireccionar a la vista "Index" en caso de éxito
                    return RedirectToAction("Index");
                }
                else
                {
                    // Si la inserción falla, agregar un mensaje de alerta a la ViewBag
                    ViewBag.ErrorMessage = "Error al insertar el usuario en la base de datos.";
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, agregar un mensaje de alerta a la ViewBag
                ViewBag.ErrorMessage = "Ocurrió un error durante la inserción del usuario: " + ex.Message;
            }

            // Devolver la vista "CreateUser" con los datos del usuario ingresados previamente
            // y el mensaje de alerta (si corresponde).
            var roles = userRepository.ReadRoles().ToList();
            ViewBag.Roles = new SelectList(roles, "id", "Description");
            return View(user);
        }



        [HttpGet]
        public ActionResult Login()
        {
            // Muestra la vista de inicio de sesión
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                UserDAO userDAO = new UserDAO();
                bool isValidCredentials = userDAO.ValidateUser(user.Email, user.Password);

                if (isValidCredentials)
                {
                    // Credenciales válidas, permite el acceso (por ejemplo, redirige a la página de inicio)
                    return RedirectToAction("Index");
                }
                else
                {
                    // Credenciales inválidas, muestra mensaje de error
                    ViewBag.ErrorMessage = "Incorrect credentials, check the email and password";
                }
            }

<<<<<<< Updated upstream
                // Si el modelo no es válido o las credenciales son inválidas, vuelve a mostrar la vista de inicio de sesión con los errores
                return View(user);
            }
=======
            // Si el modelo no es válido o las credenciales son inválidas, vuelve a mostrar la vista de inicio de sesión con los errores
            return View(user);
        }



>>>>>>> Stashed changes

        public ActionResult Edit(int id)
        {
            try
            {
                // Intenta obtener un usuario específico utilizando el método GetUserById del repositorio UserDAO
                UserDTO user = userRepository.GetUserById(id);
                if (user != null)
                {
                    // Si el usuario existe, muestra la vista de edición con los detalles del usuario
                    return View(user);
                }
                else
                {
                    Console.WriteLine("User not found");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting user: " + ex.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: User/Edit/
        [HttpPost]
        public ActionResult Edit(UserDTO user)
        {
            try
            {
                // Intenta actualizar los detalles del usuario utilizando el método UpdateUser del repositorio UserDAO
                string result = userRepository.UpdateUser(user);
                Console.WriteLine("User updated: " + result);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user: " + ex.Message);
                return View(user);
            }
        }
        // GET: User/Delete/
        public ActionResult Delete(int id)
        {
            // Obtiene un usuario específico utilizando el método GetUserById del repositorio UserDAO
            UserDTO user = userRepository.GetUserById(id);
            if (user == null)
            {
                // El usuario no existe, mostrar mensaje de error o redirigir a otra vista
                return RedirectToAction("Index");
            }

            return View(user);
        }
        // POST: User/Delete/
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Intenta eliminar el usuario utilizando el método DeleteUser del repositorio UserDAO
                string result = userRepository.DeleteUser(id);
                Console.WriteLine("User deleted: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting user: " + ex.Message);
            }
            // Redirige a la vista Index después de eliminar el usuario
            return RedirectToAction("Index");
        }
    }
}
