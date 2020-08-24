using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IStationResume_FailRepository
        : IStationResume_FailRepository<StationResume_Fail, int>
    {
        public void AddStationResume_Fail(StationResume_Fail e);
    }

    public interface IStationResume_FailRepository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
