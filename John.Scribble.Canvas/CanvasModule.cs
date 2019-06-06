// -----------------------------------------------------------------------
// <copyright file="CanvasModule.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas
{
    using John.Scribble.Canvas.View;
    using John.Scribble.Infrastructure.Interfaces;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Unity;
    using Scribble.Infrastructure.Base;

    /// <summary>
    /// CanvasModule class
    /// </summary>
    [Module(ModuleName = "CanvasModule")]
    public class CanvasModule : BaseModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasModule" /> class.
        /// </summary>
        /// <param name="container">unity container</param>
        public CanvasModule(IUnityContainer container)
            : base(container) { }

        /// <summary>
        /// Method for registering canvas types with the container
        /// </summary>
        protected override void RegisterTypes()
        {
            // Register the CanvasView with the container
            this.Container.RegisterType<IView, CanvasView>("CanvasView");
        }
    }
}
