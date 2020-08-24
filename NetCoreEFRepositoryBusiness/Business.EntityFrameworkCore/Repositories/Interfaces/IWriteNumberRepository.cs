using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IWriteNumberRepository
        : IDeveloperRepository<WriteNumber, int>
    {
        public string GetPcbSN(string Imei_1);
    }

    public interface IWriteNumberRepository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
