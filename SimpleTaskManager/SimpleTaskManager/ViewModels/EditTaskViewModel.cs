using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleTaskManager.Models;
using SimpleTaskManager.Services;
using Xamarin.Forms;

namespace SimpleTaskManager.ViewModels
{
    public class EditTaskViewModel : BaseStoredModelModalViewModel<TaskModel>
    {
        public Guid TaskId { get; set; }

        public ICommand SaveCommand { get; protected set; }

        public EditTaskViewModel() : base()
        {
            try
            {
                SaveCommand = new Command(() =>
                {
                    try
                    {
                        if (!IsBusy)
                        {
                            IsBusy = true;
                            Task.Run(async () => await SaveAsync());
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

        async Task LoadAsync()
        {
            try
            {
                var model = await DataStore.GetItemAsync(TaskId);
                if (model != null)
                {
                    Model = model.Clone() as TaskModel;
                    OnPropertyChanged(nameof(Model));
                }
                else
                {
                    Back();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        async Task SaveAsync()
        {
            try
            {
                HideKeyboard();

                await DataStore.UpdateItemAsync(Model);
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

        public override void OnAppearing()
        {
            try
            {
                Task.Run(async () => await LoadAsync());
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
