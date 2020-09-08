using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SimpleTaskManager.Models;
using SimpleTaskManager.Services;
using SimpleTaskManager.Helpers;
using System.Threading.Tasks;

namespace SimpleTaskManager.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        protected IKeyboardHelper KeyboardHelper { get; set; }


        bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public BaseViewModel()
        {
            try
            {
                KeyboardHelper = GetService<IKeyboardHelper>();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public void HideKeyboard()
        {
            try
            {
                if (KeyboardHelper == null)
                {
                    KeyboardHelper = GetService<IKeyboardHelper>();
                }

                if (KeyboardHelper != null)
                {
                    KeyboardHelper.HideKeyboard();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        protected TService GetService<TService>() where TService : class
        {
            TService result = null;
            try
            {
                result = DependencyService.Get<TService>();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return result;
        }

        public virtual void OnAppearing()
        {

        }

        public virtual void OnDisappearing()
        {

        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            bool result = false;
            try
            {
                if (!EqualityComparer<T>.Default.Equals(backingStore, value))
                {
                    backingStore = value;
                    onChanged?.Invoke();
                    OnPropertyChanged(propertyName);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return result;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            try
            {
                var changed = PropertyChanged;
                if (changed == null)
                    return;

                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
        #endregion
    }

    public abstract class BaseViewModel<TModel> : BaseViewModel where TModel : class
    {
        TModel _model;
        public virtual TModel Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }

        public BaseViewModel() : base()
        {

        }
    }
}
