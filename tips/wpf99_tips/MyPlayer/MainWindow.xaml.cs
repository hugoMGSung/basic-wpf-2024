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
using System.Windows.Shapes;

namespace MyPlayer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
            // Create a VideoDrawing.
            //
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(@"minions.mp4", UriKind.Relative));

            VideoDrawing aVideoDrawing = new VideoDrawing();
            aVideoDrawing.Rect = new Rect(0, 0, 100, 100);
            aVideoDrawing.Player = player;
            // Play the video once.
            player.Play();
        }
    }
}
