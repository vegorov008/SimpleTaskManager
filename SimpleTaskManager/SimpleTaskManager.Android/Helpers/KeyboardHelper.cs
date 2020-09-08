using System;

using Android.App;
using Android.Content;
using Android.Views.InputMethods;
using SimpleTaskManager.Helpers;

namespace SimpleTaskManager.Droid.Helpers
{
    public class KeyboardHelper : IKeyboardHelper
    {
        Activity _context;

        public KeyboardHelper(Activity context)
        {
            _context = context;
        }

        public void HideKeyboard()
        {
            _context.RunOnUiThread(() =>
            {
                try
                {
                    var inputMethodManager = _context.GetSystemService(Context.InputMethodService) as InputMethodManager;
                    if (inputMethodManager != null && _context is Activity activity)
                    {
                        var token = activity.CurrentFocus?.WindowToken;
                        inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

                        activity.Window.DecorView.ClearFocus();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                }
            });
        }
    }
}