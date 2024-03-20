using System.ComponentModel.DataAnnotations;

namespace blog.entity
{
    /// <summary>
    /// 博客文章
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(50)]
        public required string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [MinLength(50)]
        public required string Content { get; set; }

        /// <summary>
        /// 文章属性：原创 / 转载
        /// </summary>
        [StringLength(10)]
        public string? Attribute { get; set; }

        /// <summary>
        /// 转载文章的原地址
        /// </summary>
        [StringLength(500)]
        public string? OriginalPath { get; set; }

        /// <summary>
        /// 文章回复
        /// </summary>
        //public List<Reply> Replies { get; set; }

        /// <summary>
        /// 阅读数
        /// </summary>
        public int TotalView { get; set; } = 0;

        /// <summary>
        /// 点赞数
        /// </summary>
        public int TotalLike { get; set; } = 0;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 状态 0 待发布（草稿） 1 正常显示  -1 隐藏
        /// </summary>
        public int State { get; set; } = 0;

        /// <summary>
        /// 置顶标记 0 不置顶  1 置顶
        /// </summary>
        public int Top { get; set; } = 0;
    }
}
