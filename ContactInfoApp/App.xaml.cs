using ContactInfoApp.Services;

namespace ContactInfoApp
{
    public partial class App : Application
    {

        public static UserService UserService { get; private set; }

        public App(UserService userService)
        {
            InitializeComponent();

            MainPage = new AppShell();
            UserService = userService;
        }
    }
}
