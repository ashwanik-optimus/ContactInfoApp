using CommunityToolkit.Mvvm.ComponentModel;
using ContactInfoApp.Models;
using ContactInfoApp.Services;
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
    public partial class UserDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        User user;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            User = App.UserService.GetUser(Id);
            Title = $"Welcome {User.Name}";
        }
    }
}
