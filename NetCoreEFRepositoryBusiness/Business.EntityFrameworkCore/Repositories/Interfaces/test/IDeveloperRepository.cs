using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public interface IDeveloperRepository
        : IDeveloperRepository<DeveloperTest, int>
    {
        #region 已测

        //insert--------------------------------------------------------------------------------------------

        /// <summary>
        /// 添加单个DeveloperTest
        /// </summary>
        /// <param name="developer"></param>
        /// <returns></returns>
        public bool Insert(DeveloperTest developer);

        /// <summary>
        /// 添加多个DeveloperTest
        /// </summary>
        /// <param name="developers"></param>
        /// <returns></returns>
        public bool Insert(List<DeveloperTest> developers);

        //update--------------------------------------------------------------------------------------------

        /// <summary>
        /// 修改单个DeveloperTest
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Update(DeveloperTest e);

        /// <summary>
        /// 修改多个DeveloperTest
        /// </summary>
        /// <param name="developers"></param>
        /// <returns></returns>
        public bool Update(List<DeveloperTest> developers);

        //select--------------------------------------------------------------------------------------------

        /// <summary>
        /// 获取DeveloperTest所有数据(用于某些类型表,一般的查询不会使用该方法)
        /// </summary>
        /// <returns></returns>
        public List<DeveloperTest> GetAllDeveloperTest();

        /// <summary>
        /// 根据Id获取某个DeveloperTest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeveloperTest GetDeveloperTestById(int id);

        /// <summary>
        /// 根据查询条件(姓名列表,根据id列表(串)),获取DeveloperTest列表
        /// 
        /// add by 罗世杰 on 202008.12
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<DeveloperTest> GetDeveloperTestByWhere(Expression<Func<DeveloperTest, bool>> where);

        //public Task<List<DeveloperTest>> GetDeveloperTestByWhereAsync(Expression<Func<DeveloperTest, bool>> predicate);

        public Task<List<DeveloperTest>> GetDeveloperTestByWhereAsync(Expression<Func<DeveloperTest, bool>> predicate);

        #region extention

        public bool exist(Expression<Func<DeveloperTest, bool>> predicate);

        /// <summary>
        /// 获取DeveloperTest的IQueryable(无任何条件,一般情况不会使用)
        /// </summary>
        /// <returns></returns>
        public IQueryable<DeveloperTest> GetDeveloperTestAll();

        //not work
        public IQueryable<DeveloperTest> GetDeveloperTestAllIncluding(params Expression<Func<DeveloperTest, bool>>[] propertySelectors);

        /// <summary>
        /// 根据查询条件获取某个DeveloperTest
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public DeveloperTest FirstOrDefaultDeveloperTest(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// 根据查询条件获取某个DeveloperTest(异步)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public Task<DeveloperTest> FirstOrDefaultAsyncDeveloperTest(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// 根据id获取DeveloperTest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeveloperTest FirstOrDefaultDeveloperTest(int id);

        /// <summary>
        /// 根据id获取DeveloperTest(异步)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DeveloperTest> FirstOrDefaultAsyncDeveloperTest(int id);

        /// <summary>
        /// 根据查询条件，获取记录数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public long DeveloperTestCount(Expression<Func<DeveloperTest, bool>> predicate = null);

        /// <summary>
        /// 根据查询条件，获取记录数(异步)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<long> DeveloperTestCountAsync(Expression<Func<DeveloperTest, bool>> predicate = null);

        /// <summary>
        /// 根据查询条件，获取DeveloperTest的IQueryable
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public IQueryable<DeveloperTest> DeveloperTestLoad(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// 根据查询条件，获取DeveloperTest的IQueryable(异步方式)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public Task<IQueryable<DeveloperTest>> DeveloperTestLoadAsync(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true);

        #endregion

        //delete--------------------------------------------------------------------------------------------

        /// <summary>
        /// 删除单个DeveloperTest
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool DeleteById(DeveloperTest e);

        /// <summary>
        /// 删除多个DeveloperTest
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Delete(List<DeveloperTest> entitys);

        //not work
        /// <summary>
        /// 删除某个实体(异步方式)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsyncDeveloperTest(DeveloperTest entity, bool isSaveChange = true);

        //not work
        /// <summary>
        /// 删除实体列表(异步方式)
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsyncDeveloperTest(List<DeveloperTest> entitys, bool isSaveChange = true);

        //执行Sql语句--------------------------------------------------------------------------------------------

        /// <summary>
        /// 执行纯Sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSqlDeveloperTest(string sql);

        /// <summary>
        /// 执行纯Sql语句(异步方式)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsyncDeveloperTest(string sql);

        /// <summary>
        /// 执行带参数的sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public int ExecuteSqlDeveloperTest(string sql, List<DbParameter> spList);

        /// <summary>
        /// 执行带参数的sql语句(异步方式)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsyncDeveloperTest(string sql, List<DbParameter> spList);

        /// <summary>
        /// 执行sql语句,获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSqlDeveloperTest(string sql);

        /// <summary>
        /// 执行带参数的sql语句,获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSqlDeveloperTest(string sql, List<DbParameter> spList);

        #endregion

        #region Testing

        public List<DeveloperTest> Testing();

        #endregion

        #region 未测

        public IQueryable<DeveloperTest> GetDeveloperTestsByConditionNoAsync(Expression<Func<DeveloperTest, bool>>[] predicate);

        #endregion
    }

    public interface IDeveloperRepository<TEntity, TKey>
        : IRepository<RockResilienceContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
