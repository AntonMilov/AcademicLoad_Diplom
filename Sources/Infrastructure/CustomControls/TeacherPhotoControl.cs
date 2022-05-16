using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Infrastructure.CustomControls
{
    /// <summary>
    /// Контрол для отображения фотографии преподаваля или иконки).
    /// </summary>
    public class TeacherPhotoControl : ContentControl
    {
        public static readonly DependencyProperty PhotoPathProperty =
             DependencyProperty.Register(nameof(PhotoPath), typeof(string), typeof(TeacherPhotoControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// Путь к фотографии.
        /// </summary>
        public string PhotoPath
        {
            get => (string)GetValue(PhotoPathProperty);
            set => SetValue(PhotoPathProperty, value);
        }
    }
}
