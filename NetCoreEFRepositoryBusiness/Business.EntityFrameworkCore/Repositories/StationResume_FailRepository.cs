using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;
using Business.EntityFrameworkCore.Repositories.Interfaces;

namespace Business.EntityFrameworkCore.Repositories
{
    public class StationResume_FailRepository :
        BaseRepository<ApplicationContext, StationResume_Fail, int>,
        IStationResume_FailRepository
    {
        public StationResume_FailRepository(ApplicationContext context) : base(context)
        {

        }

        public void AddStationResume_Fail(StationResume_Fail e)
        {
            base.Insert(e);
        }

    }
}
