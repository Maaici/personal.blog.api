namespace blog.dtos.Query
{
    public class PageRequest
    {
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        public PageRequest()
        {
            Page = 1;
            Limit = 10;
        }

        /// <summary>
        /// 页数
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int Limit { get; set; }

        #region 预设查询字段

        public int QueryId1 { get; set; }
        public int QueryId2 { get; set; }
        public int QueryId3 { get; set; }
        public int QueryId4 { get; set; }
        public int QueryId5 { get; set; }

        public string? QueryStr1 { get; set; }
        public string? QueryStr2 { get; set; }
        public string? QueryStr3 { get; set; }
        public string? QueryStr4 { get; set; }
        public string? QueryStr5 { get; set; }

        #endregion
    }
}
