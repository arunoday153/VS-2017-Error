using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentWebApp.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage ="Please Enter ID")]
        public int ID { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public String Gender { get; set; }

        [Required(ErrorMessage ="Please Enter Salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage ="Please Select your Department")]
        public int DepartmentID { get; set; }

        public String Department { get; set; }

    }
}