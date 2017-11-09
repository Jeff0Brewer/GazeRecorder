using System;
using System.Windows;
using System.IO;
using Tobii.EyeX.Framework;
using EyeXFramework;

namespace Recorder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String path = "Recordings/";
        String name = "r";
        String ext = ".csv";
        String delim = ",";
        TextWriter tw;
        EyeXHost host;

        public MainWindow()
        {
            InitializeComponent();
            
            int num = 0;
            String currPath = path + name + num.ToString() + ext;
            while (File.Exists(currPath))
                currPath = path + name + (num++).ToString() + ext;
            tw = new StreamWriter(currPath);

            host = new EyeXHost();
            host.Start();
            var gazeData = host.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            gazeData.Next += newPoint;
        }

        private void newPoint(object s, EyeXFramework.GazePointEventArgs e)
        {
            tw.WriteLine(e.X.ToString() + delim + e.Y.ToString());
        }

        private void onExit(object s, EventArgs e) {
            tw.Close();
            host.Dispose();
        }
    }
}
