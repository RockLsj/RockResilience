using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IR_STATION_REC_TRepository
        : IR_STATION_REC_TRepository<R_STATION_REC_T, int>
    {
        public bool IsExistLINE_NAME(string LINE_NAME,string WORK_DATE,string GROUP_NAME,string MO_NUMBER,int WORK_SECTION);

        public void AddR_STATION_REC_T(string WORK_DATE,string LINE_NAME,string GROUP_NAME, 
            string MODEL_NAME,string MO_NUMBER,int WIP_QTY, 
            int PASS_QTY,int FAIL_QTY,int REPASS_QTY,
            int REFAIL_QTY,int WORK_SECTION,string WO_NUMBER);
    }

    public interface IR_STATION_REC_TRepository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
