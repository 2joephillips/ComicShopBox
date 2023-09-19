using ComicShopBox.ViewModel;

namespace ComicShopBox
{
    public partial class MainPage : ContentPage
    {
        private ComicsViewModel _viewModel;

        public MainPage(ComicsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetComicsCommand.ExecuteAsync(this);
        }
    }
}