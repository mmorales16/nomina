using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace nomina.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Please select a role")]
        public string Email { get; set; }
        public string Telephone_number { get; set; }
        public int Department_id { get; set; }
        public string Password { get; set; }
        public string Type_payment { get; set; }
        public decimal Amount_salary { get; set; }
        public int Role_id { get; set; }
        public string State { get; set; }
        public DateTime Update_date { get; set; }
        public string Update_user { get; set; }
        public DateTime Create_date { get; set; }
        public string Create_user { get; set; }       

    }
}