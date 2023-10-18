using ComicShopBox.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ComicShopBox.ViewModel
{
    public partial class StartUpViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PickedFolderName))]
        [NotifyPropertyChangedFor(nameof(FolderPicked))]
        [NotifyCanExecuteChangedFor(nameof(StartUpCommand))]
        private FolderPickerResult? pickedFolder;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(StartUpCommand))]
        string comicVinApi;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(StartUpCommand))]
        bool useComicVineApi;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(StartUpCommand))]
        bool comicVineKeyVerified;

        public bool OkayToStart => ComicVineVetted && FolderPicked;

        public bool ComicVineVetted => UseComicVineApi ? ComicVineKeyVerified : true;

        public bool FolderPicked => PickedFolder != null && PickedFolder.IsSuccessful;
        public string PickedFolderName => FolderPicked ? " Import Folder: " + PickedFolder.Folder.Name : " Import Folder: " + string.Empty;

        private readonly IFolderPicker _folderPicker;
        private readonly ComicVineApiService _comicVineApiService;


        public StartUpViewModel(IFolderPicker folderPicker, ComicVineApiService comicVineApi)
        {
            this.Title = "Start Up Page";
            _folderPicker = folderPicker;
            _comicVineApiService = comicVineApi;
            comicVinApi = "97108efe0d3ef7441f7a2954cf2e2e61532758b9";
        }
        public async void InitializeApplication()
        {
            await SecureStorage.SetAsync("hasInitialized", "initialized");
        }

        [RelayCommand]
        public async Task PickFolder(CancellationToken cancellationToken)
        {
            PickedFolder = await _folderPicker.PickAsync(cancellationToken);
            if (!PickedFolder.IsSuccessful)
            {
                return;
            }
            await Toast.Make($"Folder picked: Name - {PickedFolder.Folder.Name}, Path - {PickedFolder.Folder.Path}", ToastDuration.Long).Show(cancellationToken);
        }

        [RelayCommand(CanExecute = nameof(OkayToStart))]
        public async Task StartUp() => await Shell.Current.GoToAsync($"../{nameof(MainPage)}");

        [RelayCommand]
        public void ToggleUseComicVineApi() => UseComicVineApi = !UseComicVineApi;

        [RelayCommand]
        public async Task OpenUrl(string url)
        {
             await Launcher.OpenAsync(url);
        }

        [RelayCommand]
        public async Task CheckApiKey(string apiKey)
        {
            ComicVineKeyVerified = await _comicVineApiService.CheckApiKey(apiKey);
            var resultIs = ComicVineKeyVerified ? "Good" : "Bad";
            await Toast.Make($"Api Key is {resultIs}.").Show();
        }
    }
}