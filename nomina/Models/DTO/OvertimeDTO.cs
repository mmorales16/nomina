

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;





namespace nomina.Models.DTO
{
    public class OvertimeDTO
    {



        public string Type_action { get; set; }
        public double Overtime_value { get; set; }
        public string Overtime_description { get; set; }
        public int Overtime_id { get; set; }
        public string Create_overtime { get; set; }
        public string Update_overtime { get; set; }
        public int Id { get; set; }





    }
}