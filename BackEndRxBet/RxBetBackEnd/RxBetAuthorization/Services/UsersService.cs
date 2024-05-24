using Infrastructure;
using RxBetAuthorization.Interfaces.Auth;
using RxBetCore.Models;
using RxBetDataBase;
using RxBetDataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxBetAuthorization.Services
{
    public class UsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProwider;
        public UsersService(IUsersRepository usersRepository,IPasswordHasher passwordHasher, IJwtProvider jwtProwider)
        {
            _passwordHasher = passwordHasher;
            _usersRepository = usersRepository;
            _jwtProwider = jwtProwider;
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, hashedPassword, email);

            await _usersRepository.Add(user.Id, user.Username, user.Email, user.PasswordHash, user.RegistrationDate, user.DailyBonusCollected);
        }

        public async Task<string> Login(string email , string password)
        {
            var user = await _usersRepository.GetByEmail(email);

            var valid = _passwordHasher.Verify(password, user.PasswordHash);

            if(valid == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProwider.GenerateToken(user);

            return token;
        }
    }
}
