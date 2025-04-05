using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTestMovie.Models;

namespace MvcTestMovie.Data
{
    public class MvcTestMovieContext : DbContext
    {
        public MvcTestMovieContext (DbContextOptions<MvcTestMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcTestMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
