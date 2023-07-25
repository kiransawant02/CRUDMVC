using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDMVC.Models
{
    public class User
    {
        [Required]
        [DisplayName("User Id")]
        public int Id { get; set; } 
        
        [Required]
        [DisplayName("User Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("User Email")]
        public string EmailId { get; set; }

        [Required]
        [DisplayName("User Password")]
        public string Password{ get; set; }
    }
}