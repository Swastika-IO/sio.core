using System;
using System.Collections.Generic;
using AutoMapper;
//using Swastika.Extension.Blog.Application.EventSourcedNormalizers;
using Swastika.Extension.Blog.Application.Interfaces;
using Swastika.Extension.Blog.Application.ViewModels;
using Swastika.Domain.Core.Bus;
using Swastika.Extension.Blog.Domain.Interfaces;
using Swastika.Extension.Blog.Domain.Commands;
using Swastika.Infrastructure.Data.Repository.EventSourcing;

namespace Swastika.Extension.Blog.Application.Services
{
    public class BlogAppService : IBlogAppService
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBus Bus;

        public BlogAppService(IMapper mapper, 
                                  IBlogRepository blogRepository, 
                                  IBus bus, 
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<BlogViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<BlogViewModel>>(_blogRepository.GetAll());
        }

        public BlogViewModel GetById(Guid id)
        {
            return _mapper.Map<BlogViewModel>(_blogRepository.GetById(id));
        }

        public void Register(BlogViewModel blogViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewBlogCommand>(blogViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(BlogViewModel blogViewModel)
        {
            var updateCommand = _mapper.Map<UpdateBlogCommand>(blogViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveBlogCommand(id);
            Bus.SendCommand(removeCommand);
        }

        //public IList<BlogHistoryData> GetAllHistory(Guid id)
        //{
        //    return BlogHistory.ToJavaScriptBlogHistory(_eventStoreRepository.All(id));
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
