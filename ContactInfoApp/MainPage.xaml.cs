using ContactInfoApp.ViewModels;

namespace ContactInfoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(UsersListViewModel usersListViewModel)
        {
            InitializeComponent();
            BindingContext = usersListViewModel;
        }
    }
}
