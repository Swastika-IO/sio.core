using System;
using System.Collections.Generic;
//using Swastika.Extension.Blog.Application.EventSourcedNormalizers;
using Swastika.Extension.Blog.Application.ViewModels;

namespace Swastika.Extension.Blog.Application.Interfaces
{
    public interface IBlogAppService : IDisposable
    {
        void Register(BlogViewModel blogViewModel);
        IEnumerable<BlogViewModel> GetAll();
        BlogViewModel GetById(Guid id);
        void Update(BlogViewModel blogViewModel);
        void Remove(Guid id);
        //IList<BlogHistoryData> GetAllHistory(Guid id);
    }
}
