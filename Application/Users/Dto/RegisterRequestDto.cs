using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record RegisterRequestDto(
        string UserName,

        [Required(ErrorMessage = "Email id Required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        string Email,

        string Password)
    {
        public string Role { get; set; }
    }
}