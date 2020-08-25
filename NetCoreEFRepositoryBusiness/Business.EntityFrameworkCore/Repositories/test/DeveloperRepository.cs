using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

using Business.Domain.Entities;
using EntityFrameworkCore.Repository;

namespace Business.EntityFrameworkCore.Repositories
{
    public class DeveloperRepository :
        BaseRepository<RockResilienceContext, DeveloperTest, int>,
        IDeveloperRepository
    {
        public DeveloperRepository(RockResilienceContext context) : base(context)
        {

        }

        #region 已测

        //insert--------------------------------------------------------------------------------------------

        public bool Insert(DeveloperTest developer)
        {
            return base.Insert(developer);
        }

        public bool Insert(List<DeveloperTest> developers)
        {
            return base.Insert(developers);
        }

        //update--------------------------------------------------------------------------------------------

        public bool Update(DeveloperTest e)
        {
            return base.Update(e);
        }

        public bool Update(List<DeveloperTest> developers)
        {
            return base.Update(developers);
        }

        //select--------------------------------------------------------------------------------------------

        /// <summary>
        /// 获取DeveloperTest所有数据(用于某些类型表,一般的查询不会使用该方法)
        /// </summary>
        /// <returns></returns>
        public List<DeveloperTest> GetAllDeveloperTest()
        {
            var iq = base.GetAll();
            return iq != null ? iq.ToList() : new List<DeveloperTest>();
        }

        public DeveloperTest GetDeveloperTestById(int id)
        {
            return base.FirstOrDefault(id);
        }

        public IEnumerable<DeveloperTest> GetDeveloperTestByWhere(Expression<Func<DeveloperTest, bool>> where)
        {
            return base.GetByQuery(where);
        }

        //public async Task<List<DeveloperTest>> GetDeveloperTestByWhereAsync(Expression<Func<DeveloperTest, bool>> predicate)
        //{
        //    return await base.GetAllListAsync(predicate);
        //}

        public Task<List<DeveloperTest>> GetDeveloperTestByWhereAsync(Expression<Func<DeveloperTest, bool>> predicate)
        {
            return base.GetAllListAsync(predicate);
        }

        #region extention

        public bool exist(Expression<Func<DeveloperTest, bool>> predicate)
        {
            long nCount = base.Count(predicate);
            return nCount > 0 ? true : false;
        }

        //ok
        public IQueryable<DeveloperTest> GetDeveloperTestAll()
        {
            return base.GetAll();
        }

        public IQueryable<DeveloperTest> GetDeveloperTestAllIncluding(params Expression<Func<DeveloperTest, bool>>[] propertySelectors)
        {
            return base.GetAllIncluding(propertySelectors);
        }

        //ok
        public DeveloperTest FirstOrDefaultDeveloperTest(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true)
        {
            return base.FirstOrDefault(predicate, isNoTracking);
        }

        //ok
        public Task<DeveloperTest> FirstOrDefaultAsyncDeveloperTest(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true)
        {
            return base.FirstOrDefaultAsync(predicate, isNoTracking);
        }

        //ok
        public DeveloperTest FirstOrDefaultDeveloperTest(int id)
        {
            return base.FirstOrDefault(id);
        }

        //ok
        public Task<DeveloperTest> FirstOrDefaultAsyncDeveloperTest(int id)
        {
            return base.FirstOrDefaultAsync(id);
        }

        //ok
        public long DeveloperTestCount(Expression<Func<DeveloperTest, bool>> predicate = null)
        {
            return base.Count(predicate);
        }

        //ok
        public Task<long> DeveloperTestCountAsync(Expression<Func<DeveloperTest, bool>> predicate = null)
        {
            return base.CountAsync(predicate);
        }

        //ok
        public IQueryable<DeveloperTest> DeveloperTestLoad(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true)
        {
            return base.Load(predicate, isNoTracking);
        }

        //ok
        public Task<IQueryable<DeveloperTest>> DeveloperTestLoadAsync(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true)
        {
            return base.LoadAsync(predicate, isNoTracking);
        }

        #endregion

        //delete--------------------------------------------------------------------------------------------

        public bool DeleteById(DeveloperTest e)
        {
            return base.Delete(e);
        }

        public bool Delete(List<DeveloperTest> entitys)
        {
            return base.Delete(entitys);
        }

        public Task<bool> DeleteAsyncDeveloperTest(DeveloperTest entity, bool isSaveChange = true)
        {
            return base.DeleteAsync(entity, isSaveChange);
        }

        /// <summary>
        /// 删除实体列表(异步方式)
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsyncDeveloperTest(List<DeveloperTest> entitys, bool isSaveChange = true)
        {
            return base.DeleteAsync(entitys, isSaveChange);
        }

        //执行Sql语句--------------------------------------------------------------------------------------------

        /// <summary>
        /// 执行纯Sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSqlDeveloperTest(string sql)
        {
            return base.ExecuteSql(sql);
        }

        /// <summary>
        /// 执行纯Sql语句(异步方式)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsyncDeveloperTest(string sql)
        {
            return base.ExecuteSqlAsync(sql);
        }

        /// <summary>
        /// 执行带参数的sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public int ExecuteSqlDeveloperTest(string sql, List<DbParameter> spList)
        {
            return base.ExecuteSql(sql, spList);
        }

        /// <summary>
        /// 执行带参数的sql语句(异步方式)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsyncDeveloperTest(string sql, List<DbParameter> spList)
        {
            return base.ExecuteSqlAsync(sql, spList);
        }

        /// <summary>
        /// 执行sql语句,获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSqlDeveloperTest(string sql)
        {
            return base.GetDataTableWithSql(sql);
        }

        /// <summary>
        /// 执行带参数的sql语句,获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSqlDeveloperTest(string sql, List<DbParameter> spList)
        {
            return base.GetDataTableWithSql(sql, spList);
        }

        #endregion

        #region Testing

        public List<DeveloperTest> Testing()
        {
            return new List<DeveloperTest>();
        }

        #endregion

        #region 未测

        //Not work
        public IQueryable<DeveloperTest> GetDeveloperTestsByConditionNoAsync(params Expression<Func<DeveloperTest, bool>>[] predicate)
        {
            return base.GetAllIncluding(predicate);
        }

        #endregion
    }
}
