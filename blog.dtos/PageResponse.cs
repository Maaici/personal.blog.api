namespace blog.dtos
{
    public class PageResponse
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; } = 200;
        /// <summary>
        /// 操作消息
        /// </summary>
        public string RetMsg { get; set; } = "";

        /// <summary>
        /// 总记录条数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 数据内容
        /// </summary>
        public object? RetData { get; set; }
    }
}
