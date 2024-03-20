namespace maaici.utils
{
    /// <summary>
    /// DateTime Extends
    /// </summary>
    public static class DateTimeExtends
    {
        /// <summary>
        /// 转成常用的格式, eg：2024-03-20 13:45:23
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToCommonFormats(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 格式化DateTime中的日期部分， eg: 2024-03-20
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}
