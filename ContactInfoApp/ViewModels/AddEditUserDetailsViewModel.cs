using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactInfoApp.Models;
using ContactInfoApp.Resources;
using ContactInfoApp.Services;
using System.Web;

namespace ContactInfoApp.ViewModels
{
    [QueryProperty(Constants.ID, Constants.ID)]
    public partial class AddEditUserDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private int _userId;

        [ObservableProperty]
        User selectedUser = new() { ProfilePicture = Constants.DEFAULTPICTURE };

        [ObservableProperty]
        private string _saveEditText = Constants.ADDUSER;

        [ObservableProperty]
        private bool _isMale;

        protected IUserService userService;

        public AddEditUserDetailsViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

            _userId = Convert.ToInt32(HttpUtility.UrlDecode(query[Constants.ID].ToString()));
            if (_userId != 0)
            {
                GetUserDetails(_userId);
            }
        }

        [RelayCommand]
        protected void GetUserDetails(int id)
        {
            User user = userService.GetUser(id);
            if (user != null) 
            {
                SelectedUser.Name = user.Name;
                SelectedUser.Email = user.Email;
                SelectedUser.MobileNumber = user.MobileNumber;
                SelectedUser.Sex = user.Sex;
                SelectedUser.Address = user.Address;
                SelectedUser.ProfilePicture = user.ProfilePicture;
                SaveEditText = Constants.UPDATEUSER;
            }
        }

        [RelayCommand]
        protected async Task AddUser()
        {
            if (string.IsNullOrEmpty(SelectedUser.Name) || string.IsNullOrEmpty(SelectedUser.Email) || string.IsNullOrEmpty(SelectedUser.MobileNumber))
            {
                await Shell.Current.DisplayAlert(Constants.INVALIDDATA, Constants.INSERTVALIDDATA, Constants.OK);
                return;
            }

            var user = new User
            {
                Name = SelectedUser.Name,
                Email = SelectedUser.Email,
                MobileNumber = SelectedUser.MobileNumber,
                Sex = IsMale ? Constants.MALE : Constants.FEMALE,
                Address = SelectedUser.Address,
                ProfilePicture = SelectedUser.ProfilePicture,
            };

            if (string.Equals(SaveEditText, Constants.UPDATEUSER))
            {
                user.Id = _userId;
                userService.UpdateUser(user);
            }
            else
            {
                userService.AddUser(user);
                ClearForm();
            }
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private void ClearForm()
        {
            SelectedUser.Name = string.Empty;
            SelectedUser.MobileNumber = string.Empty;
            SelectedUser.Address = string.Empty;
            SelectedUser.Sex = string.Empty;
            SelectedUser.Email = string.Empty;
            SelectedUser.ProfilePicture = Constants.DEFAULTPICTURE;
        }

        [RelayCommand]
        async Task SelectMedia()
        {
            var selection = await Shell.Current.DisplayActionSheet(Constants.SELECTPICTURE, Constants.CANCEL, null, [Constants.GALLERY, Constants.CAMERA]);

            if (string.Equals(selection, Constants.CANCEL)) { return; }

            await SelectFromGallery(selection);
            await SelectCameraImage(selection);
        }

        private async Task SelectCameraImage(string selection)
        {
            if (string.Equals(selection, Constants.CAMERA) && MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);

                    SelectedUser.ProfilePicture = localFilePath;
                }
            }
        }

        private async Task SelectFromGallery(string selection)
        {
            if (string.Equals(selection, Constants.GALLERY))
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = Constants.SELECTPROFILEPICTURE,
                    FileTypes = FilePickerFileType.Images
                });
                if (result != null)
                {
                    SelectedUser.ProfilePicture = result.FullPath;
                }
            }
        }
    }

}
