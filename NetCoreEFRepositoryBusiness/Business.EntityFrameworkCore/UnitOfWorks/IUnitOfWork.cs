﻿using Business.EntityFrameworkCore.Repositories;

namespace Business.EntityFrameworkCore.UnitOfWorks
{
    public interface IUnitOfWork
    {
        #region Test

        IDeveloperRepository Developers { get; }
        IPeopleTestsRepository PeopleTests { get; }
        IConsumeDetailTestsRepository ConsumeDetailTests { get; }
        IStudentTest2Repository StudentTest2s { get; }
        IStudentTest3Repository StudentTest3s { get; }

        #endregion
    }
}
