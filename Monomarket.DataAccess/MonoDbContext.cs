using Microsoft.EntityFrameworkCore;
using Monomarket.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.DataAccess
{
    public class MonoDbContext : MonomarketDbContext
    {
        public MonoDbContext(DbContextOptions<MonoDbContext> options) : base(options)
        {
        }

        public event EventHandler OnSave;

        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            Add(entity);
            await SaveChangesAsync();
            return entity;
        }
    }
}
