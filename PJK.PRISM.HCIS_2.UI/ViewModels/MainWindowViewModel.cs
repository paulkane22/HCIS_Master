
using System;
using System.Configuration;
using PJK.PRISM.HCIS_2.UI.Services;
using Prism.Events;
using Prism.Mvvm;

namespace PJK.PRISM.HCIS_2.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase, IWindowViewModel
    {
        private string _title = "HCIS II";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _statusBarMessage = "HCIS II";
        public string StatusBarMessage
        {
            get { return _statusBarMessage; }
            set { SetProperty(ref _statusBarMessage, value); }
        }


        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;


        public MainWindowViewModel(IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            _eventAggregator.GetEvent<ShowConnectionEvent>().Subscribe(OnShowConnectionList);
        }

        private void OnShowConnectionList()
        {

            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                string myMessage = "";

                foreach (ConnectionStringSettings cs in settings)
                {
                    myMessage += cs.Name + " :" + cs.ProviderName + " :" + cs.ConnectionString + "\n";
                }

                var value = _messageDialogService.ShowOKCancelDialog(myMessage, "Connection Strings");
            }


        }
    }
}
