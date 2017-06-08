//using AutoMapper;

//namespace Swastika.Extension.Blog.Base {

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <typeparam name="TModel">The type of the model.</typeparam>
//    /// <typeparam name="TView">The type of the view.</typeparam>
//    /// <seealso cref="AutoMapper.Profile" />
//    public abstract class ViewModelBase<TModel, TView> : Profile where TModel : class where TView : ViewModelBase<TModel, TView> {
//        /// <summary>
//        /// The model
//        /// </summary>
//        private TModel _model;

//        //private ICommand _saveCommand;
//        //private ICommand _removeCommand;
//        //private ICommand _previewCommand;

//        //public abstract void Preview();
//        //public abstract void RemoveModel();
//        //public abstract bool SaveModel();

//        /// <summary>
//        /// Gets or sets the model.
//        /// </summary>
//        /// <value>
//        /// The model.
//        /// </value>
//        public TModel Model { get => _model; set => _model = value; }

//        /// <summary>
//        /// Parses the view.
//        /// </summary>
//        public virtual void ParseView() {
//            Mapper.Map<TModel, TView>(Model, (TView)this);
//        }

//        /// <summary>
//        /// Parses the model.
//        /// </summary>
//        public virtual void ParseModel() {
//            Mapper.Map<TView, TModel>((TView)this, Model);
//        }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="ViewModelBase{TModel, TView}"/> class.
//        /// </summary>
//        public ViewModelBase() {
//        }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="ViewModelBase{TModel, TView}"/> class.
//        /// </summary>
//        /// <param name="model">The model.</param>
//        public ViewModelBase(TModel model) {
//            Model = model;
//            ParseView();
//        }
//    }
//}