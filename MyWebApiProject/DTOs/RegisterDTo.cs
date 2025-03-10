using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.DTOs
{
    public class RegisterDTo
    {
        [Required(ErrorMessage ="This field is required ")]
        public string? UserName{get; set;}
        
        [Required(ErrorMessage ="This field is required ")]
        [EmailAddress]
        public string? Email{get; set;}
        
        [Required(ErrorMessage ="This field is required ")]
        public string Password{get; set;}
    }
}