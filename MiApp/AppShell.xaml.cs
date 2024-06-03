using MiApp.Views;

namespace MiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(IMCPage), typeof(IMCPage));
        }
    }
}
