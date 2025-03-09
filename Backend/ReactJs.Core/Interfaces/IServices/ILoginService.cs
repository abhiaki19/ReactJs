using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Interfaces.IServices
{
    public interface ILoginService : IBaseService<LoginResponse>
    {
        Task<LoginResponse> Login(LoginRequest model, CancellationToken cancellationToken);

        Task<LoginResponce> SignInAsync(LoginRequest model, CancellationToken cancellationToken);
    }
}
