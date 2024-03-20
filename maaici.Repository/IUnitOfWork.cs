using System.Data;

namespace maaici.Repository
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// sql执行的超时时间
        /// </summary>
        int? CommandTimeout { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        Task<int> SaveChangesAsync();

        /// <summary>
        /// 执行sql查询语句，返回一个指定类型的list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        List<T> SqlQuery<T>(string sql, params object[] parameters) where T : class, new();

        /// <summary>
        /// 执行sql查询语句，返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DataTable SqlQuery(string sql, params object[] parameters);

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// 获取仓储实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// 开始一个事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        bool Commit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();
    }
}
