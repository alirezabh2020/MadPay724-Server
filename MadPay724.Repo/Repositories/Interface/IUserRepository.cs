using MadPay724.Repo.Infrastructure;
using MadPay724.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Repo.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UserExists(string username);
    }
}
