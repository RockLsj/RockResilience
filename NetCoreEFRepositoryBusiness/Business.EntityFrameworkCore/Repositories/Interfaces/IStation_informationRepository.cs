using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IStation_informationRepository
        : IStation_informationRepository<Station_information, int>
    {
        public bool IsExistwtuid(string SN);

        public void AddStation_information(string wtuid, string Model);

        public void UpdateStation_information(string wtuid, int RR);

        public bool UpdateStation_information(string strSql);

        public string GetStationFlag(string strSql);
    }

    public interface IStation_informationRepository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
