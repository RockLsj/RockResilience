using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Common.Extensions;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public class PeopleTestsRepository :
        BaseRepository<ApplicationContext, PeopleTest, int>,
        IPeopleTestsRepository
    {
        public PeopleTestsRepository(ApplicationContext context) : base(context)
        {

        }

        public IQueryable<PeopleTest> GetPeopleTests()
        {
            return base.GetAll();
        }

        public bool DeleteById(PeopleTest e)
        {
            return base.Delete(e);
        }

    }
}
