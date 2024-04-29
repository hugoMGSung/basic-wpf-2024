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

namespace ex03_wpf_again
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SldTemp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PgbTemp.Value = e.NewValue;
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(PsbTemp.Password);
        }

        DispatcherTimer timerVideoTime;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(0.1);
            timerVideoTime.Tick += TimerVideoTime_Tick;
            MdeMovie.Stop();
        }

        private void TimerVideoTime_Tick(object? sender, EventArgs e)
        {
            ShowPosition();
        }

        private void MdeMovie_MediaOpened(object sender, RoutedEventArgs e)
        {
            sbarPosition.Minimum = 0;
            sbarPosition.Maximum =
                MdeMovie.NaturalDuration.TimeSpan.TotalSeconds;
            sbarPosition.Visibility = Visibility.Visible;
        }

        private void ShowPosition()
        {
            sbarPosition.Value = MdeMovie.Position.TotalSeconds;
            TxtPosition.Text =
                MdeMovie.Position.TotalSeconds.ToString("0.0");
        }

        private void EnableButtons(bool is_playing)
        {
            if (is_playing)
            {
                BtnCheck.IsEnabled = false;
                BtnToggle.IsEnabled = true;
                BtnPlay.Opacity = 0.5;
                BtnStop.Opacity = 1.0;
            }
            else
            {
                BtnCheck.IsEnabled = true;
                BtnToggle.IsEnabled = false;
                BtnPlay.Opacity = 1.0;
                BtnStop.Opacity = 0.5;
            }
            timerVideoTime.IsEnabled = is_playing;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            MdeMovie.Play();
            EnableButtons(true);
        }
    }
}