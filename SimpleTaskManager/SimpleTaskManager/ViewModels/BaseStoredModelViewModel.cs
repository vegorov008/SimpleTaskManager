using System;
using System.Collections.Generic;
using System.Text;
using SimpleTaskManager.Services;

namespace SimpleTaskManager.ViewModels
{
    public abstract class BaseStoredModelViewModel<TModel> : BaseViewModel<TModel> where TModel : class
    {
        protected IDataStore<TModel> DataStore { get; set; }

        public BaseStoredModelViewModel() : base()
        {
            try
            {
                DataStore = GetService<IDataStore<TModel>>(); 
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
