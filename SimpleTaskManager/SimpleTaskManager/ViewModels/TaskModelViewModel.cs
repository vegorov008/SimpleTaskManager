using System;
using System.Collections.Generic;
using System.Text;
using SimpleTaskManager.Models;

namespace SimpleTaskManager.ViewModels
{
    public class TaskModelViewModel : BaseStoredModelViewModel<TaskModel>
    {
        List<string> _taskStatusesList;
        public List<string> TaskStatusesList
        {
            get => _taskStatusesList;
            set => SetProperty(ref _taskStatusesList, value);
        }

        public TaskModelViewModel(TaskModel model)
        {
            try
            {
                TaskStatusesList = new List<string>()
                {
                    TaskStatus.Open.ToString(),
                    TaskStatus.InProgress.ToString(),
                    TaskStatus.Done.ToString()
                };

                Model = model;

                this.PropertyChanged -= TaskModelViewModel_PropertyChanged;
                this.PropertyChanged += TaskModelViewModel_PropertyChanged;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void TaskModelViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == nameof(Status))
                {
                    DataStore.UpdateItemAsync(Model);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public string Title
        {
            get => Model?.Title ?? string.Empty;
            set
            {
                try
                {
                    if (Model != null)
                    {
                        Model.Title = value;
                        OnPropertyChanged(nameof(Title));
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                }
            }
        }

        public string Description
        {
            get => Model?.Description ?? string.Empty;
            set
            {
                try
                {
                    if (Model != null)
                    {
                        Model.Description = value;
                        OnPropertyChanged(nameof(Description));
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                }
            }
        }

        public string Status
        {
            get => Model?.Status.ToString() ?? string.Empty;
            set
            {
                try
                {
                    if (Model != null)
                    {
                        if (Enum.TryParse<TaskStatus>(value, out TaskStatus state))
                        {
                            Model.Status = state;
                            OnPropertyChanged(nameof(Status));
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                }
            }
        }

        public string CreationDate
        {
            get => Model?.CreationDate.ToShortDateString() ?? DateTime.MinValue.ToShortDateString();
        }
    }
}
