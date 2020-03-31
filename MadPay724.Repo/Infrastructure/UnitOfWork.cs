using MadPay724.Repo.Repositories.Interface;
using MadPay724.Repo.Repositories.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Repo.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        #region Constructor

        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }

        #endregion

        #region Save

        public void Save()
        {
            _db.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        #endregion

        #region Private Repository
        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_db);
                }
                return userRepository;
            }


        }
        #endregion


        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}
