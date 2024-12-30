using AutoMapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUSersRepository _usersRepository;
        private readonly IMapper mapper;

        public UserService(IUSersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            this.mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _usersRepository.GetUserByEmailAndPassword(loginRequestDto.Email, loginRequestDto.password);

            if (user == null)
                return null;

            return new AuthenticationResponse(user.UserId, user.Email, user.PersonName, user.Gender, "Token", Success: true);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequestDto registerRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                PersonName = registerRequestDto.PersonName,
                Email = registerRequestDto.Email,
                Password = registerRequestDto.Password,
                Gender = registerRequestDto.GenderOptions.ToString(),
            };
            var registeredUser = await _usersRepository.AddUser(user); 

            if (registeredUser == null)
            {
                throw new NullReferenceException(); 
            }

            return new AuthenticationResponse(
                registeredUser.UserId,
                registeredUser.Email,
                registeredUser.PersonName,
                user.Gender, "Token", Success: true);
                
        }
    }
}
