using ContactInfoApp.ViewModels;

namespace ContactInfoApp
{
    public partial class UsersListPage : ContentPage
    {
        public UsersListPage(UsersListViewModel usersListViewModel)
        {
            InitializeComponent();
            BindingContext = usersListViewModel;
        }
    }
}
