using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTaskManager.Models;
using SimpleTaskManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksListPage : ContentPage
    {
        protected TasksListViewModel ViewModel { get; private set; }

        public TasksListPage() : base()
        {
            try
            {
                InitializeComponent();
                ViewModel = BindingContext as TasksListViewModel;
                ViewModel.Navigation = Navigation;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item is TaskModelViewModel taskModelViewModel)
                {
                    ViewModel.ItemTapped.Execute(taskModelViewModel);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void MenuItem_RemoveClicked(object sender, EventArgs e)
        {
            try
            {
                if (sender is MenuItem menuItem)
                {
                    if (menuItem.BindingContext is TaskModelViewModel viewModel)
                    {
                        ViewModel.RemoveTask(viewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                ViewModel.OnAppearing();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        protected override void OnDisappearing()
        {
            try
            {
                base.OnDisappearing();
                ViewModel.OnDisappearing();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}