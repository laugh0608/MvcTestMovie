using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTestMovie.Models;

namespace MvcTestMovie.Data
{
    // 对于 EF Core，使用模型执行数据访问。 模型由实体类和表示数据库会话的上下文对象构成
    // 上下文对象允许查询并保存数据
    // 数据库上下文派生自 Microsoft.EntityFrameworkCore.DbContext 并指定要包含在数据模型中的实体
    public class MvcTestMovieContext : DbContext
    {
        public MvcTestMovieContext (DbContextOptions<MvcTestMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcTestMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
