using System;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace PJK.PRISM.HCIS_2.UI.ViewModels
{
    public class RibbonMainViewModel : BindableBase
    {

        private IEventAggregator _eventAggregator;

        public DelegateCommand AddProjectCommand { get; private set; }
        public DelegateCommand EditProjectCommand { get; private set; }
        public DelegateCommand DeleteProjectCommand { get; private set; }
        public DelegateCommand RefreshListCommand { get; private set; }

        public DelegateCommand SelectDBConnectionCommand { get; set; }


        public RibbonMainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            SelectDBConnectionCommand = new DelegateCommand(OnSelectDBConnection);
        }

        private void OnSelectDBConnection()
        {
            _eventAggregator.GetEvent<ShowConnectionEvent>().Publish();
        }
    }
}
