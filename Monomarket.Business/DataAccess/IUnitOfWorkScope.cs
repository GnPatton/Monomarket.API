using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.Business.DataAccess
{
    public interface IUnitOfWorkScope : IDisposable
    {
        Task CommitAssync();

        void Rollback();
    }
}
