using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityFrameworkCore.Repositories;
using Business.EntityFrameworkCore.Repositories.Interfaces;

namespace Business.EntityFrameworkCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        //test
        public IDeveloperRepository Developers { get; private set; }
        public IPeopleTestsRepository PeopleTests { get; private set; }
        public IConsumeDetailTestsRepository ConsumeDetailTests { get; private set; }
        public IStudentTest2Repository StudentTest2s { get; private set; }
        public IStudentTest3Repository StudentTest3s { get; private set; }

        public IC_WORK_DESC_TRepository C_WORK_DESC_Ts { get; private set; }
        public IWriteNumberRepository WriteNumbers { get; private set; }
        public IStationResumeRepository StationResumes { get; private set; }
        public IStationResume_FailRepository StationResume_Fails { get; private set; }
        public IR_STATION_REC_TRepository R_STATION_REC_Ts { get; private set; }
        public IStation_informationRepository Station_informations { get; private set; }
        public IBAH_MOProcessFlowRepository BAH_MOProcessFlows { get; private set; }

        public UnitOfWork(
            IApplicationDbContext context,

            IDeveloperRepository developers,
            IPeopleTestsRepository peopleTests,
            IConsumeDetailTestsRepository consumeDetailTests,
            IStudentTest2Repository studentTest2s,
            IStudentTest3Repository studentTest3s,

            IC_WORK_DESC_TRepository c_WORK_DESC_Ts,
            IWriteNumberRepository writeNumbers,
            IStationResumeRepository stationResumes,
            IStationResume_FailRepository stationResume_Fails,
            IR_STATION_REC_TRepository r_STATION_REC_Ts,
            IStation_informationRepository station_informations,
            IBAH_MOProcessFlowRepository bAH_MOProcessFlows
            )//ApplicationContext context
        {
            _context = context;

            //Developers = new DeveloperRepository(_context);
            //test
            Developers = developers;
            PeopleTests = peopleTests;
            ConsumeDetailTests = consumeDetailTests;
            StudentTest2s = studentTest2s;
            StudentTest3s = studentTest3s;

            C_WORK_DESC_Ts = c_WORK_DESC_Ts;
            WriteNumbers = writeNumbers;
            StationResumes = stationResumes;
            StationResume_Fails = stationResume_Fails;
            R_STATION_REC_Ts = r_STATION_REC_Ts;
            Station_informations = station_informations;
            BAH_MOProcessFlows = bAH_MOProcessFlows;
        }

        public int Complete()
        {
            return int.Parse(_context.SaveChanges().ToString());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
