using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public interface IC_WORK_DESC_TRepository
        : IC_WORK_DESC_TRepository<C_WORK_DESC_T, int>
    {

        /// <summary>
        /// Get WORK_SECTION from table C_WORK_DESC_T by START_TIME,END_TIME,LINE_NAME.
        /// 根据条件:START_TIME,END_TIME,LINE_NAME,从表C_WORK_DESC_T中获取WORK_SECTION.
        /// 
        /// Original source:Procedure [dbo].[Spd_Get_WorkSection]
        /// 改写来源:存储过程[dbo].[Spd_Get_WorkSection]
        /// </summary>
        /// <returns></returns>
        public int Spd_Get_WorkSection();
    }

    public interface IC_WORK_DESC_TRepository<TEntity, TKey>
        : IRepository<ApplicationContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
