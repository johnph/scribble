// -----------------------------------------------------------------------
// <copyright file="CanvasView.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas.View
{
    using John.Scribble.Canvas.ViewModel;
    using John.Scribble.Infrastructure.Interfaces;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for CanvasView.xaml
    /// </summary>
    public partial class CanvasView : UserControl, IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasView" /> class.
        /// </summary>
        public CanvasView()
        {
            InitializeComponent();
            this.DataContext = new CanvasViewModel();
        }
    }
}
