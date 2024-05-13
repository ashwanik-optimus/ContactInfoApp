using ContactInfoApp.Models;
using ContactInfoApp.ViewModels;

namespace ContactInfoApp.Views;

public partial class UserDetailsPage : ContentPage
{
    public UserDetailsPage(UserDetailsViewModel userDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = userDetailsViewModel;
	}
}