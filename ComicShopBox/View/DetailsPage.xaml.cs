using ComicShopBox.ViewModel;

namespace ComicShopBox.View;

public partial class DetailsPage : ContentPage
{
    private DetailsViewModel _viewModel;
    public DetailsPage(DetailsViewModel viewModel)
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