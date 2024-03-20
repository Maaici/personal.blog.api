namespace Gemini.Redis
{
    public class RedisHelper
    {
        //单例模式创建一个redis连接
        public static RedisOperator Default { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis0")); } }
        public static RedisOperator Redis1 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis1")); } }
        public static RedisOperator Redis2 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis2")); } }
        public static RedisOperator Redis3 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis3")); } }

        //public static RedisOperator Redis4 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis4")); } }
        //public static RedisOperator Redis5 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis5")); } }
        //public static RedisOperator Redis6 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis6")); } }
        //public static RedisOperator Redis7 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis7")); } }
        //public static RedisOperator Redis8 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis8")); } }
        //public static RedisOperator Redis9 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis9")); } }
        //public static RedisOperator Redis10 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis10")); } }
        //public static RedisOperator Redis11 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis11")); } }
        //public static RedisOperator Redis12 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis12")); } }
        //public static RedisOperator Redis13 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis13")); } }
        //public static RedisOperator Redis14 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis14")); } }
        //public static RedisOperator Redis15 { get { return new RedisOperator(ConfigHelper.GetConnectionString("Redis15")); } }
    }

}
