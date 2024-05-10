using ContactInfoApp.ViewModels;

namespace ContactInfoApp.Views;

public partial class AddEditUserDetailsPage : ContentPage
{
	public AddEditUserDetailsPage(AddEditViewModel addEditViewModel)
	{
		InitializeComponent();
		BindingContext = addEditViewModel;
	}
}