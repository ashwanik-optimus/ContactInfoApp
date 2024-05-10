using ContactInfoApp.Models;
using ContactInfoApp.ViewModels;

namespace ContactInfoApp.Views;

public partial class UserDetailsPage : ContentPage
{
    UserDetailsViewModel userDetailsViewModel;
    public UserDetailsPage(UserDetailsViewModel userDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = this.userDetailsViewModel = userDetailsViewModel;
	}
}