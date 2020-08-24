using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public interface IStudentTest2Repository
        : IStudentTest2Repository<StudentTest2, int>
    {
        public IQueryable<StudentTest2> GetStudentTest2s();
    }

    public interface IStudentTest2Repository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
