using ComicShopBox.Database;
using ComicShopBox.Services;

namespace ComicShopBox
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}