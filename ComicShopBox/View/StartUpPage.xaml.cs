using ComicShopBox.ViewModel;

namespace ComicShopBox.View;

public partial class StartUpPage :ContentPage
{
    private StartUpViewModel _viewModel;
	public StartUpPage(StartUpViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }
}