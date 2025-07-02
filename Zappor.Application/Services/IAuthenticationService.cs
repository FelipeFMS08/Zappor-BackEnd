using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zappor.Application.DTO;

namespace Zappor.Application.Services
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(AuthenticationDTO authenticationDTO);
        Task<string?> LoginAsync(AuthenticationDTO authenticationDTO);
    }
}
