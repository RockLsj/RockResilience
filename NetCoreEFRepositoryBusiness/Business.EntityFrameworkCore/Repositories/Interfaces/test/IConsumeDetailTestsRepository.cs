using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public interface IConsumeDetailTestsRepository
        : IConsumeDetailTestRepository<ConsumeDetailTest, int>
    {
        public bool DeleteById(ConsumeDetailTest e);
    }

    public interface IConsumeDetailTestRepository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
