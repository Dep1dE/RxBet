using RxBetCore.Models;
using RxBetDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxBetAuthorization.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(UserEntity user);
    }
}
