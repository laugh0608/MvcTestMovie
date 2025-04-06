using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTestMovie.Models;

public class Movie
{
    public int Id { get; set; }
    
    // 添加字段验证
    // Required 和 MinimumLength 特性表示属性必须有值；但用户可输入空格来满足此验证
    // StringLength 特性使你能够设置字符串属性的最大长度，以及可选的最小长度
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }
    
    // Display 特性指定要显示的字段名称的内容
    [Display(Name = "Release Date")]
    //  DataType 属性指定数据的类型（日期），使字段中存储的时间信息不会显
    [DataType(DataType.Date)]
    // 也可以显示置顶日期格式：
    // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    // 或者合并：
    // [Display(Name = "Release Date"), DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    // 添加字段验证
    // RegularExpression 特性用于限制可输入的字符
    // 只能使用字母，第一个字母必须为大写，允许使用空格，但不允许使用数字和特殊字符
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(30)]
    // 或者合并：
    // [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
    [Required]
    public string? Genre { get; set; }
    
    // 添加字段验证
    // Range 特性将值限制在指定范围内
    [Range(1, 100)]
    // DataType 属性用于指定比数据库内部类型更具体的数据类型，它们不是验证属性
    [DataType(DataType.Currency)]
    // 使 Entity Framework Core 能将 Price 正确地映射到数据库中的货币
    [Column(TypeName = "decimal(18, 2)")]
    // 或者合并：
    // [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    
    // 添加字段验证
    // 要求第一个字符为大写字母，允许在后续空格中使用特殊字符和数字。 “PG-13”对“分级”有效，但对于“分类”无效
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    // StringLength 特性使你能够设置字符串属性的最大长度，以及可选的最小长度
    [StringLength(5)]
    // 或者合并：
    // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
    [Required]
    // 添加分级字段
    public string? Rating {  get; set; }
}