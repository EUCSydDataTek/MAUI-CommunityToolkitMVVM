using CommunityToolkitMVVM.ViewModels;

namespace CommunityToolkitMVVM.Views;

public partial class ObservablePropertyPage : ContentPage
{
    public ObservablePropertyPage(ObservablePropertyVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}