using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swastika.Extension.Blog.Data;
using Swastika.Extension.Blog.Models;
using Swastika.Extensions.Blog.Repositories;

namespace Swastika.Extensions.Blog.Web.Controllers
{
    public class ManageController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly BlogPostRepository _repo;

        public ManageController(BlogDbContext context)
        {
            _context = context;
            _repo = new BlogPostRepository(context);
        }

        // GET: Manage
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetViewModelListAsync(false));
        }

        // GET: Manage/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .SingleOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Manage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Title,Slug,Description,CreatedUtc,ModifiedUtc,PublishedUtc,CreatedByUserId,CommonStatusId,Id")] Extension.Blog.Models.Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Id = Guid.NewGuid();
                blog.CreatedByUserId = Guid.NewGuid().ToString();
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Manage/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Manage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Title,Slug,Description,CreatedUtc,ModifiedUtc,PublishedUtc,CreatedByUserId,CommonStatusId,Id")] Extension.Blog.Models.Blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Manage/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .SingleOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Manage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.Id == id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogExists(Guid id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }
    }
}
