using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Common.Extensions;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;
using Business.EntityFrameworkCore.Repositories.Interfaces;

namespace Business.EntityFrameworkCore.Repositories
{
    public class R_STATION_REC_TRepository :
        BaseRepository<ApplicationContext, R_STATION_REC_T, int>,
        IR_STATION_REC_TRepository
    {
        public R_STATION_REC_TRepository(ApplicationContext context) : base(context)
        {

        }

        public bool IsExistLINE_NAME(string LINE_NAME, string WORK_DATE, string GROUP_NAME, string MO_NUMBER, int WORK_SECTION)
        {
            string strLINE_NAME = "";

            Expression<Func<R_STATION_REC_T, bool>> predicate = f => true;
            predicate = predicate.And(e=> e.LINE_NAME == LINE_NAME);
            predicate = predicate.And(e=> e.WORK_DATE == WORK_DATE);
            predicate = predicate.And(e=> e.GROUP_NAME == GROUP_NAME);
            predicate = predicate.And(e=> e.MO_NUMBER == MO_NUMBER);
            predicate = predicate.And(e=> e.WORK_SECTION == WORK_SECTION);

            var iq = base.Load(predicate);

            if (iq.Any())
            {
                strLINE_NAME = iq.Select(e => e.LINE_NAME).FirstOrDefault();
            }

            return !String.IsNullOrEmpty(strLINE_NAME);
        }

        public void AddR_STATION_REC_T(string WORK_DATE, string LINE_NAME, string GROUP_NAME, string MODEL_NAME, string MO_NUMBER, int WIP_QTY, int PASS_QTY, int FAIL_QTY, int REPASS_QTY, int REFAIL_QTY, int WORK_SECTION, string WO_NUMBER)
        {
            R_STATION_REC_T e = new R_STATION_REC_T();
            e.WORK_DATE= WORK_DATE;
            e.LINE_NAME= LINE_NAME;
            e.GROUP_NAME = GROUP_NAME;
            e.MODEL_NAME = MODEL_NAME;
            e.MO_NUMBER = MO_NUMBER;
            e.WIP_QTY = WIP_QTY;
            e.PASS_QTY = PASS_QTY;
            e.FAIL_QTY = FAIL_QTY;
            e.REPASS_QTY = REPASS_QTY;
            e.REFAIL_QTY = REFAIL_QTY;
            e.WORK_SECTION = WORK_SECTION;
            e.WO_NUMBER = WO_NUMBER;

            base.Insert(e);
        }
    }
}
