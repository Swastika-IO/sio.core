using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swastika.Extensions.Blog.Repositories;
using Swastika.Extension.Blog.ViewModels;
using Swastika.Common.Helper;
using Swastika.UI.Base.Controllers;
using Swastika.UI.Base;
using System.Linq.Expressions;

namespace Swastika.Extension.Blog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Blog")]
    public class BlogController : BaseApiController<BlogViewModel>
    {
        private readonly BlogRepository _repo;

        public BlogController()
        {
            _repo = BlogRepository.GetInstance();
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<IActionResult> GetBlogAsync()
        {
            var result = await _repo.GetModelListAsync(b => b.CreatedUtc, "desc", 0, 10, false);
            return GetSuccessResult(result);
        }

        // GET: api/Blog
        [HttpPost]
        public async Task<IActionResult> GetBlogAsync([FromBody]RequestPaging request)
        {
            Expression<Func<Models.Blog, bool>> predicate = b => string.IsNullOrEmpty(request.Keyword)
            || b.Title.Contains(request.Keyword) || b.Name.Contains(request.Keyword);
            var result = await _repo.GetModelListByAsync(predicate, b => b.CreatedUtc, "desc", request.PageIndex, request.PageSize, false);
            return GetSuccessResult(result);
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
                blog = new BlogViewModel();
                //return NotFound(id);
            }
            return GetResult(1, blog, SWConstants.ResponseKey.OK.ToString(), string.Empty, string.Empty);
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
                return BadRequest(blog);
            }

            var result = await _repo.EditModelAsync(blog.ParseModel());


            if (!_repo.CheckIsExists(blog.Model))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Blog
        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> PostBlog([FromBody] BlogViewModel blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (blog.Id == default(Guid))
            {
                blog.Id = Guid.NewGuid();
                blog.CreatedUtc = DateTime.Now;
                blog.ModifiedUtc = DateTime.Now;
                blog.PublishedUtc = DateTime.Now;
            }
            var result = await _repo.SaveModelAsync(blog.ParseModel());
            return GetResult<BlogViewModel>(result != null ? 1 : 0, result, SWConstants.ResponseKey.OK.ToString(), string.Empty, string.Empty);
        }

        // DELETE: api/Blog/5
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteBlog([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _repo.GetSingleModelAsync(m => m.Id == id, false);
            if (blog == null)
            {
                return NotFound(id);
            }

            var result = await _repo.RemoveModelAsync(blog.ParseModel());
            return GetResult<bool>(result ? 1 : 0, result, SWConstants.ResponseKey.OK.ToString(), string.Empty, string.Empty);
            //return Ok(blog);
        }
    }
}