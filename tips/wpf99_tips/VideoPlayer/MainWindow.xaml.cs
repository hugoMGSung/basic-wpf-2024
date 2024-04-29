using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace VideoPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            SldSeek.Value = Player.Position.TotalSeconds;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Player.Play();
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            Player.Pause();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }

        private void SldVolumne_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Volume = (double)e.NewValue;
        }

        private void SldSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Position = TimeSpan.FromSeconds(SldSeek.Value);
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string filename = (string)((DataObject)e.Data).GetFileDropList()[0];
            Player.Source = new Uri(filename, UriKind.RelativeOrAbsolute);

            Player.LoadedBehavior = MediaState.Manual;
            Player.UnloadedBehavior = MediaState.Manual;
            Player.Volume = (double)SldVolumne.Value;
            Player.Play();
        }

        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = Player.NaturalDuration.TimeSpan;
            SldSeek.Maximum = ts.TotalSeconds;
            timer.Start();
        }
    }
}