using Monomarket.Business.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monomarket.DataAccess
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
