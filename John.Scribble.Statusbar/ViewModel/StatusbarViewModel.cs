// -----------------------------------------------------------------------
// <copyright file="StatusbarViewModel.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Statusbar.ViewModel
{
    using John.Scribble.Infrastructure.Enums;
    using John.Scribble.Infrastructure.Events;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.ViewModel;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// StatusbarViewModel class
    /// </summary>
    public class StatusbarViewModel : NotificationObject
    {
        /// <summary>
        /// Variable to display strokes count
        /// </summary>
        private string strokes = string.Format("{0} {1}", "Strokes Count = ", 0);

        /// <summary>
        /// Variable to display the selected tool
        /// </summary>
        private string selectedTool = string.Format("{0} {1}", "Selected Tool = ", "None");

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarViewModel" /> class.
        /// </summary>
        public StatusbarViewModel()
        {
            // Get instance of event aggregator
            IEventAggregator eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

            // Subcribe to stroke change event
            eventAggregator.GetEvent<StrokeChangedEvent>().Subscribe(count =>
            {
                this.Strokes = string.Format("{0} {1}", "Strokes Count = ", count);
            });

            // Subscribe to tool changed event
            eventAggregator.GetEvent<ToolChangedEvent>().Subscribe(param =>
            {
                if (param != DrawingMode.Clear)
                {
                    this.SelectedTool = string.Format("{0} {1}", "Selected Tool = ", param);
                }
            });
        }

        /// <summary>
        /// Gets or sets the strokes
        /// </summary>
        public string Strokes
        {
            get
            {
                return this.strokes;
            }

            set
            {
                this.strokes = value;
                this.RaisePropertyChanged(() => this.Strokes);
            }
        }

        /// <summary>
        /// Gets or sets the selected tool
        /// </summary>
        public string SelectedTool
        {
            get
            {
                return this.selectedTool;
            }

            set
            {
                this.selectedTool = value;
                this.RaisePropertyChanged(() => this.SelectedTool);
            }
        }
    }
}
