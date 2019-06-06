// -----------------------------------------------------------------------
// <copyright file="CanvasModel.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas.Model
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Scribble.Infrastructure.Enums;

    /// <summary>
    /// CanvasModel class
    /// </summary>
    [Serializable]
    public sealed class CanvasModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasModel" /> class.
        /// </summary>
        public CanvasModel() { }
        
        /// <summary>
        /// Variable for Modes array
        /// </summary>
        public DrawingMode[] Modes { get; set; }

        /// <summary>
        /// Variable for point array
        /// </summary>
        public Point[][] Points { get; set; }
    }
}
