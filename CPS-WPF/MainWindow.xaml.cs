using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CPS_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int clicks, ticks;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(1000000);
        }

        public void button_CPSPressed(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                // start the timer
                timer.IsEnabled = true;
                timer.Start();
            }
            clicks++;
        }

        public void button_ResetPressed(object sender, RoutedEventArgs e)
        {
            clicks = 0;
            ticks = 0;
            timer.Stop();
            Button_Click.IsEnabled = true;
            TextBlock_CPS.Text = "CPS: ";
        }

        private void timer_tick(object sender, EventArgs e)
        {
            TextBlock_CPS.Text = "CPS: " + clicks / ((float)ticks / 10);
            ticks++;
            if (ticks == 50)
            {
                Button_Click.IsEnabled = false;
                timer.Stop();
            }
        }
    }
}