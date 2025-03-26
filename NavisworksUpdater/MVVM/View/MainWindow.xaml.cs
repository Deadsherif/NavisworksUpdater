using NavisworksUpdater.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavisworksUpdater.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;
        private  MainWindowViewModel _viewModel;
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
            _viewModel = mainWindowViewModel;
        }

        public bool IsClosed { get; private set; }

        public static MainWindow CreateInstance(MainWindowViewModel mainWindowViewModel)
        {
            if (instance == null || instance.IsClosed)
                instance = new MainWindow(mainWindowViewModel);
            else instance.Activate();
            return instance;
        }

        protected override void OnClosed(EventArgs e) => IsClosed = true;
       

    }
}
