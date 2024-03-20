using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using CollegeRecruit.Models;
using System.Data.Common;
using System.Data;

namespace CollegeRecruit.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public Dictionary<string, dynamic> repositories;
        private readonly WebDbcontext _context;
        protected IDbContextTransaction Transaction;
        public UnitOfWork(WebDbcontext context)
        {
            _context = context;
            repositories = new Dictionary<string, dynamic>();
        }

        /// <summary>
        /// 创建一个仓储实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T).Name;
            if (repositories.ContainsKey(type))
            {
                return repositories[type] as IRepository<T>;
            }
            var repositoryType = typeof(Repository<>);
            repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context));

            return repositories[type] as IRepository<T>;
        }

        public int? CommandTimeout
        {
            get => _context.Database.GetCommandTimeout();
            set => _context.Database.SetCommandTimeout(value);
        }

        #region sql操作

        /// <summary>
        /// 执行SQL语句，返回受影响的行数（不适合查询语句）
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlCommand(sql, parameters);
        }

        private DbCommand CreateCommand(string sql, params object[] parameters)
        {
            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            if (_context.Database.IsSqlServer())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
            }
            return cmd;
        }

        /// <summary>
        /// 执行sql查询，返回detatable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable SqlQuery(string sql, params object[] parameters)
        {
            var command = CreateCommand(sql, parameters);
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            _context.Database.GetDbConnection().Close();
            return dt;
        }

        /// <summary>
        /// 执行sql查询，返回List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<T> SqlQuery<T>(string sql, params object[] parameters) where T : class, new()
        {
            var dt = SqlQuery(sql, parameters);
            return dt.ToList<T>();
        }

        #endregion

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 创建一个事务
        /// </summary>
        [Obsolete("未经测试，慎用")]
        public void BeginTransaction()
        {
            Transaction = _context.Database.BeginTransaction();
        }

        [Obsolete("未经测试，慎用")]
        public bool Commit()
        {
            Transaction.Commit();
            return true;
        }

        [Obsolete("未经测试，慎用")]
        public void Rollback()
        {
            Transaction.Rollback();
        }

        #region IDisposable Support

        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~UnitOfWork()
        // {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
