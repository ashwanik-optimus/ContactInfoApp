using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactInfoApp.Models;
using ContactInfoApp.Services;
using ContactInfoApp.Views;
using Plugin.Maui.Biometric;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ContactInfoApp.ViewModels
{
    public partial class UsersListViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; private set; } = new();

       

        [ObservableProperty]
        bool isRefreshing;

        readonly IUserService userService;

        public UsersListViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        [RelayCommand]
        async Task GetUserList()
        {
            if (IsLoading) return;

            try
            {
                IsLoading = true;
                if (Users.Any())
                {
                    Users.Clear();
                }
                var users = userService.GetUsers();
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get user info : {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Unable to get user info", "OK");
            }
            finally
            {
                IsRefreshing = false;
                IsLoading = false;
            }
        }

        [RelayCommand]
        async Task GoToUserDetails(int id)
        {
            if (id == 0) return;

            await Shell.Current.GoToAsync($"{nameof(UserDetailsPage)}?Id={id}", true);
        }

        [RelayCommand]
        async Task DeleteUserDetails(int id)
        {
            userService.DeleteUser(id);
            await GetUserList();
        }

        [RelayCommand]
        async Task AddNewUserDetails()
        {
            var result = await BiometricAuthenticationService.Default.AuthenticateAsync(new AuthenticationRequest()
            {
                Title = "Please authenticate to add user",
                NegativeText = "Cancel"
            }, CancellationToken.None);
            if ((result.Status == BiometricResponseStatus.Success))
            {
                await Shell.Current.GoToAsync($"{nameof(AddEditUserDetailsPage)}?Id=0", true);
            }
        }


    }
}
