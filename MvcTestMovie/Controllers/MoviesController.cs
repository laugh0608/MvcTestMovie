using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTestMovie.Data;
using MvcTestMovie.Models;

namespace MvcTestMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcTestMovieContext _context;

        // 构造函数使用依赖关系注入将数据库上下文 (MvcMovieContext) 注入到控制器中
        public MoviesController(MvcTestMovieContext context)
        {
            _context = context;
        }

        // 调用 List 方法时是如何创建 View 对象，代码将此 Movies 列表从 Index 操作方法传递给视图
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            // 如果数据上下文的 属性为 null，则代码返回 Movie
            return View(await _context.Movie.ToListAsync());
        }

        // id 参数通常作为路由数据传递
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lambda 表达式会被传入 FirstOrDefaultAsync 方法以选择与路由数据或查询字符串值相匹配的电影实体
            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            // 如果找到了电影，Movie 模型的实例则会被传递到 Details 视图
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // 提取电影并填充由 Edit.cshtmlRazor 文件生成的编辑表单
        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        //  HTTP POST Edit 方法，它会处理已发布的电影值：
        // [Bind] 特性是防止过度发布的一种方法，只应在 [Bind] 特性中包含想要更改的属性
        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // HttpPost 特性指定只能为 POST 请求调用此 Edit 方法
        [HttpPost]
        // ValidateAntiForgeryToken 特性用于防止请求伪造，并与编辑视图文件 (Views/Movies/Edit.cshtml) 中生成的防伪令牌匹配
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            // HttpGet Edit 方法采用电影 ID 参数，使用 Entity Framework FindAsync 方法查找电影
            // 将所选电影返回到“编辑”视图。 如果无法找到电影，则返回 NotFound (HTTP 404)
            if (id != movie.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
