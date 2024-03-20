using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace Gemini.Redis
{
    public class RedisOperator : ICache
    {
        int Default_Timeout = 600;//默认超时时间（单位秒）
        JsonSerializerSettings jsonConfig = new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
        ConnectionMultiplexer connectionMultiplexer;
        IDatabase database;

        class CacheObject<T>
        {
            public int ExpireTime { get; set; }
            //是否是绝对过期时间
            public bool IsAbsolute { get; set; }
            public T Value { get; set; }
        }

        string GetJsonData(object data, double cacheTime, bool isAbsolute)
        {
            return GetJsonData<object>(data, cacheTime, isAbsolute);
        }

        string GetJsonData<T>(T data, double cacheTime, bool isAbsolute)
        {
            //一般就过期时间不会这么长，所以我这边类型转换就粗鲁一些
            var cacheObject = new CacheObject<T>() { Value = data, ExpireTime = 2147483647 > cacheTime ? (int)cacheTime : 2147483647, IsAbsolute = isAbsolute };
            return JsonConvert.SerializeObject(cacheObject, jsonConfig);//序列化对象
        }

        public RedisOperator(string config)
        {
            connectionMultiplexer = ConnectionMultiplexer.Connect(config);
            database = connectionMultiplexer.GetDatabase();
        }

        /// <summary>
        /// 连接超时设置
        /// </summary>
        public int TimeOut
        {
            get
            {
                return Default_Timeout;
            }
            set
            {
                Default_Timeout = value;
            }
        }

        public object Get(string key)
        {
            return Get<object>(key);
        }

        public T Get<T>(string key)
        {
            var cacheValue = database.StringGet(key);
            var value = default(T);
            if (!cacheValue.IsNull)
            {
                var cacheObject = JsonConvert.DeserializeObject<CacheObject<T>>(cacheValue, jsonConfig);
                if (!cacheObject.IsAbsolute)
                    database.KeyExpire(key, new TimeSpan(0, 0, cacheObject.ExpireTime));
                value = cacheObject.Value;
            }
            DateTime endJson = DateTime.Now;
            return value;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetWithNoTemple<T>(string key)
        {
            var cacheValue = database.StringGet(key);
            var value = default(T); 
            if (!cacheValue.IsNull)
            {
                value = JsonConvert.DeserializeObject<T>(cacheValue, jsonConfig);
            }
            return value;

        }

        /// <summary>
        /// 设置一个一对键值，永不过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void Insert(string key, object data)
        {
            var jsonData = GetJsonData(data, TimeOut, false);
            database.StringSet(key, jsonData);
        }

        /// <summary>
        /// 设置一个一对键值，永不过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void Insert<T>(string key, T data)
        {
            var jsonData = GetJsonData<T>(data, TimeOut, false);
            database.StringSet(key, jsonData);
        }

        public void Insert(string key, object data, int cacheTime, bool isAbsolute = false)
        {
            var timeSpan = TimeSpan.FromSeconds(cacheTime);
            var jsonData = GetJsonData(data, cacheTime, isAbsolute);
            database.StringSet(key, jsonData, timeSpan);
        }

        public void Insert<T>(string key, T data, int cacheTime, bool isAbsolute = false)
        {
            var timeSpan = TimeSpan.FromSeconds(cacheTime);
            var jsonData = GetJsonData<T>(data, cacheTime, isAbsolute);
            database.StringSet(key, jsonData, timeSpan);
        }

        /// <summary>
        /// 添加一个键值（仅仅存储值，区别与方法【 Insert 】，他将值包含在一段json里面）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        /// <param name="isAbsolute"></param>
        public void InsertKey(string key, string data, int cacheTime, bool isAbsolute = false)
        {
            var timeSpan = TimeSpan.FromSeconds(cacheTime);
            database.StringSet(key, data, timeSpan);
        }


        [Obsolete("建议用他的重载，直接传入秒数")]
        public void Insert(string key, object data, DateTime cacheTime, bool isAbsolute = false)
        {
            var timeSpan = cacheTime - DateTime.Now;
            string jsonData = GetJsonData(data, timeSpan.TotalSeconds, isAbsolute);
            database.StringSet(key, jsonData, timeSpan);
        }

        [Obsolete("建议用他的重载，直接传入秒数")]
        public void Insert<T>(string key, T data, DateTime cacheTime, bool isAbsolute = false)
        {
            var timeSpan = cacheTime - DateTime.Now;
            var jsonData = GetJsonData<T>(data, timeSpan.TotalSeconds, isAbsolute);
            database.StringSet(key, jsonData, timeSpan);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            database.KeyDelete(key);
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        public bool Exists(string key)
        {
            return database.KeyExists(key);
        }
    }
}
