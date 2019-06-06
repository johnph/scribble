// -----------------------------------------------------------------------
// <copyright file="StatusbarView.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Statusbar.View
{
    using John.Scribble.Infrastructure.Interfaces;
    using John.Scribble.Statusbar.ViewModel;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for StatusbarView.xaml
    /// </summary>
    public partial class StatusbarView : UserControl, IView
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="StatusbarView" /> class.
        /// </summary>
        public StatusbarView()
        {
            InitializeComponent();
            this.DataContext = new StatusbarViewModel();
        }
    }
}
