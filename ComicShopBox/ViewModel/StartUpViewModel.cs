using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ComicShopBox.ViewModel
{
    public partial class StartUpViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FolderPicked))]
        [NotifyPropertyChangedFor(nameof(PickedFolderName))]
        FolderPickerResult pickedFolder;


        public bool FolderPicked => pickedFolder != null;
        public string PickedFolderName => FolderPicked ? PickedFolder.Folder.Name: string.Empty;

        private readonly IFolderPicker _folderPicker;
        public StartUpViewModel(IFolderPicker folderPicker)
        {
            this.Title = "Start Up Page";
            _folderPicker = folderPicker;   

        }
        public async void InitializeApplication()
        {
            await SecureStorage.SetAsync("hasInitialized", "initialized");
        }

        [RelayCommand]
        async Task PickFolder(CancellationToken cancellationToken)
        {
            PickedFolder = await _folderPicker.PickAsync(cancellationToken);
            if (PickedFolder.IsSuccessful)
            {
                await Toast.Make($"Folder picked: Name - {PickedFolder.Folder.Name}, Path - {PickedFolder.Folder.Path}", ToastDuration.Long).Show(cancellationToken);
            }
            else
            {
                await Toast.Make($"Folder is not picked, {PickedFolder.Exception.Message}").Show(cancellationToken);
            }
        }
       
    }
}