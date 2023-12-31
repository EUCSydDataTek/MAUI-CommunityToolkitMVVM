﻿using CommunityToolkit.Mvvm.ComponentModel;
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



    // COMMANDS
    [RelayCommand(CanExecute = nameof(CanGreetUser))]
    private void GreetUser()
    {
        Shell.Current.DisplayAlert("Welcome!", $"Hello, {FullName}", "Ok");
    }

    private bool CanGreetUser()
    {
        return firstName?.Length > 0 & lastName?.Length > 0;
    }

    // PROPERTY CHANGING EVENTS
    partial void OnFirstNameChanging(string value)
    {
        Debug.WriteLine($"The firstName is about to change to {value}");
    }

    partial void OnFirstNameChanged(string value)
    {
        Debug.WriteLine($"The lastName just changed to {value}");
    }
}
