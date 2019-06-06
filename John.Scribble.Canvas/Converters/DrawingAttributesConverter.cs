// -----------------------------------------------------------------------
// <copyright file="DrawingAttributesConverter.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas.Converters
{
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Ink;
    using John.Scribble.Canvas.Constants;
    using Scribble.Infrastructure.Enums;

    /// <summary>
    /// DrawingAttributesConverter class
    /// </summary>
    public class DrawingAttributesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            DrawingMode targetMode = (DrawingMode)values[1];

            DrawingAttributes[] drawingAttributesList = (DrawingAttributes[])
                (CanvasConstants.DrawingAttributes);

            return drawingAttributesList[(int)targetMode];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
