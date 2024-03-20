using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiProject.Models;

namespace MyWebApiProject.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}