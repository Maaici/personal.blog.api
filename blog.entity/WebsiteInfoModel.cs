using System.ComponentModel.DataAnnotations;

namespace blog.entity
{
    /// <summary>
    /// 网站相关信息配置
    /// </summary>
    public class WebsiteInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 网站名
        /// </summary>
        [MaxLength(20)]
        public required string WebsiteName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(20)]
        public required string NickName { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        [MaxLength(20)]
        public required string AreaName { get; set; }

        /// <summary>
        /// 出生日期，例：1992-11-25
        /// </summary>
        [MaxLength(20)]
        public string? BirthDay { get; set; }

        /// <summary>
        /// 个人信息下方的一段话
        /// </summary>
        [MaxLength(300)]
        public string? SomeWords { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        [MaxLength(200)]
        public required string photoPath { get; set; }

        /// <summary>
        /// 网站主背景图片
        /// </summary>
        [MaxLength(200)]
        public required string BackgroungImagePath { get; set; }
    }
}
