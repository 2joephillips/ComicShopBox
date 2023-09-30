using ComicShopBox.ViewModel;

namespace ComicShopBox.View;

public partial class DetailsPage : ContentPage
{
    private ComicDetailsViewModel _viewModel;
    public DetailsPage(ComicDetailsViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}