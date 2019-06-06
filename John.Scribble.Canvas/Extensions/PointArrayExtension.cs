// -----------------------------------------------------------------------
// <copyright file="PointArrayExtension.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas.Extensions
{
    using System.Windows;
    using System.Windows.Ink;
    using System.Windows.Input;
    using Scribble.Infrastructure.Enums;
    using John.Scribble.Canvas.Constants;

    /// <summary>
    /// PointArrayExtension class
    /// </summary>
    public static class PointArrayExtension
    {
        /// <summary>
        /// Method to generate stroke
        /// </summary>
        /// <param name="pointArray">point array</param>
        /// <param name="drawingMode">drawingMode</param>
        /// <returns></returns>
        public static Stroke GenerateStroke(this Point[] pointArray, DrawingMode drawingMode)
        {
            StylusPointCollection stylusCollection = new StylusPointCollection(pointArray);
            Stroke stroke = new Stroke(stylusCollection);

            stroke.DrawingAttributes = (DrawingAttributes)CanvasConstants
                .DrawingAttributes[(int)(DrawingMode)drawingMode];

            return stroke;
        }
    }
}
