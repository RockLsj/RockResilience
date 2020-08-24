using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IBAH_MOProcessFlowRepository
        : IDeveloperRepository<BAH_MOProcessFlow, int>
    {
        public int GetBah_n11(string bah_c13, string bah_c031);
    }

    public interface IBAH_MOProcessFlowRepository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
