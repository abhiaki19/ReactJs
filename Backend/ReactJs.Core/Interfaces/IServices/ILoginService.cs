using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Interfaces.IServices
{
    public interface ILoginService : IBaseService<LoginResponce>
    {
        Task<LoginResponce> Login(LoginRequest model, CancellationToken cancellationToken);
    }
}
