// -----------------------------------------------------------------------
// <copyright file="CanvasViewModel.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas.ViewModel
{
    using System.Collections.Specialized;
    using System.Windows.Controls;
    using System.Windows.Ink;
    using John.Scribble.Canvas.Constants;
    using John.Scribble.Canvas.Extensions;
    using John.Scribble.Canvas.Model;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.ViewModel;
    using Microsoft.Practices.ServiceLocation;
    using Scribble.Infrastructure.Enums;
    using Scribble.Infrastructure.Events;

    /// <summary>
    /// CanvasViewModel class
    /// </summary>
    public class CanvasViewModel : NotificationObject
    {
        /// <summary>
        /// Variable for editing mode
        /// </summary>
        private InkCanvasEditingMode editingMode;

        /// <summary>
        /// Variable for resource key
        /// </summary>
        private DrawingMode resourceKey;

        /// <summary>
        /// Variable for stylus shape
        /// </summary>
        private StylusShape stylusShape;

        /// <summary>
        /// Variable for strokes
        /// </summary>
        private StrokeCollection strokes;

        /// <summary>
        /// Variable for event aggregator
        /// </summary>
        private IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasViewModel" /> class.
        /// </summary>
        public CanvasViewModel()
        {
            // Get instance of event aggregator
            this.eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

            // Initializes new instance of StrokeCollection class
            this.strokes = new StrokeCollection();

            // On Stroke change publish StrokeChangedEvent to update the count in statusbar
            (this.strokes as INotifyCollectionChanged).CollectionChanged += delegate
            {
                this.eventAggregator.GetEvent<StrokeChangedEvent>().Publish(this.strokes.Count);
            };

            // Subscribe to tool changed event
            eventAggregator.GetEvent<ToolChangedEvent>().Subscribe(param =>
            {
                this.OnToolChanged(param);               
            });
        }

        /// <summary>
        /// Gets or set editing mode
        /// </summary>
        public InkCanvasEditingMode EditingMode
        {
            get
            {
                return this.editingMode;
            }

            set
            {
                this.editingMode = value;
                this.RaisePropertyChanged(() => this.EditingMode);
            }
        }        

        /// <summary>
        /// Gets or set resource key
        /// </summary>
        public DrawingMode ResourceKey
        {
            get
            {
                return resourceKey;
            }

            set
            {
                resourceKey = value;
                this.RaisePropertyChanged(() => this.ResourceKey);
            }
        }        

        /// <summary>
        /// Gets or sets stylus shape
        /// </summary>
        public StylusShape StylusShape
        {
            get
            {
                return this.stylusShape;
            }

            set
            {
                this.stylusShape = value;
                this.RaisePropertyChanged(() => this.StylusShape);
            }
        }

        /// <summary>
        /// Gets or sets strokes
        /// </summary>
        public StrokeCollection Strokes
        {
            get { return this.strokes; }
            set { this.strokes = value; }
        }        

        /// <summary>
        /// Method to perform the canvas operation on tool change
        /// </summary>
        /// <param name="drawingMode"></param>
        private void OnToolChanged(DrawingMode drawingMode)
        {
            switch (drawingMode)
            {
                case DrawingMode.BlackPen:
                case DrawingMode.BluePen:
                case DrawingMode.RedPen:
                case DrawingMode.GreenPen:
                case DrawingMode.YellowHighlighter:
                case DrawingMode.PinkHighlighter:
                    this.EditingMode = InkCanvasEditingMode.Ink;
                    this.ResourceKey = drawingMode;
                    break;
                case DrawingMode.EraserByPointSmall:
                    this.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    this.StylusShape = new RectangleStylusShape(6, 6);
                    break;
                case DrawingMode.EraserByPointMedium:
                    this.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    this.StylusShape = new RectangleStylusShape(18, 18);
                    break;
                case DrawingMode.EraserByPointLarge:
                    this.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    this.StylusShape = new RectangleStylusShape(32, 32);
                    break;
                case DrawingMode.EraseByStroke:
                    this.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case DrawingMode.Select:
                    this.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case DrawingMode.Clear:
                    this.Strokes.Clear();
                    break;
                case DrawingMode.Save:
                    this.Save();
                    break;
                case DrawingMode.Open:
                    this.Strokes.Clear();
                    this.Open();
                    break;
                case DrawingMode.Exit:
                    System.Windows.Application.Current.Shutdown();
                    break;
                default:
                    this.EditingMode = InkCanvasEditingMode.None;
                    break;
            }
        }

        /// <summary>
        /// Method to save the canvas strokes
        /// </summary>
        private void Save()
        {
            CanvasModel canvasModel = new CanvasModel();

            // Call the extension method to convert the strokes in to point array
            canvasModel.Points = this.Strokes.GeneratePointArray();

            // Call the extension method to get the drawing modes of strokes
            canvasModel.Modes = this.Strokes.GetDrawingModes();

            // create a instance of file dialog box to specify the file name and location for save
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            // Set the filter that determines the file type
            saveFileDialog.Filter = CanvasConstants.FileType;

            if (saveFileDialog.ShowDialog() == true)
            {
                DataService.CanvasService canvasService = new DataService.CanvasService();

                // call the service method to serialize and save the the contents
                canvasService.Write(saveFileDialog.FileName, canvasModel);              
            }
        }

        /// <summary>
        /// Method to open a scribble file
        /// </summary>
        private void Open()
        {
            // create a instance of file dialog box to specify the file
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = CanvasConstants.FileType;

            // call showDialog to display the file dialog
            if (openFileDialog.ShowDialog() == true)
            {
                // Call service method to deserialize the file contents into Model
                DataService.CanvasService canvasService = new DataService.CanvasService();
                CanvasModel canvasModel = canvasService.Read(openFileDialog.FileName);

                for (int i = 0; i < canvasModel.Points.Length; i++)
                {
                    if (canvasModel.Points[i] != null)
                    {
                        // Call the extension method to convet the points array to storke
                        var strokes = canvasModel.Points[i].GenerateStroke((DrawingMode)canvasModel.Modes[i]);

                        // add the stroke to the collection
                        this.Strokes.Add(strokes);
                    }
                }
            }
        }
    }
}
