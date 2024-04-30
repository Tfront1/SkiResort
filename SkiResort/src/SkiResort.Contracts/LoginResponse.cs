using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts;

public class LoginResponse
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
