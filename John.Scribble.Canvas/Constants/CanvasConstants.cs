// -----------------------------------------------------------------------
// <copyright file="CanvasConstants.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas.Constants
{
    using System.Windows.Ink;
    using System.Windows.Media;

    /// <summary>
    /// CanvasConstants static class
    /// </summary>
    public static class CanvasConstants
    {
        /// <summary>
        /// Drawing attributes for Pen (Black, Blue, Red, Green) and Highlighter (Yellow, Pink)
        /// </summary>
        public static readonly DrawingAttributes[] DrawingAttributes = new DrawingAttributes[]
        {
            new DrawingAttributes() 
            { 
                Color = Colors.Black, 
                StylusTip = StylusTip.Rectangle, 
                Height = 1.8, 
                Width = 1.8, 
                IsHighlighter = false
            },
            new DrawingAttributes() 
            { 
                Color = Colors.Blue, 
                StylusTip = StylusTip.Rectangle, 
                Height = 1.8, 
                Width = 1.8, 
                IsHighlighter = false
            },
            new DrawingAttributes() 
            { 
                Color = Colors.Red, 
                StylusTip = StylusTip.Rectangle, 
                Height = 1.8, 
                Width = 1.8, 
                IsHighlighter = false
            },
            new DrawingAttributes() 
            { 
                Color = Colors.Green, 
                StylusTip = StylusTip.Rectangle, 
                Height = 1.8, 
                Width = 1.8, 
                IsHighlighter = false
            },
            new DrawingAttributes() 
            { 
                Color = Colors.Yellow, 
                StylusTip = StylusTip.Rectangle, 
                Height = 32.4, 
                Width = 8.67, 
                IsHighlighter = true
            },
            new DrawingAttributes() 
            { 
                Color = Colors.Pink, 
                StylusTip = StylusTip.Rectangle, 
                Height = 32.4, 
                Width = 8.67, 
                IsHighlighter = true
            }
        };

        /// <summary>
        /// File type
        /// </summary>
        public static readonly string FileType = "scribble files (*.scrib)|*.scrib";
    }
}
