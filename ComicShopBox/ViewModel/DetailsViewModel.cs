using ComicShop.Core;
using ComicShopBox.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection.Metadata;

namespace ComicShopBox.ViewModel;


[QueryProperty(nameof(Comic), nameof(Comic))]   
public partial class DetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Comic comic; 

    public DetailsViewModel()
    {

    }

    [RelayCommand]
    Task Back() => Shell.Current.GoToAsync(nameof(MainPage));

    [RelayCommand]
    Task GoToStartUp() => Shell.Current.GoToAsync($"../{nameof(StartUpPage)}");

}
