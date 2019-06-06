// -----------------------------------------------------------------------
// <copyright file="MenubarModule.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Statusbar
{
    using John.Scribble.Infrastructure.Base;
    using John.Scribble.Infrastructure.Interfaces;
    using John.Scribble.Statusbar.View;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// StatusbarModule class
    /// </summary>
    [Module(ModuleName = "StatusbarModule")]
    public class StatusbarModule : BaseModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarModule" /> class.
        /// </summary>
        /// <param name="container">unity container</param>       
        public StatusbarModule(IUnityContainer container)
            : base(container) { }

        /// <summary>
        /// Method for registering statusbar types with the container
        /// </summary>
        protected override void RegisterTypes()
        {
            // Register the StatusView with the container
            this.Container.RegisterType<IView, StatusbarView>("StatusbarView");
        }
    }
}
