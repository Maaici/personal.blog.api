using System;

namespace Gemini.Redis
{
    public interface ICache
    {
        /// <summary>
        /// 缓存过期时间
        /// </summary>
        int TimeOut { set; get; }
        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        object Get(string key);
        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        T Get<T>(string key);
        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove(string key);
        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        //void Clear();
        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        void Insert(string key, object data);
        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        void Insert<T>(string key, T data);
        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间(秒钟)</param>
        /// <param name="isAbsolute">表示该过期时间是否是绝对时间，默认为false,读取后会自动延期</param>
        void Insert(string key, object data, int cacheTime, bool isAbsolute = false);

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间(秒钟)</param>
        /// <param name="isAbsolute">表示该过期时间是否是绝对时间，默认为false,读取后会自动延期</param>
        void Insert<T>(string key, T data, int cacheTime, bool isAbsolute = false);

        /// <summary>
        /// 添加一个键值（仅仅存储值，区别与方法【 Insert 】，他将值包含在一段json里面）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        /// <param name="isAbsolute"></param>
        void InsertKey(string key, string data, int cacheTime, bool isAbsolute = false);

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        /// <param name="isAbsolute">表示该过期时间是否是绝对时间，默认为false,读取后会自动延期</param>
        void Insert(string key, object data, DateTime cacheTime, bool isAbsolute = false);
        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        /// <param name="isAbsolute">表示该过期时间是否是绝对时间，默认为false,读取后会自动延期</param>
        void Insert<T>(string key, T data, DateTime cacheTime, bool isAbsolute = false);
        /// <summary>
        /// 判断key是否存在
        /// </summary>
        bool Exists(string key);
    }
}
