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
    public partial class EditTaskPage : ContentPage
    {
        protected EditTaskViewModel ViewModel { get; private set; }

        public EditTaskPage() : base()
        {
            try
            {
                InitializeComponent();
                ViewModel = BindingContext as EditTaskViewModel;
                ViewModel.Navigation = Navigation;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public EditTaskPage(Guid taskId) : this()
        {
            try
            {
                ViewModel.TaskId = taskId;
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