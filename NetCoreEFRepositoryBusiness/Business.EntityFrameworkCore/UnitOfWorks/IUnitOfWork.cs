using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityFrameworkCore.Repositories;
using Business.EntityFrameworkCore.Repositories.Interfaces;

namespace Business.EntityFrameworkCore.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        #region Test

        IDeveloperRepository Developers { get; }
        IPeopleTestsRepository PeopleTests { get; }
        IConsumeDetailTestsRepository ConsumeDetailTests { get; }
        IStudentTest2Repository StudentTest2s { get; }
        IStudentTest3Repository StudentTest3s { get; }

        #endregion

        IC_WORK_DESC_TRepository C_WORK_DESC_Ts { get; }
        IWriteNumberRepository WriteNumbers { get; }
        IStationResumeRepository StationResumes { get; }
        IStationResume_FailRepository StationResume_Fails { get; }
        IR_STATION_REC_TRepository R_STATION_REC_Ts { get; }
        IStation_informationRepository Station_informations { get; }
        IBAH_MOProcessFlowRepository BAH_MOProcessFlows { get; }
        

        int Complete();
    }
}
