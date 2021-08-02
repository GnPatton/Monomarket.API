using Microsoft.EntityFrameworkCore.Storage;
using Monomarket.Business.DataAccess;
using Monomarket.Business.DataAccess.Repositories;
using Monomarket.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.DataAccess
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private UnitOfWorkScope _unitOfWorkScope;
        internal readonly MonoDbContext _dbContext;

        private IUserRepository _userRepository;

        public event EventHandler OnCommit
        {
            add
            {
                var scopeCommited = _unitOfWorkScope;
                if (scopeCommited != null) scopeCommited.OnScopeCommited += value;
            }
            remove
            {
                var scopeCommited = _unitOfWorkScope;
                if (scopeCommited != null) scopeCommited.OnScopeCommited -= value;
            }
        }

        public event EventHandler OnSave
        {
            add
            {
                _dbContext.OnSave += value;
            }
            remove
            {
                _dbContext.OnSave -= value;
            }
        }

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_dbContext));

        public UnitOfWork(MonoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add<T>(T entity)
        {
            _dbContext.Add(entity);
            return entity;
        }

        public Task CommitAsync()
        {
            try
            {
                return _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't save changes on database");
            }
        }

        public IUnitOfWorkScope CreateScope()
        {
            if (_unitOfWorkScope != null) throw new InvalidOperationException();
            _unitOfWorkScope = new UnitOfWorkScope(this, _dbContext.Database.BeginTransaction());
            return _unitOfWorkScope;
        }

        public async Task<IUnitOfWorkScope> CreateScopeAsync()
        {
            if (_unitOfWorkScope != null) throw new InvalidOperationException();
            _unitOfWorkScope = new UnitOfWorkScope(this, await _dbContext.Database.BeginTransactionAsync());
            return _unitOfWorkScope;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Remove<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        private class UnitOfWorkScope : IUnitOfWorkScope
        {
            private readonly UnitOfWork _unitOfWork;
            private readonly IDbContextTransaction _contextTransaction;

            public event EventHandler OnScopeCommited;

            public UnitOfWorkScope(UnitOfWork unitOfWork, IDbContextTransaction contextTransaction)
            {
                _unitOfWork = unitOfWork;
                _contextTransaction = contextTransaction;
            }

            public async Task CommitAssync()
            {
                await _unitOfWork.CommitAsync();
                _contextTransaction.Commit();
                OnScopeCommited?.Invoke(this, EventArgs.Empty);
            }

            public void Dispose()
            {
                _contextTransaction.Dispose();
            }

            public void Rollback()
            {
                _contextTransaction.Rollback();
            }
        }
    }
}
