using System.ComponentModel.DataAnnotations;

namespace blog.entity
{
    public class UsersLink
    {
        public int Id { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(50)]
        public required string Icon { get; set; }

        /// <summary>
        /// 站点名字，如：GitHub / csdn 请短一点
        /// </summary>
        [MaxLength(10)]
        public required string descr { get; set; }

        /// <summary>
        /// 跳转链接
        /// </summary>
        [MaxLength(1000)]
        public string? path { get; set; }

        /// <summary>
        /// 站点描述，如：maaici的github
        /// </summary>
        [MaxLength(50)]
        public string? text { get; set; }
    }
}
