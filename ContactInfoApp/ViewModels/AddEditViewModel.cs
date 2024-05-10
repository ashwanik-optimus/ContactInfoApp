using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactInfoApp.Models;
using ContactInfoApp.Services;
using System.Web;

namespace ContactInfoApp.ViewModels
{
    [QueryProperty("Id", "Id")]
    public partial class AddEditViewModel : BaseViewModel, IQueryAttributable
    {
        private int _userId;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string mobileNumber;

        [ObservableProperty]
        string sex;

        [ObservableProperty]
        string address;

        [ObservableProperty]
        string profilePicture = "select3.png";

        [ObservableProperty]
        string saveEditText = "Add User";

        protected IUserService userService;

        public AddEditViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

            _userId = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            if (_userId != 0)
            {
                GetUserDetails(_userId);
            }
            //var _user = App.UserService.GetUser(id);
        }

        [RelayCommand]
        protected void GetUserDetails(int id)
        {
            User user = userService.GetUser(id);
            if (user != null) 
            {
                Name = user.Name;
                Email = user.Email;
                MobileNumber = user.MobileNumber;
                Sex = user.Sex;
                Address = user.Address;
                ProfilePicture = user.ProfilePicture;
                SaveEditText = "Update User";
            }
        }

        [RelayCommand]
        protected async Task AddUser()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(MobileNumber))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
                return;
            }

            var user = new User
            {
                Name = Name,
                Email = Email,
                MobileNumber = MobileNumber,
                Sex = Sex,
                Address = Address,
                ProfilePicture = ProfilePicture,
            };

            if (string.Equals(SaveEditText, "Update User"))
            {
                user.Id = _userId;
                userService.UpdateUser(user);
            }
            else
            {
                userService.AddUser(user);
                await ClearForm();
            }
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task ClearForm()
        {
            //AddEditButtonText = createButtonText;
            Name = string.Empty;
            MobileNumber = string.Empty;
            Address = string.Empty;
            Sex = string.Empty;
            Email = string.Empty;
            ProfilePicture = "select3.png";
        }

        [RelayCommand]
        async Task SelectMedia()
        {
            var selection = await Shell.Current.DisplayActionSheet("Select Picture", "Cancel", null, new string[] { "Gallery", "Camera" });

            if (string.Equals(selection, "Cancel")) { return; }

            await SelectFromGallery(selection);
            await SelectCameraImage(selection);
        }

        private async Task SelectCameraImage(string selection)
        {
            if (string.Equals(selection, "Camera") && MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    //string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);

                    ProfilePicture = localFilePath;
                }
            }
        }

        private async Task SelectFromGallery(string selection)
        {
            if (string.Equals(selection, "Gallery"))
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select profile picture",
                    FileTypes = FilePickerFileType.Images
                });
                if (result != null)
                {
                    ProfilePicture = result.FullPath;
                }
            }
        }
    }

}
