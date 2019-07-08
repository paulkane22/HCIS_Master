using PJK.PRISM.HCIS2.Module.PatientManager.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace PJK.PRISM.HCIS2.Module.PatientManager
{
    public class PatientManagerModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<IMessageDialogService, MessageDialogService>();
        }
    }
}