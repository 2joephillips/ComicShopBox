using ComicShopBox.ViewModel;

namespace ComicShopBox
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
        }
    }
}