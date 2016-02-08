using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Student_Assistant_App.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        public String FirstName { get; set; }
        public String LastName { get; set; }

        [Required(ErrorMessage ="Email is required!")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public String Password  { get; set; }

        [Compare("Password", ErrorMessage ="Please Confirm your Password.")]
        [DataType(DataType.Password)]
        public String ConfrimPassword { get; set; }
    }
}