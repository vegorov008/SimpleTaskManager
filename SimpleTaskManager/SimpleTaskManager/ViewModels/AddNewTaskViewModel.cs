using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleTaskManager.Models;
using SimpleTaskManager.Services;
using Xamarin.Forms;

namespace SimpleTaskManager.ViewModels
{
    public class AddNewTaskViewModel : BaseStoredModelModalViewModel<TaskModel>
    {
        public ICommand SaveCommand { get; protected set; }

        public AddNewTaskViewModel()
        {
            try
            {
                Model = new TaskModel();

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

        async Task SaveAsync()
        {
            try
            {
                HideKeyboard();

                Model.Id = Guid.NewGuid();
                Model.CreationDate = DateTime.Now;
                base.Model.Status = Models.TaskStatus.Open;

                await DataStore.AddItemAsync(Model);
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
}
