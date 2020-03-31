using MadPay724.Common.Helpers;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Auth.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Services.Auth.Repo
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork<MadPayDbContext> _db;
        public AuthService(IUnitOfWork<MadPayDbContext> dbContext)
        {
            _db = dbContext;
        }
        public async Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            Utilities.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _db.UserRepository.InsertAsync(user);
            await _db.SaveAsync();
            return user;
        }
    }
}
