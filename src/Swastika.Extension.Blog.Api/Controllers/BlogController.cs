using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastika.Extensions.Blog.Repositories;
using Swastika.Extension.Blog.ViewModels;

namespace Swastika.Extension.Blog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Blog")]
    public class BlogController : Controller
    {
        private readonly BlogRepository _repo;

        public BlogController()
        {
            _repo = BlogRepository.GetInstance();
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<IEnumerable<BlogViewModel>> GetBlogAsync()
        {
            return await _repo.GetViewModelListAsync(false);
        }

        // GET: api/Blog/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _repo.GetSingleModelAsync(m => m.Id == id, false);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog([FromRoute] Guid id, [FromBody] BlogViewModel blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blog.Id)
            {
                return BadRequest();
            }

            var result = await _repo.EditModelAsync(blog.ParseModel());


            if (!_repo.isExists(blog.Model))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Blog
        [HttpPost]
        public async Task<IActionResult> PostBlog([FromBody] BlogViewModel blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repo.EditModelAsync(blog.ParseModel());

            return CreatedAtAction("GetBlog", new { id = result.Id }, result);
        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _repo.GetSingleModelAsync(m => m.Id == id, false);
            if (blog == null)
            {
                return NotFound();
            }

            await _repo.RemoveModelAsync(blog.Model);

            return Ok(blog);
        }
    }
}