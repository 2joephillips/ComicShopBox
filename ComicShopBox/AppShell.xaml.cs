using ComicShopBox.View;

namespace ComicShopBox
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
            Routing.RegisterRoute(nameof(StartUpPage), typeof(StartUpPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));  
        }
    }
}