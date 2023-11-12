using MAUICommunityToolkitMVVM.ViewModels;

namespace MAUICommunityToolkitMVVM.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

