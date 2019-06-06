// -----------------------------------------------------------------------
// <copyright file="StrokesCollectionExtension.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas.Extensions
{
    using System.Windows;
    using System.Windows.Ink;
    using Scribble.Infrastructure.Enums;

    /// <summary>
    /// StrokesCollectionExtension class
    /// </summary>
    public static class StrokesCollectionExtension
    {
        /// <summary>
        /// Method to generate point array
        /// </summary>
        /// <param name="strokes">stroke collection</param>
        /// <returns>point array</returns>
        public static Point[][] GeneratePointArray(this StrokeCollection strokes)
        {
            Point[][] pointArray = new System.Windows.Point[strokes.Count][];
            // canvasModel.Modes = new DrawingMode[strokes.Count];

            for (int i = 0; i < strokes.Count; i++)
            {
                pointArray[i] = new System.Windows.Point[strokes[i].StylusPoints.Count];
                // canvasModel.Modes[i] = this.GetDrawingMode(strokes[i].DrawingAttributes.Color.ToString());

                for (int j = 0; j < strokes[i].StylusPoints.Count; j++)
                {
                    pointArray[i][j] = new System.Windows.Point();
                    pointArray[i][j].X = strokes[i].StylusPoints[j].X;
                    pointArray[i][j].Y = strokes[i].StylusPoints[j].Y;
                }                
            }

            return pointArray;
        }

        /// <summary>
        /// Method to get drawing modes with color value
        /// </summary>
        /// <param name="strokes">strokes array</param>
        /// <returns>Array of DrawingMode</returns>
        public static DrawingMode[] GetDrawingModes(this StrokeCollection strokes)
        {
            DrawingMode[] drawingModeArray = new DrawingMode[strokes.Count];

            for (int i = 0; i < strokes.Count; i++)
            {
                DrawingMode drawingMode;

                string color = strokes[i].DrawingAttributes.Color.ToString();

                switch (color.ToLower())
                {
                    case "#ff000000":
                        drawingMode = DrawingMode.BlackPen;
                        break;
                    case "#ff0000ff":
                        drawingMode = DrawingMode.BluePen;
                        break;
                    case "#ffff0000":
                        drawingMode = DrawingMode.RedPen;
                        break;
                    case "#ff008000":
                        drawingMode = DrawingMode.GreenPen;
                        break;
                    case "#ffffff00":
                        drawingMode = DrawingMode.YellowHighlighter;
                        break;
                    case "#ffffc0cb":
                        drawingMode = DrawingMode.PinkHighlighter;
                        break;
                    default:
                        drawingMode = DrawingMode.BlackPen;
                        break;
                }

                drawingModeArray[i] = drawingMode;
            }

            return drawingModeArray;
        }
    }
}
