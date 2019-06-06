// -----------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="John">
//  Scribble: A WPF Sample application
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Shell
{
    using John.Scribble.Infrastructure.Interfaces;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.UnityExtensions;
    using Microsoft.Practices.Unity;
    using System.Windows;

    /// <summary>
    /// Bootstrapper class for initialization of application
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Method to create a shell
        /// </summary>
        /// <returns>An instance of shell class</returns>
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        /// <summary>
        /// Method to initialize the shell as the main window
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        /// <summary>
        /// Method to load the modules from the directory
        /// </summary>
        /// <returns>The ModuleCatalog</returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }

        /// <summary>
        /// Method to initialize the modules
        /// </summary>
        protected override void InitializeModules()
        {
            base.InitializeModules();

            IRegionManager regionManager = this.Container.Resolve<IRegionManager>();

            // Register view with region
            if (regionManager.Regions.ContainsRegionWithName("MenuRegion") &&
                this.Container.IsRegistered(typeof(IView), "MenuView"))
            {
                regionManager.RegisterViewWithRegion("MenuRegion",
                    () => this.Container.Resolve<IView>("MenuView"));
            }

            if (regionManager.Regions.ContainsRegionWithName("CanvasRegion") &&
                this.Container.IsRegistered(typeof(IView), "CanvasView"))
            {
                regionManager.RegisterViewWithRegion("CanvasRegion",
                    () => this.Container.Resolve<IView>("CanvasView"));
            }

            if (regionManager.Regions.ContainsRegionWithName("StatusbarRegion") &&
                this.Container.IsRegistered(typeof(IView), "StatusbarView"))
            {
                regionManager.RegisterViewWithRegion("StatusbarRegion",
                    () => this.Container.Resolve<IView>("StatusbarView"));
            }
        }
    }
}
