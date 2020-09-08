using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleTaskManager.ViewModels
{
    public abstract class BaseModalViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; protected set; }

        public BaseModalViewModel() : base()
        {
            try
            {
                BackCommand = new Command(() =>
                {
                    if (!IsBusy) Task.Run(async () => await Back());
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        protected async Task Back()
        {
            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    await Navigation.PopModalAsync();
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                IsBusy = false;
            }
        }
    }

    public abstract class BaseModalViewModel<TModel> : BaseViewModel<TModel> where TModel : class
    {
        public ICommand BackCommand { get; protected set; }

        public BaseModalViewModel() : base()
        {
            try
            {
                BackCommand = new Command(() =>
                {
                    try
                    {
                        if (!IsBusy)
                        {
                            IsBusy = true;
                            Back();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.HandleException(ex);
                    }
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        protected virtual async void Back()
        {
            try
            {
                HideKeyboard();
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public abstract class BaseStoredModelModalViewModel<TModel> : BaseStoredModelViewModel<TModel> where TModel : class
    {
        public ICommand BackCommand { get; protected set; }

        public BaseStoredModelModalViewModel() : base()
        {
            try
            {
                BackCommand = new Command(() =>
                {
                    try
                    {
                        if (!IsBusy)
                        {
                            IsBusy = true;
                            Back();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.HandleException(ex);
                    }
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        protected virtual async void Back()
        {
            try
            {
                HideKeyboard();
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
