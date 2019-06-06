// -----------------------------------------------------------------------
// <copyright file="MenubarModule.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Menubar
{
    using John.Scribble.Infrastructure.Base;
    using John.Scribble.Infrastructure.Interfaces;
    using John.Scribble.Menubar.View;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// MenubarModule class
    /// </summary>
    [Module(ModuleName = "MenubarModule")]
    public class MenubarModule : BaseModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenubarModule" /> class.
        /// </summary>
        /// <param name="container">unity container</param>
        public MenubarModule(IUnityContainer container)
            : base(container) { }

        /// <summary>
        /// Method for registering menubar types with the container
        /// </summary>
        protected override void RegisterTypes()
        {
            // Register the MenuView with the container
            this.Container.RegisterType<IView, MenuView>("MenuView");        
        }
    }
}
