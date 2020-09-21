using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using Common.Domain.Entities;
using Common.Extensions;
using EntityFrameworkCore.Interface;

namespace EntityFrameworkCore.Repository
{
    public class BaseRepository<TDbContext, TEntity>
        : BaseRepository<TDbContext, TEntity, int>, IRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class, IEntity
    {
        public BaseRepository(TDbContext context) : base(context)
        {
        }
    }

    public abstract class BaseRepository<TDbContext, TEntity, TKey>
        : IRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
    {
        public TDbContext _dbContext { get; }
        public DbSet<TEntity> _dbSet;

        protected string _connectionString { get; }

        public BaseRepository(TDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();

            _connectionString = context.Database.GetDbConnection().ConnectionString;
        }

        #region insert entity or entities

        /// <summary>
        /// insert single entity(synchronize)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public bool Insert(TEntity entity, bool isSaveChange = true)
        {
            _dbSet.Add(entity);
            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// insert single entity(asynchronous)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(TEntity entity, bool isSaveChange = true)
        {
            _dbSet.Add(entity);
            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        /// <summary>
        /// insert entities(synchronize)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public bool Insert(List<TEntity> entitys, bool isSaveChange = true)
        {
            _dbSet.AddRange(entitys);
            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// insert entities(asynchronous)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(List<TEntity> entitys, bool isSaveChange = true)
        {
            _dbSet.AddRange(entitys);
            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        #endregion

        #region update entity or entities

        /// <summary>
        /// update specified properties of a table(synchronize)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <param name="updatePropertyList"></param>
        /// <returns></returns>
        public bool Update(TEntity entity, bool isSaveChange = true, List<string> updatePropertyList = null)
        {
            if (entity == null)
            {
                return false;
            }
            _dbSet.Attach(entity);
            var entry = _dbContext.Entry(entity);
            if (updatePropertyList == null)
            {
                entry.State = EntityState.Modified;//全字段更新
            }
            else
            {

                updatePropertyList.ForEach(c =>
                {
                    entry.Property(c).IsModified = true; //部分字段更新的写法
                });


            }
            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(TEntity entity, bool isSaveChange = true, List<string> updatePropertyList = null)
        {
            if (entity == null)
            {
                return false;
            }
            _dbSet.Attach(entity);
            var entry = _dbContext.Entry<TEntity>(entity);
            if (updatePropertyList == null)
            {
                entry.State = EntityState.Modified;//全字段更新
            }
            else
            {
                updatePropertyList.ForEach(c =>
                {
                    entry.Property(c).IsModified = true; //部分字段更新的写法
                });

            }
            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        public bool Update(List<TEntity> entitys, bool isSaveChange = true)
        {
            if (entitys == null || entitys.Count == 0)
            {
                return false;
            }
            entitys.ForEach(c =>
            {
                Update(c, false);
            });
            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// update entities(asynchronous)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(List<TEntity> entitys, bool isSaveChange = true)
        {
            if (entitys == null || entitys.Count == 0)
            {
                return false;
            }
            entitys.ForEach(c =>
            {
                _dbSet.Attach(c);
                _dbContext.Entry<TEntity>(c).State = EntityState.Modified;
            });
            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        #endregion

        #region query entity or entities

        /// <summary>
        /// Get the IQueryable of all data of a table
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return GetAllIncluding();
        }

        /// <summary>
        /// Get IQueryable of particular entity by query conditions
        /// </summary>
        /// <param name="predicate">query conditions</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public IQueryable<TEntity> Load(Expression<Func<TEntity, bool>> predicate = null, bool isNoTracking = true)
        {
            if (predicate == null)
            {
                predicate = c => true;
            }
            return isNoTracking ? _dbSet.Where(predicate).AsNoTracking() : _dbSet.Where(predicate);
        }

        /// <summary>
        /// Get IQueryable of particular entity by conditions
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, bool>>[] propertySelectors)
        {
            var query = _dbSet.AsQueryable();

            if (!propertySelectors.IsNullOrEmpty())
            {
                foreach (var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }

        /// <summary>
        /// Get IQueryable of particular entity by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> LoadAsync(Expression<Func<TEntity, bool>> predicate = null, bool isNoTracking = true)
        {
            if (predicate == null)
            {
                predicate = c => true;
            }
            return await Task.Run(() => isNoTracking ? _dbSet.Where(predicate).AsNoTracking() : _dbSet.Where(predicate));
        }

        /// <summary>
        /// Get List of particular entity by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Get enumerable of particular entity by conditions(asynchronous)
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> where)
        {
            if (where == null)
            {
                return _dbSet;
            }
            return this._dbSet.AsNoTracking().Where(where);
        }

        /// <summary>
        /// Get the first entity from the list which queried by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, bool isNoTracking = true)
        {
            var data = isNoTracking ? _dbSet.Where(predicate).AsNoTracking() : _dbSet.Where(predicate);
            return data.FirstOrDefault();
        }

        /// <summary>
        /// Get the first entity from the list which queried by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate">query conditions</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null, bool isNoTracking = true)
        {
            var data = isNoTracking ? _dbSet.Where(predicate).AsNoTracking() : _dbSet.Where(predicate);
            return await data.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get the entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity FirstOrDefault(TKey id)
        {
            if (id == null)
            {
                return default(TEntity);
            }
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Get the entity by Id(asynchronous)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstOrDefaultAsync(TKey id)
        {
            if (id == null)
            {
                return default(TEntity);
            }

            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Get the queried row count by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public long Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                predicate = c => true;
            }
            return _dbSet.LongCount(predicate);
        }

        /// <summary>
        /// Get the queried row count by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                predicate = c => true;
            }
            return await _dbSet.LongCountAsync(predicate);
        }

        //public IQueryable<TEntity> GetAllAsNoFilter(params object[] filterStrings)
        //{
        //    return _dbSet.AsOpenMesNoFilter(_dbContext, filterStrings);
        //}

        //public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)

        //public List<TEntity> GetAllList()
        //{
        //    return GetAll().ToList();
        //}

        //public async Task<List<TEntity>> GetAllListAsync()
        //{
        //    return await GetAll().ToListAsync();
        //}

        //public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return GetAll().Single(predicate);
        //}

        //public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await GetAll().SingleAsync(predicate);
        //}

        #endregion

        #region delete entity or entities

        /// <summary>
        /// delete a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity, bool isSaveChange = true)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);

            return isSaveChange ? SaveChanges() > 0 : false;
        }

        /// <summary>
        /// delete entities
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public bool Delete(List<TEntity> entitys, bool isSaveChange = true)
        {
            entitys.ForEach(entity =>
            {
                var iq = _dbSet.Where(e => e.Id.Equals(entity.Id));
                if (iq != null && iq.Count() == 1)
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            });

            return isSaveChange ? SaveChanges() > 0 : false;
        }

        /// <summary>
        /// delete a entity(asynchronous)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(TEntity entity, bool isSaveChange = true)
        {
            var iq = _dbSet.Where(e => e.Id.Equals(entity.Id));
            if (iq != null && iq.Count() == 1)
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }

            return isSaveChange ? await SaveChangesAsync() > 0 : false;
        }

        /// <summary>
        /// delete entities(asynchronous)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(List<TEntity> entitys, bool isSaveChange = true)
        {
            entitys.ForEach(entity =>
            {
                var iq = _dbSet.Where(e => e.Id.Equals(entity.Id));
                if (iq != null && iq.Count() == 1)
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            });
            return isSaveChange ? await SaveChangesAsync() > 0 : false;
        }

        #endregion

        #region Execute sql

        /// <summary>
        /// Execute sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql);
        }

        /// <summary>
        /// Execute sql(asynchronous)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsync(string sql)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql);
        }

        /// <summary>
        /// Execute sql which has parameters
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<DbParameter> spList)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, spList.ToArray());
        }

        /// <summary>
        /// Execute sql which has parameters(asynchronous)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsync(string sql, List<DbParameter> spList)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql, spList.ToArray());
        }

        /// <summary>
        /// Execute query sql and return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataTable GetDataTableWithSql(string sql)
        {
            return GetDataTableWithSql(sql, null);
        }

        /// <summary>
        /// Execute query sql which has parameters and return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public virtual DataTable GetDataTableWithSql(string sql, List<DbParameter> spList)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.CommandType = CommandType.Text;
                if (spList != null && spList.ToArray() != null)
                {
                    da.SelectCommand.Parameters.AddRange(spList.ToArray());
                }
                da.Fill(dt);
            }
            return dt;
        }

        //public virtual void BulkInsert<T>(IList<T> entities)
        //{
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = _connectionString;
        //        if (conn.State != ConnectionState.Open)
        //        {
        //            conn.Open();
        //        }

        //        string tableName = string.Empty;
        //        var tableAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
        //        if (tableAttribute != null)
        //            tableName = ((TableAttribute)tableAttribute).Name;
        //        else
        //            tableName = typeof(T).Name + "s";

        //        SqlBulkCopy sqlBC = new SqlBulkCopy(conn)
        //        {
        //            BatchSize = 100000,
        //            BulkCopyTimeout = 0,
        //            DestinationTableName = tableName
        //        };
        //        foreach (System.Reflection.PropertyInfo item in typeof(T).GetProperties())
        //        {
        //            sqlBC.ColumnMappings.Add(item.Name, item.Name);
        //        }
        //        using (sqlBC)
        //        {
        //            sqlBC.WriteToServer(entities.ToDataTable());
        //        }
        //    }
        //}

        #endregion

        /// <summary>
        /// make change commit
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// make change commit(asynchronous)
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

    }
}
