using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SimpleTaskManager.Models;
using Xamarin.Forms;

namespace SimpleTaskManager.Converters
{
    internal class TaskStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TaskStatus taskStatus = TaskStatus.Open;

            if (value is TaskStatus status)
            {
                taskStatus = status;
            }
            else if (value is string str)
            {
                Enum.TryParse<TaskStatus>(str, out taskStatus);
            }

            switch (taskStatus)
            {
                case TaskStatus.Open:
                    return Color.Black;
                    break;

                case TaskStatus.InProgress:
                    return Color.DarkOrange;
                    break;

                case TaskStatus.Done:
                    return Color.Green;
                    break;

                default:
                    return Color.Black;
                    break;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TaskStatus.Open;
        }
    }
}
