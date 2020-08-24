using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;
using Business.EntityFrameworkCore.Repositories.Interfaces;

namespace Business.EntityFrameworkCore.Repositories
{
    public class StationResumeRepository :
        BaseRepository<ApplicationContext, StationResume, int>,
        IStationResumeRepository
    {
        public StationResumeRepository(ApplicationContext context) : base(context)
        {

        }

        public bool AddStationResume(StationResume e)
        {
            return base.Insert(e);
        }
    }
}
