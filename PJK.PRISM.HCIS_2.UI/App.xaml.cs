using PJK.PRISM.HCIS_2.UI.ViewModels;
using PJK.PRISM.HCIS_2.UI.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using System;
using PJK.PRISM.HCIS_2.UI.Services;

namespace PJK.PRISM.HCIS_2.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Splash>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMessageDialogService, MessageDialogService>();
        }



        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            //moduleCatalog.AddModule<Module.Mana.ManaModule>();
            //moduleCatalog.AddModule<Module.ExampleControls.ExampleControlsModule>();
            //// moduleCatalog.AddModule<Module.Projects.ProjectsModule>();
        }



        private void PrismApplication_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {

            MessageBox.Show("Unexpected error occurred. Please contact MDSAS Support" + Environment.NewLine + e.Exception.Message, "This is not the error you are looking for");

            e.Handled = true;

        }
    }
}
