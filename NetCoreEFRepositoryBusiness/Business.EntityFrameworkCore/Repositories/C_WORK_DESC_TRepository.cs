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
    public class C_WORK_DESC_TRepository :
        BaseRepository<ApplicationContext, C_WORK_DESC_T, int>,
        IC_WORK_DESC_TRepository
    {
        public C_WORK_DESC_TRepository(ApplicationContext context) : base(context)
        {

        }

        /// <summary>
        /// Get WORK_SECTION from table C_WORK_DESC_T by START_TIME,END_TIME,LINE_NAME.
        /// 根据条件:START_TIME,END_TIME,LINE_NAME,从表C_WORK_DESC_T中获取WORK_SECTION.
        /// </summary>
        /// <returns></returns>
        public int Spd_Get_WorkSection()
        {
            int vintWorkSection = 0;

            int lstrHHMI = int.Parse(DateTime.Now.ToString("HHmm"));
            string strDefault = "Default";

            Expression<Func<C_WORK_DESC_T, bool>> predicate = f => true;
            predicate = predicate.And(e => e.START_TIME <= lstrHHMI);
            predicate = predicate.And(e => e.END_TIME > lstrHHMI);
            predicate = predicate.And(e => e.LINE_NAME == strDefault);

            var iq = base.Load(predicate);

            if (iq.Any())
            {
                vintWorkSection = iq.Select(e => e.WORK_SECTION).FirstOrDefault();
            }

            return vintWorkSection;
        }
    }
}
