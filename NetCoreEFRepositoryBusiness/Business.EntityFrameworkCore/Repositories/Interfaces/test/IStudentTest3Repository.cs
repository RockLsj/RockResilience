using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public interface IStudentTest3Repository
        : IStudentTest3Repository<StudentTest3, int>
    {
        public IQueryable<StudentTest3> GetStudentTest3s();
    }

    public interface IStudentTest3Repository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
