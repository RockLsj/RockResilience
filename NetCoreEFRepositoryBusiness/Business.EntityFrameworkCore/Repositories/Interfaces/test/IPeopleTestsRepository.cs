﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public interface IPeopleTestsRepository
        : IPeopleTestsRepository<PeopleTest, int>
    {
        public IQueryable<PeopleTest> GetPeopleTests();

        public bool DeleteById(PeopleTest e);

    }

    public interface IPeopleTestsRepository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
