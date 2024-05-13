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
        private User _user;

        [ObservableProperty]
        int id;

        public UserDetailsViewModel(IUserService userService) : base(userService)
        {

        }

        public new void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            GetUserDetails(Id);
            Title = $"Welcome {Name}";
        }

        [RelayCommand]
        async static Task SendMail()
        {
            var result = await Shell.Current.DisplayAlert("Send Mail", $"Do you want to send mail to user? ", "OK", "Cancel");
            if(result)
            {
                await SendEMail();

            }
        } 

        [RelayCommand]
        async static Task StartDialer()
        {
            var result = await Shell.Current.DisplayAlert("Call", "Do you want to send mail to user? ", "OK", "Cancel");
            if (result)
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open("809-555-5454");
            }
        }

        [RelayCommand]
        async Task StartNavigation()
        {
            var result = await Shell.Current.DisplayAlert("Start navigation", "Do you want to start navigation to user's address? ", "OK", "Cancel");
            if (result)
            {
                await NavigateToBuilding25();
            }
        }

        [RelayCommand]
        async Task UpdateUser()
        {
            await Shell.Current.GoToAsync($"{nameof(AddEditUserDetailsPage)}?Id={Id}", true);
        }

        private async Task NavigateToBuilding25()
        {
            var location = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            try
            {
                await Map.Default.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                // No map application available to open
            }
        }

        private static async Task SendEMail()
        {
            if (Microsoft.Maui.ApplicationModel.Communication.Email.Default.IsComposeSupported)
            {

                string subject = "Hello friends!";
                string body = "It was great to see you last weekend.";
                string[] recipients = new[] { "john@contoso.com", "jane@contoso.com" };

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(recipients)
                };

                await Microsoft.Maui.ApplicationModel.Communication.Email.Default.ComposeAsync(message);
            }
        }

    }
}
