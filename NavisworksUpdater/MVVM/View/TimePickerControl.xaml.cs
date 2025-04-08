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
    /// Interaction logic for TimePickerControl.xaml
    /// </summary>
    public partial class TimePickerControl : UserControl
    {
        public TimePickerControl()
        {
            InitializeComponent();
            Loaded += TimePickerControl_Loaded;
        }

        private void TimePickerControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is TimePickerViewModel vm)
            {
                vm.SelectedTime = this.SelectedTime;

                vm.PropertyChanged += (s, args) =>
                {
                    if (args.PropertyName == nameof(vm.SelectedTime))
                    {
                        // Sync ViewModel change to DependencyProperty
                        this.SelectedTime = vm.SelectedTime;
                    }
                };
            }
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register(
                nameof(SelectedTime),
                typeof(DateTime),
                typeof(TimePickerControl),
                new FrameworkPropertyMetadata(DateTime.Now, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedTimeChanged));

        public DateTime SelectedTime
        {
            get => (DateTime)GetValue(SelectedTimeProperty);
            set => SetValue(SelectedTimeProperty, value);
        }

        private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (TimePickerControl)d;
            if (control.DataContext is TimePickerViewModel vm)
            {
                var newTime = (DateTime)e.NewValue;
                if (vm.SelectedTime != newTime)
                    vm.SelectedTime = newTime;
            }
        }
    }
}
