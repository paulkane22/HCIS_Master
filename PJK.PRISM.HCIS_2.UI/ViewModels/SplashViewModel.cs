using Prism.Mvvm;

namespace PJK.PRISM.HCIS_2.UI.ViewModels
{
    public class SplashViewModel : BindableBase
    {
        private string _splashMessage = "HCIS Loading... Please wait. ";
        public string SplashMessage
        {
            get { return _splashMessage; }
            set { SetProperty(ref _splashMessage, value); }
        }


        public SplashViewModel()
        {

        }
    }
}
