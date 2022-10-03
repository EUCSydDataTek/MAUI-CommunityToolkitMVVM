using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace CommunityToolkitMVVM.ViewModels;
public partial class ObservablePropertyVM : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyCanExecuteChangedFor(nameof(GreetUserCommand))]
    private string firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyCanExecuteChangedFor(nameof(GreetUserCommand))]
    private string lastName;

    public string FullName => $"{FirstName} {LastName}";


    [RelayCommand(CanExecute = nameof(CanGreetUser))]
    private void GreetUser()
    {
        Shell.Current.DisplayAlert("Welcome!", $"Hello, {FullName}", "Ok");
    }

    private bool CanGreetUser()
    {
        return firstName?.Length > 0 & lastName?.Length > 0;
    }

    partial void OnFirstNameChanging(string value)
    {
        Debug.WriteLine($"The name is about to change to {value}");
    }

    partial void OnLastNameChanged(string value)
    {
        Debug.WriteLine($"The name just changed to {value}");
    }
}
