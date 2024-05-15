using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace ContactInfoApp.Models
{
    [Table("users")]
    public partial class User : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        string name;

        [ObservableProperty]
        private string sex;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string mobileNumber;

        [ObservableProperty]
        private string profilePicture;
    }
}
