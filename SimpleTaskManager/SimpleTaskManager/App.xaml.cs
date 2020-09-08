using System;
using SimpleTaskManager.Models;
using SimpleTaskManager.Services;
using SimpleTaskManager.Views;
using TxMobile.Storage.Services.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTaskManager
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();

                SqLiteDataProvider sqLiteDataProvider = new SqLiteDataProvider();

                DependencyService.RegisterSingleton<SqLiteDataProvider>(sqLiteDataProvider);
                DependencyService.RegisterSingleton<IDataStore<TaskModel>>(new SqLiteDataStore(sqLiteDataProvider));

                MainPage = new TasksListPage();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
