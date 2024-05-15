using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactInfoApp.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        private bool isLoading;

        [ObservableProperty]
        private string addEditButtonText;

        public bool IsNotLoading => !IsLoading;
    }
}
