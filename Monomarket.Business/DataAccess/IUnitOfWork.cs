using Monomarket.Business.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.Business.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        event EventHandler OnCommit;

        event EventHandler OnSave;

        IUserRepository UserRepository { get; }

        IUnitOfWorkScope CreateScope();

        Task<IUnitOfWorkScope> CreateScopeAsync();

        T Add<T>(T entity);

        void Remove<T>(T entity) where T : class;

        Task CommitAsync();
    }
}
