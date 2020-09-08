using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTaskManager.Models;
using SimpleTaskManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTaskManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewTaskPage : ContentPage
    {
        protected AddNewTaskViewModel ViewModel { get; private set; }
        public AddNewTaskPage()
        {
            try
            {
                InitializeComponent();
                ViewModel = BindingContext as AddNewTaskViewModel;
                ViewModel.Navigation = Navigation;
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