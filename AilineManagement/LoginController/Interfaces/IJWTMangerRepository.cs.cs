using LoginService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Interfaces
{
    public interface IJWTMangerRepository
    {
        Tokens Authenticate(LoginViewModel users, bool IsRegister);

    }
}
