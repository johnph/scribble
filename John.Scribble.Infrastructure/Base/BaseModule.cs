// -----------------------------------------------------------------------
// <copyright file="BaseModule.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Infrastructure.Base
{
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// BaseModule Abstract class implements IModule interface
    /// </summary>
    public abstract class BaseModule : IModule
    {
        /// <summary>
        /// Abstract method to register types
        /// </summary>
        protected abstract void RegisterTypes();

        /// <summary>
        /// Gets or set Unity container
        /// </summary>
        protected IUnityContainer Container { get; set; }

        /// <summary>
        ///  Initializes a new instance of the <see cref="BaseModule" /> class.
        /// </summary>
        /// <param name="container">unity container</param>
        public BaseModule(IUnityContainer container)
        {
            this.Container = container;
        }

        /// <summary>
        /// Method to initialize the module
        /// </summary>
        public void Initialize()
        {
            this.RegisterTypes();
        }
    }
}
