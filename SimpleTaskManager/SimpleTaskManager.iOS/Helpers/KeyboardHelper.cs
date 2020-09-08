using System;
using SimpleTaskManager.Helpers;
using UIKit;
using Xamarin.Forms;

namespace SimpleTaskManager.iOS.Helpers
{
    internal class KeyboardHelper : IKeyboardHelper
    {
        public void HideKeyboard()
        {
            try
            {
                Device.InvokeOnMainThreadAsync(() =>
                {
                    try
                    {
                        UIApplication.SharedApplication.KeyWindow.EndEditing(true);
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