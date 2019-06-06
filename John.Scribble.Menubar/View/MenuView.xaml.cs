// -----------------------------------------------------------------------
// <copyright file="MenuView.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Menubar.View
{
    using John.Scribble.Infrastructure.Interfaces;
    using John.Scribble.Menubar.ViewModel;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl, IView
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="MenuView" /> class.
        /// </summary>
        public MenuView()
        {
            InitializeComponent();
            this.DataContext = new MenuViewModel();
        }
    }
}
