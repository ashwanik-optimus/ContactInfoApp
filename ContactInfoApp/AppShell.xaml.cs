using ContactInfoApp.Views;

namespace ContactInfoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));

        }
    }
}
