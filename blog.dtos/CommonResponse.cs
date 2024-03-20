namespace blog.dtos
{
    /// <summary>
    /// 通用的返回结果实体
    /// </summary>
    public class CommonResponse
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string RetMsg { get; set; } = "";
        public Object? RetData { get; set; }
    }
}
