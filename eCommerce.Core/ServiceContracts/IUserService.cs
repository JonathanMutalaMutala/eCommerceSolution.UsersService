using eCommerce.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUserService
    {
        /// <summary>
        /// Method permettant de recuperer le user qui compte se connecter 
        /// </summary>
        /// <param name="loginRequestDto"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequestDto loginRequestDto);

        Task<AuthenticationResponse?> Register(RegisterRequestDto registerRequestDto);




    }
}
