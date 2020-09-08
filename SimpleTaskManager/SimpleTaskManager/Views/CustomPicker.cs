using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SimpleTaskManager.Views
{
    public class CustomPicker : Picker
    {
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                base.OnPropertyChanged(propertyName);

                if (propertyName == Picker.SelectedIndexProperty.PropertyName)
                {
                    this.InvalidateMeasure();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
