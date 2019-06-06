// -----------------------------------------------------------------------
// <copyright file="MenuViewModel.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Menubar.ViewModel
{
    using System.Windows.Input;
    using John.Scribble.Infrastructure.Enums;
    using John.Scribble.Infrastructure.Events;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// MenuViewModel class
    /// </summary>
    public class MenuViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuViewModel" /> class.
        /// </summary>
        public MenuViewModel()
        {
            IEventAggregator eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

            this.MenuItemCommand = new DelegateCommand<DrawingMode?>(param => 
            {   
                eventAggregator.GetEvent<ToolChangedEvent>().Publish(param.Value); 
            });
        }

        /// <summary>
        /// Gets MenuItemCommand
        /// </summary>
        public ICommand MenuItemCommand { get; private set; }
    }
}
