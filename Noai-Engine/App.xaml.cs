using Microsoft.Extensions.DependencyInjection;
using Core.Startup;

namespace Noai_Engine
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            new CoreStartup().ProjectFolderInit();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}