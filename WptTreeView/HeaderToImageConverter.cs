﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WptTreeView
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;

            if (string.IsNullOrEmpty(path))
                return null;

            var image = "file-regular.png";

            var directoryName = Path.GetFileName(path);

            if (string.IsNullOrEmpty(directoryName))
                image = "hdd-regular.png";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "folder-regular.png";

            return new BitmapImage(new Uri($"pack://application:,,,/Images/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
