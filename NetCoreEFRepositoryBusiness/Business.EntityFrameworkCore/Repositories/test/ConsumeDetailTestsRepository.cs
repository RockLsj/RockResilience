using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;
using Business.EntityFrameworkCore;
using Business.EntityFrameworkCore.Repositories;

namespace Business.EntityFrameworkCore.Repositories
{
    public class ConsumeDetailTestsRepository :
        BaseRepository<ApplicationContext, ConsumeDetailTest, int>,
        IConsumeDetailTestsRepository
    {
        public ConsumeDetailTestsRepository(ApplicationContext context) : base(context)
        {

        }

        public bool DeleteById(ConsumeDetailTest e)
        {
            return base.Delete(e);
        }
    }
}
