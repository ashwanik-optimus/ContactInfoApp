using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactInfoApp.Models;
using ContactInfoApp.Services;
using ContactInfoApp.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ContactInfoApp.ViewModels
{
    public partial class UsersListViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; private set; } = new();


        [ObservableProperty]
        bool isRefreshing;
        public UsersListViewModel()
        {
            Title = "User List";
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
                var users = App.UserService.GetUsers();
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
        async Task GetUserDetails(int id)
        {
            if (id == 0) return;

            await Shell.Current.GoToAsync($"{nameof(UserDetailsPage)}?Id={id}", true);
        }
    }
}
