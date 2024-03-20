using Microsoft.Extensions.Configuration;

namespace Gemini.Dapper
{
    public static class DapperClient<T> where T : class
    {
        /// <summary>
        /// 高校库
        /// </summary>
        public static DapperOperator<T> GaoXiao
        {
            get
            {
                return new DapperOperator<T>(ConfigService.GetConfiguration().GetConnectionString("DB_GAOXIAO"));
            }
        }

        /// <summary>
        /// 高校库
        /// </summary>
        public static DapperOperator<T> Guarantee
        {
            get
            {
                return new DapperOperator<T>(ConfigService.GetConfiguration().GetConnectionString("DB_GUARANTEE"));
            }
        }

        /// <summary>
        /// 高校库
        /// </summary>
        public static DapperOperator<T> HrBase
        {
            get
            {
                return new DapperOperator<T>(ConfigService.GetConfiguration().GetConnectionString("DB_HRBASE"));
            }
        }

        /// <summary>
        /// 高校库
        /// </summary>
        public static DapperOperator<T> HrCom
        {
            get
            {
                return new DapperOperator<T>(ConfigService.GetConfiguration().GetConnectionString("DB_HRCOM"));
            }
        }

        /// <summary>
        /// 高校库
        /// </summary>
        public static DapperOperator<T> HrPer
        {
            get
            {
                return new DapperOperator<T>(ConfigService.GetConfiguration().GetConnectionString("DB_HRPER"));
            }
        }
    }
}
