using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading;
using System.Windows;


namespace PJK.PRISM.HCIS_2.UI.ViewModels
{
    public class SplashScreenViewModel : BindableBase
    {
        private string _title = "Splash";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public SplashScreenViewModel()
        {

        }
    }
}
