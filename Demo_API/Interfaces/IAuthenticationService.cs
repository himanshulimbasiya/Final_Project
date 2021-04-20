using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_API.Models;

namespace Demo_API.Interfaces
{
    public interface IAuthenticationService
    {
        User Login(String userName, String password);
    }
}
