using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTestMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    // Display 特性指定要显示的字段名称的内容
    [Display(Name = "Release Date")]
    //  DataType 属性指定数据的类型（日期），使字段中存储的时间信息不会显
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    public string? Genre { get; set; }
    
    // 使 Entity Framework Core 能将 Price 正确地映射到数据库中的货币
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    
    // 添加分级字段
    public string? Rating {  get; set; }
}