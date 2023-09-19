using ComicShopBox.Model;
using ComicShopBox.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ComicShopBox.ViewModel;

public partial class ComicsViewModel : BaseViewModel
{
    ComicService _service;
    public ObservableCollection<Comic> Comics { get; } = new();
    public ComicsViewModel(ComicService service)
    {
        Title = "Comics Mega List";
        this._service = service;
    }

    [RelayCommand]
    async Task GetComicsAsync()
    {
        if(IsBusy)return;

        try
        {
            IsBusy = true;
            var comics = await _service.GetComics();

            if(Comics.Count !=  0) { Comics.Clear(); }
            foreach(var comic in comics) { Comics.Add(comic); }
        }
        catch (Exception ex){
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unable to Get Comics: ", "OK");


        }
        finally { 
        IsBusy = false;
        }
    }
}