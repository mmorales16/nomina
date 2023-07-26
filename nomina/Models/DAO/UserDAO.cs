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
        public List<UserDTO> ReadUsers()
        {
            List<UserDTO> users = new List<UserDTO>();

            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM tb_users";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
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
                Console.WriteLine("Error in nomina.Models.DAO.UserDAO.InserUser:" + ex.Message);
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

    }
}