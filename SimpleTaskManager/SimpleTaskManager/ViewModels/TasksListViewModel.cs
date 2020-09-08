using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SimpleTaskManager.Models;
using SimpleTaskManager.Services;
using SimpleTaskManager.Views;
using SimpleTaskManager.Pages;
using System.Linq;

namespace SimpleTaskManager.ViewModels
{
    public class TasksListViewModel : BaseViewModel
    {
        readonly IDataStore<TaskModel> _dataStore;

        public ObservableCollection<TaskModelViewModel> Items { get; }
        public Command AddNewTaskCommand { get; }
        public Command RemoveTaskCommand { get; set; }
        public Command<TaskModelViewModel> ItemTapped { get; }

        public TasksListViewModel()
        {
            try
            {
                _dataStore = DependencyService.Resolve<IDataStore<TaskModel>>();

                Items = new ObservableCollection<TaskModelViewModel>();

                AddNewTaskCommand = new Command(() =>
                {
                    try
                    {
                        if (!IsBusy)
                        {
                            IsBusy = true;
                            AddNewTask();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.HandleException(ex);
                    }
                });

                ItemTapped = new Command<TaskModelViewModel>(OnItemTapped);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        async Task LoadItemsAsync()
        {
            try
            {
                Items.Clear();

                var items = await _dataStore.GetItemsAsync();
                if (items != null)
                {
                    items = items.OrderByDescending(x => x.CreationDate);
                    foreach (var item in items)
                    {
                        Items.Add(new TaskModelViewModel(item));
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        async void AddNewTask()
        {
            try
            {
                await Navigation.PushModalAsync(new AddNewTaskPage());
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

        public async void RemoveTask(TaskModelViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {
                    Items.Remove(viewModel);
                    await _dataStore.DeleteItemAsync(viewModel.Model.Id);
                }
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

        void OnItemTapped(TaskModelViewModel item)
        {
            try
            {
                if (item != null)
                {
                    Navigation.PushModalAsync(new TaskDetailsPage(item.Model));
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public override void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                Task.Run(async () =>
                {
                    try
                    {
                        await LoadItemsAsync();
                        OnPropertyChanged(nameof(Items));
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
    }
}