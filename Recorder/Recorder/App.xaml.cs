using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EyeXFramework.Wpf;

namespace Recorder
{
    public partial class App : Application
    {
        private WpfEyeXHost _eyeXHost;
        public App()
        {
            _eyeXHost = new WpfEyeXHost();
            _eyeXHost.Start();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _eyeXHost.Dispose();
        }
    }
}
