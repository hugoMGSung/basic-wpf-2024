using System;
using System.IO;
using System.Windows;

namespace VLCplayer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.VlcControl.Loaded += VlcControl_Loaded;
        }

        void VlcControl_Loaded(object sender, RoutedEventArgs e)
        {
            VlcControl_LoadVideo("D:\\Temp\\minions.mp4");
        }

        void VlcControl_LoadVideo(string videoPath)
        {
            var currentDir = AppDomain.CurrentDomain.BaseDirectory;
            var VlcDir = System.IO.Path.Combine(currentDir, "VLC");

            var VlcLibDirectory = new DirectoryInfo(VlcDir);

            var options=new string[] { };
            VlcControl.SourceProvider.CreatePlayer(VlcLibDirectory, options);
            VlcControl.SourceProvider.MediaPlayer.Play(new Uri(videoPath));
        }

        void ForwordBtn_Click(object sender, RoutedEventArgs e)
        {
            VlcControl.SourceProvider.MediaPlayer.Rate = 2;
        }
    }
}
