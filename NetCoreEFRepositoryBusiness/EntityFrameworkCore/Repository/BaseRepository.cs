using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Microsoft.Data.SqlClient;
using Common.Extensions;

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

    /// <summary>
    /// The implementation of .net core ef code first repository(.net core ef 数据仓储的实现)
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BaseRepository<TDbContext, TEntity, TKey>
        : IRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
    {
        public TDbContext _dbContext { get; } = null;
        public DbSet<TEntity> _dbSet;

        /// <summary>
        /// 连接字符串
        /// </summary>
        protected string _connectionString { get; set; }

        public BaseRepository(TDbContext context)
        {
            _connectionString = context.Database.GetDbConnection().ConnectionString;

            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region 插入数据(同步和异步方式，保存单个实体和实体列表)

        public bool Insert(TEntity entity, bool isSaveChange = true)
        {
            _dbSet.Add(entity);
            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        public async Task<bool> InsertAsync(TEntity entity, bool isSaveChange = true)
        {
            _dbSet.Add(entity);
            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        public bool Insert(List<TEntity> entitys, bool isSaveChange = true)
        {
            _dbSet.AddRange(entitys);
            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

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

        #region 查找

        //public IQueryable<TEntity> GetAllAsNoFilter(params object[] filterStrings)
        //{
        //    return _dbSet.AsOpenMesNoFilter(_dbContext, filterStrings);
        //}

        public IQueryable<TEntity> GetAll()
        {
            return GetAllIncluding();
        }

        //public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
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

        public long Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                predicate = c => true;
            }
            return _dbSet.LongCount(predicate);
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                predicate = c => true;
            }
            return await _dbSet.LongCountAsync(predicate);
        }

        public TEntity FirstOrDefault(TKey id)
        {
            if (id == null)
            {
                return default(TEntity);
            }
            return _dbSet.Find(id);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, bool isNoTracking = true)
        {
            var data = isNoTracking ? _dbSet.Where(predicate).AsNoTracking() : _dbSet.Where(predicate);
            return data.FirstOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync(TKey id)
        {
            if (id == null)
            {
                return default(TEntity);
            }

            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null, bool isNoTracking = true)
        {
            var data = isNoTracking ? _dbSet.Where(predicate).AsNoTracking() : _dbSet.Where(predicate);
            return await data.FirstOrDefaultAsync();
        }

        //public List<TEntity> GetAllList()
        //{
        //    return GetAll().ToList();
        //}

        //public async Task<List<TEntity>> GetAllListAsync()
        //{
        //    return await GetAll().ToListAsync();
        //}

        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        //public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return GetAll().Single(predicate);
        //}

        //public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await GetAll().SingleAsync(predicate);
        //}

        public async Task<IQueryable<TEntity>> LoadAsync(Expression<Func<TEntity, bool>> predicate = null, bool isNoTracking = true)
        {
            if (predicate == null)
            {
                predicate = c => true;
            }
            return await Task.Run(() => isNoTracking ? _dbSet.Where(predicate).AsNoTracking() : _dbSet.Where(predicate));
        }

        public IQueryable<TEntity> Load(Expression<Func<TEntity, bool>> predicate = null, bool isNoTracking = true)
        {
            if (predicate == null)
            {
                predicate = c => true;
            }
            return isNoTracking ? _dbSet.Where(predicate).AsNoTracking() : _dbSet.Where(predicate);
        }

        #endregion

        #region 删除

        public bool Delete(TEntity entity, bool isSaveChange = true)
        {
            var iq = _dbSet.Where(e => e.Id.Equals(entity.Id));
            if (iq != null && iq.Count() == 1)
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
            return isSaveChange ? SaveChanges() > 0 : false;
        }

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

        #region 更新数据

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

        public async Task<bool> UpdateAsync(TEntity entity, List<string> updatePropertyList = null, bool isSaveChange = true)
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

        #region SQL语句

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

        public int ExecuteSql(string sql)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql);
        }

        public Task<int> ExecuteSqlAsync(string sql)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql);
        }

        public int ExecuteSql(string sql, List<DbParameter> spList)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, spList.ToArray());
        }

        public Task<int> ExecuteSqlAsync(string sql, List<DbParameter> spList)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql, spList.ToArray());
        }

        public virtual DataTable GetDataTableWithSql(string sql)
        {
            return GetDataTableWithSql(sql, null);
        }

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

        #endregion

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        #region add by 罗世杰 on 202008.12

        public IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> where)
        {
            if (where == null)
            {
                return _dbSet;
            }
            return this._dbSet.AsNoTracking().Where(where);
        }

        #endregion

    }
}
