using MySql.Data.MySqlClient;
using nomina.Models.DTO;
using nomina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nomina.Models.DAO
{
    public class UserDAO
    {
        public List<UserDTO> ReadUsers(string searchKeyword)
        {
            List<UserDTO> users = new List<UserDTO>();

            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM tb_users WHERE name LIKE @searchKeyword OR email LIKE @searchKeyword";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%");

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDTO user = new UserDTO();
                                user.Id = reader.GetInt32("user_id");
                                user.Name = reader.GetString("name");
                                user.Last_Name = reader.GetString("last_name");
                                user.Email = reader.GetString("email");
                                user.Telephone_number = reader.GetString("telephone_number");
                                user.Department_id = reader.GetInt32("department_id");
                                user.Password = reader.GetString("password");
                                user.Type_payment = reader.GetString("type_payment");
                                user.Amount_salary = reader.GetDecimal("amount_salary");
                                user.Role_id = reader.GetInt32("role_id");
                                user.State = reader.GetString("state");
                                user.Update_date = reader.GetDateTime("update_date");
                                user.Update_user = reader.GetString("update_user");
                                user.Create_date = reader.GetDateTime("create_date");
                                user.Create_user = reader.GetString("create_user");
                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in nomina.Models.DAO.UserDAO.ReadUsers:" + ex.Message);
            }
            return users;
        }


        public List<Roles> ReadRoles()
        {
            List<Roles> roles = new List<Roles>();

            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM tb_roles";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Roles role = new Roles();
                                role.Id = reader.GetInt32("id");
                                role.Description = reader.GetString("description");

                                roles.Add(role);
                            }
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine("Error in nomina.Models.DAO.Roles.InserUser:" + ex.Message);
            }
            return roles;
        }


        public string InsertUser(UserDTO user)


        {
            string response = "Failed";

            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string insertUserQuery = "INSERT INTO tb_users (name, last_name, email, telephone_number, department_id, password, type_payment, amount_salary, role_id, state, update_date, update_user, create_date, create_user ) VALUES (@name, @last_name, @email, @telephone_number, @department_id, @password, @type_payment, @amount_salary, @role_id, @state, @update_date, @update_user, @create_date, @create_user)";


                    using (MySqlCommand userCommand = new MySqlCommand(insertUserQuery, connection))
                    {
                        userCommand.Parameters.AddWithValue("@name", user.Name);
                        userCommand.Parameters.AddWithValue("@last_name", user.Last_Name);
                        userCommand.Parameters.AddWithValue("@email", user.Email);
                        userCommand.Parameters.AddWithValue("@telephone_number", user.Telephone_number);
                        userCommand.Parameters.AddWithValue("@department_id", user.Department_id);
                        userCommand.Parameters.AddWithValue("@password", user.Password);
                        userCommand.Parameters.AddWithValue("@type_payment", string.IsNullOrEmpty(user.Type_payment) ? "" : user.Type_payment);
                        userCommand.Parameters.AddWithValue("@amount_salary", user.Amount_salary);
                        userCommand.Parameters.AddWithValue("@role_id", user.Role_id);
                        // Asignar el valor fijo "active" al parámetro @state
                        userCommand.Parameters.AddWithValue("@state", "active");
                        userCommand.Parameters.AddWithValue("@update_date", user.Update_date);
                        userCommand.Parameters.AddWithValue("@update_user", string.IsNullOrEmpty(user.Update_user) ? "MMORALES" : user.Update_user);
                        // Asignar automáticamente la fecha y hora actual al parámetro @create_date
                        userCommand.Parameters.AddWithValue("@create_date", DateTime.Now);
                        userCommand.Parameters.AddWithValue("@create_user", string.IsNullOrEmpty(user.Create_user) ? "ADMIN" : user.Create_user);

                        int rowsAffected = userCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            response = "Success";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UserDAO.InsertUser: " + ex.Message);
            }

            return response;
        }


        public bool ValidateUser(string email, string password)
        {
            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();
                    string selectQuery = "SELECT COUNT(*) FROM tb_users WHERE email = @Email AND password = @Password";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0; // Si count es mayor a 0, las credenciales son válidas.
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in nomina.Models.DAO.UserDAO.ValidateUser: " + ex.Message);
                return false; // En caso de error, consideramos las credenciales inválidas.
            }
        }







    }
}