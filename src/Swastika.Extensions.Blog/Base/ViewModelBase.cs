using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Extension.Blog.Base
{
    public abstract class ViewModelBase<TModel, TView> where TModel : new() where TView : new()
    {
        //private Window _currentWindow;
        //private BaseRepo<TModel, TView> _baseRepo;
        //private TModel _model;
        //private IEventAggregator _eventHandler;
        //private string _modelName;
        //private int _errorCount;
        ////private ApiURLRepo _urlRepo;

        //private ICommand _saveCommand;
        //private DelegateCommand<Window> _saveAndCloseCommand;
        //private ICommand _removeCommand;
        //private ICommand _previewCommand;

        //private DelegateCommand<Window> _closeWindowCommand;
        //public ICommand SaveCommand
        //{
        //    get
        //    {
        //        if (_saveCommand == null)
        //        {
        //            _saveCommand = new RelayCommand(p => SaveModel(), p => CanSaveModel());
        //        }
        //        return _saveCommand;
        //    }

        //    set
        //    {
        //        _saveCommand = value;
        //    }
        //}
        //public DelegateCommand<Window> CloseWindowCommand
        //{
        //    get
        //    {
        //        if (_closeWindowCommand == null)
        //        {
        //            _closeWindowCommand = new DelegateCommand<Window>(CloseWindow);
        //        }
        //        return _closeWindowCommand;
        //    }

        //    set
        //    {
        //        _closeWindowCommand = value;
        //    }
        //}

        //public DelegateCommand<Window> SaveAndCloseCommand
        //{
        //    get
        //    {
        //        if (_saveAndCloseCommand == null)
        //        {
        //            _saveAndCloseCommand = new DelegateCommand<Window>(SaveAndCloseWindow, CanSaveAndClose);
        //        }
        //        return _saveAndCloseCommand;
        //    }

        //    set
        //    {
        //        _saveAndCloseCommand = value;
        //    }
        //}

        //private bool CanSaveAndClose(Window obj)
        //{
        //    return CanSaveModel();
        //}

        //private async void SaveAndCloseWindow(Window window)
        //{
        //    ViewToModel();
        //    var resp = await SaveModel();
        //    ApplicationService.Instance.GlobalEventAggregator.GetEvent<ItemChanged<TView>>().Publish(resp.StatusCode == System.Net.HttpStatusCode.OK);
        //    if (window != null)
        //    {

        //        if (resp.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            CloseWindow(window);
        //        }
        //    }

        //}

        //protected virtual void CloseWindow(Window window)
        //{
        //    if (window != null)
        //    {
        //        if (IsChanged)
        //        {
        //            if (common.ConfirmDialog("Bạn chưa lưu thông tin! tiếp tục đóng?", "Lưu ý"))
        //            {
        //                if (Model != null)
        //                {
        //                    ModelToView();
        //                }

        //                window.Close();
        //            }
        //        }
        //        else
        //        {
        //            window.Close();
        //            IsChanged = false;
        //        }

        //    }
        //}

        //public int ErrorCount
        //{
        //    get
        //    {
        //        return _errorCount;
        //    }

        //    set
        //    {
        //        _errorCount = value;
        //        OnPropertyChanged("ErrorCount");
        //    }
        //}

        //public TModel Model
        //{
        //    get
        //    {
        //        return _model;
        //    }

        //    set
        //    {
        //        _model = value;
        //        OnPropertyChanged("Model");
        //    }
        //}


        //public ICommand RemoveCommand
        //{
        //    get
        //    {
        //        if (_removeCommand == null)
        //        {
        //            _removeCommand = new RelayCommand(p => RemoveModel(), p => CanRemove());
        //        }
        //        return _removeCommand;
        //    }

        //    set
        //    {
        //        _removeCommand = value;
        //    }
        //}

        //public BaseRepo<TModel, TView> BaseRepo
        //{
        //    get
        //    {
        //        return _baseRepo;
        //    }

        //    set
        //    {
        //        _baseRepo = value;
        //    }
        //}
        //public string ModelName
        //{
        //    get
        //    {
        //        return _modelName;
        //    }

        //    set
        //    {
        //        _modelName = value;
        //    }
        //}

        //public IEventAggregator EventHandler
        //{
        //    get
        //    {
        //        if (_eventHandler == null)
        //        {
        //            _eventHandler = new EventAggregator();
        //        }
        //        return _eventHandler;
        //    }

        //    set
        //    {
        //        _eventHandler = value;
        //    }
        //}

        //public ICommand PreviewCommand
        //{
        //    get
        //    {
        //        if (_previewCommand == null)
        //        {
        //            _previewCommand = new RelayCommand(vm => Preview(), vm => CanPreview());
        //        }
        //        return _previewCommand;
        //    }

        //    set
        //    {
        //        _previewCommand = value;
        //    }
        //}

        //public Window CurrentWindow
        //{
        //    get
        //    {
        //        return _currentWindow;
        //    }

        //    set
        //    {
        //        _currentWindow = value;
        //    }
        //}

        //protected static IEventAggregator EventAggregator
        //{
        //    get
        //    {
        //        if (eventAggregator == null)
        //        {
        //            eventAggregator = new EventAggregator();
        //        }
        //        return eventAggregator;
        //    }

        //    set
        //    {
        //        eventAggregator = value;
        //    }
        //}


        //bool CanPreview()
        //{
        //    return Model != null;
        //}
        //public abstract void Preview();

        //public abstract void RemoveModel();
        //public abstract Task<IRestResponse> SaveModel();
        //public abstract bool CanSaveModel();
        //public abstract void ModelToView();
        //public abstract void ViewToModel();

        //public virtual bool CanRemove()
        //{
        //    return Model != null;
        //}
        //private void OnNotifiedOfPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e != null && !String.Equals(e.PropertyName, "IsChanged", StringComparison.Ordinal))
        //    {
        //        IsChanged = true;
        //    }
        //}
        //public ViewModelBase(string baseApiURL, string modelName)
        //{
        //    ModelName = modelName;
        //    //URLRepo = new ApiURLRepo(baseApiURL, modelName);
        //    BaseRepo = new BaseRepo<TModel, TView>(baseApiURL, modelName);
        //    this.PropertyChanged += new PropertyChangedEventHandler(OnNotifiedOfPropertyChanged);
        //}

        //public ViewModelBase()
        //{
        //    this.PropertyChanged += new PropertyChangedEventHandler(OnNotifiedOfPropertyChanged);
        //}
    }
}
