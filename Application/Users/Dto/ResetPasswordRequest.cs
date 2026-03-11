using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record ResetPasswordDto(string Email, string Code, string NewPassword);
}