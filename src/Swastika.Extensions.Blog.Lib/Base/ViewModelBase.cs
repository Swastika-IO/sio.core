using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Extension.Blog.Base
{
    public abstract class ViewModelBase<TModel, TView> : Profile where TModel : class where TView : class
    {
        private TModel _model;
        private TView _view;

        //private ICommand _saveCommand;
        //private ICommand _removeCommand;
        //private ICommand _previewCommand;

        //public abstract void Preview();
        //public abstract void RemoveModel();
        //public abstract bool SaveModel();

        public TModel Model { get => _model; set => _model = value; }
        public TView View { get => _view; set => _view = value; }

        public virtual void RegisterAutoMapper()
        {
            CreateMap<TModel, TView>();
            CreateMap<TView, TModel>();
        }
        public virtual void ParseView()
        {
            View = Mapper.Map<TView>(Model);
        }

        public virtual void ParseModel()
        {
            Model = Mapper.Map<TModel>(View);
        }

        public ViewModelBase()
        {
            RegisterAutoMapper();
        }
        public ViewModelBase(TModel model)
        {
            Model = model;
            ParseView();
        }
    }
}
