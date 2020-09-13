using System;
using AMD.Domain;
using MaterialDesignThemes.Wpf;
using MahApps.Metro.Controls;
using System.Windows.Navigation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AMD.Navigation;

namespace AMD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Navigation.NavigationServiceEx _navigationServiceEx;

        public static Snackbar Snackbar;

        public MainWindow()
        {
            MaterialDesignWindow.RegisterCommands(this);
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2500);
            }).ContinueWith(t =>
            {
                //note you can use the message queue from any thread, but just for the demo here we 
                //need to get the message queue from the snackbar, so need to be on the dispatcher
                MainSnackbar.MessageQueue.Enqueue("           Welcome to AMD Enterprise!");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            DataContext = new MainWindowViewModel(MainSnackbar.MessageQueue);

            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();


            this._navigationServiceEx = NavigationServiceEx.Instance;
            this._navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
            this.RootGrid.Children.Add(this._navigationServiceEx.Frame);

            // Navigate to login page.
            this.Loaded += (sender, args) =>
                this._navigationServiceEx.Navigate(new Uri("Views/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
        }
    }
}