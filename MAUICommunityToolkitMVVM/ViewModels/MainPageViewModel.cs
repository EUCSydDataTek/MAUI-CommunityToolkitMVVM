using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MAUICommunityToolkitMVVM.ViewModels;
public partial class MainPageViewModel : ObservableObject
{
    #region PROPERTIES
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyCanExecuteChangedFor(nameof(GreetUserCommand))]
    private string firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyCanExecuteChangedFor(nameof(GreetUserCommand))]
    private string lastName;

    public string FullName => $"{FirstName} {LastName}";
    #endregion

    #region COMMANDS
    [RelayCommand]
    private void SyncUI()
    {
        FirstName = "John";
        LastName = "Doe";
    }

    [RelayCommand(CanExecute = nameof(CanGreetUser))]
    private void GreetUser()
    {
        Shell.Current.DisplayAlert("Welcome!", $"Hello, {FullName}", "Ok");
    }

    private bool CanGreetUser()
    {
        return FirstName?.Length > 0 & LastName?.Length > 0;
    }
    #endregion

    #region PROPERTY CHANGING EVENTS
    partial void OnFirstNameChanging(string value)
    {
        Debug.WriteLine($"The firstName is about to change to {value}");
    }

    partial void OnFirstNameChanged(string value)
    {
        Debug.WriteLine($"The lastName just changed to {value}");
    }
    #endregion
}
