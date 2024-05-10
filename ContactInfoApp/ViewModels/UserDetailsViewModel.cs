using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactInfoApp.Models;
using ContactInfoApp.Services;
using ContactInfoApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ContactInfoApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class UserDetailsViewModel : AddEditViewModel, IQueryAttributable
    {
        //[ObservableProperty]
        //User user;

        [ObservableProperty]
        int id;

        public UserDetailsViewModel(IUserService userService) : base(userService)
        {

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            GetUserDetails(Id);
            Title = $"Welcome {Name}";
        }

        [RelayCommand]
        async Task SendMail()
        {
            await Shell.Current.DisplayAlert("b hjhvh", "hjvhjvjh", "OK");
        }

        [RelayCommand]
        async Task StartDialer()
        {
            await Shell.Current.DisplayAlert("b hjhvh", "hjvhjvjh", "OK");
        }

        [RelayCommand]
        async Task StartNavigation()
        {
            await Shell.Current.DisplayAlert("b hjhvh", "hjvhjvjh", "OK");
        }

        [RelayCommand]
        async Task UpdateUser()
        {
            await Shell.Current.GoToAsync($"{nameof(AddEditUserDetailsPage)}?Id={Id}", true);
        }

    }
}
