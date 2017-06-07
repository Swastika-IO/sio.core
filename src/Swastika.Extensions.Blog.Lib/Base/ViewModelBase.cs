using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Extension.Blog.Base
{
    public abstract class ViewModelBase<TModel, TView>: Profile where TModel : class where TView : ViewModelBase<TModel, TView>
    {
        private TModel _model;

        //private ICommand _saveCommand;
        //private ICommand _removeCommand;
        //private ICommand _previewCommand;

        //public abstract void Preview();
        //public abstract void RemoveModel();
        //public abstract bool SaveModel();

        public TModel Model { get => _model; set => _model = value; }

        
        public virtual void ParseView()
        {
            Mapper.Map<TModel, TView>(Model, (TView)this);
        }

        public virtual void ParseModel()
        {
            Model = Mapper.Instance.Map<TModel>(this);
        }

        public ViewModelBase()
        {
            
        }
        public ViewModelBase(TModel model)
        {
            Model = model;
            ParseView();
        }

    }
}
