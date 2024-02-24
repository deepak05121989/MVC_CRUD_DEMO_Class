using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DEMO.Models
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [DisplayName("Student Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile is Required")]
       // [EmailAddress]
        //[Range(10,52)]
        //[RegularExpression("tfnyyygyygy")]
        public long Mobile { get; set; }
    }
}