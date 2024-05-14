using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactInfoApp.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        bool isLoading;

        [ObservableProperty]
        string addEditButtonText;

        public bool IsNotLoading => !IsLoading;
    }
}
