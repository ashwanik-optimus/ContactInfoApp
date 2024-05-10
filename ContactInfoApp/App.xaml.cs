using ContactInfoApp.Services;

namespace ContactInfoApp
{
    public partial class App : Application
    {

        public static IUserService UserService { get; private set; }

        public App(IUserService userService)
        {
            InitializeComponent();

            MainPage = new AppShell();
            UserService = userService;
        }
    }
}
