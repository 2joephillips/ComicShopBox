
using ComicShop.Core;
using ComicShopBox.Services;
using ComicShopBox.View;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ComicShopBox.ViewModel;

public partial class MainPageViewModel : BaseViewModel
{
    ComicService _service;
    public ObservableCollection<Comic> Comics { get; } = new();
    public MainPageViewModel(ComicService service)
    {
        Title = "Comics Mega List";
        this._service = service;
     
    }

    [RelayCommand]
    async Task GetComicsAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var comics = await _service.GetComics();

            if (Comics.Count != 0) { Comics.Clear(); }
            foreach (var comic in comics.Take(20))
            {
                Comics.Add(comic);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unable to Get Comics: ", "OK");


        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    Task Navigate() => Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object> { ["Comic"] = Comics[0] });
}