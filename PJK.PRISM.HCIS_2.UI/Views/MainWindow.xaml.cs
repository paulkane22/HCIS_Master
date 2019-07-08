using System;
using System.Windows;
using System.Configuration;

namespace PJK.PRISM.HCIS_2.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetConnectionStrings();
            Console.ReadLine();
        }



        static void GetConnectionStrings()
        {
            ConnectionStringSettingsCollection settings =  ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    Console.WriteLine(cs.Name);
                    Console.WriteLine(cs.ProviderName);
                    Console.WriteLine(cs.ConnectionString);
                }
            }
        }

    }
}
