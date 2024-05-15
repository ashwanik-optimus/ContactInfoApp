using ContactInfoApp.ViewModels;

namespace ContactInfoApp.Views;

public partial class AddEditUserDetailsPage : ContentPage
{
	public AddEditUserDetailsPage(AddEditUserDetailsViewModel addEditViewModel)
	{
		InitializeComponent();
		BindingContext = addEditViewModel;
	}
}