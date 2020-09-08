using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleTaskManager.Models;
using SimpleTaskManager.Services;
using SimpleTaskManager.Views;
using Xamarin.Forms;

namespace SimpleTaskManager.ViewModels
{
    public class TaskDetailsViewModel : BaseStoredModelModalViewModel<TaskModel>
    {
        public Guid TaskId { get; set; }

        public ICommand EditCommand { get; protected set; }

        public TaskDetailsViewModel() : base()
        {
            try
            {
                EditCommand = new Command(() =>
                {
                    try
                    {
                        if (!IsBusy)
                        {
                            IsBusy = true;
                            EditAsync();
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
                    Model = model;
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

        async void EditAsync()
        {
            try
            {
                await Navigation.PushModalAsync(new EditTaskPage(TaskId));
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
