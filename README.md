# master

## Fra gammeldags MVVM til CommunityToolkitMVVM

1. Installer NuGet-pakken `CommunityToolkit.Mvvm`
&nbsp;

2. Fjern `BaseViewModel` og nedarv fra `ObservableObject`. Gør ViewModel klassen `partial`

3. Omskriv properties til private fields og sæt attributten `[ObservableProperty]` på properties.
`FullName` ændres til `public string FullName => $"{FirstName} {LastName}";`:

    ```csharp
    [ObservableProperty]
    private string firstName;

    [ObservableProperty]
    private string lastName;

    public string FullName => $"{FirstName} {LastName}";
    ```
    
>Test at funktionen "Sync UI with backend" virker.

&nbsp;

4. Opdatér FullName

    FullName property kan synkroniseres ved at tilføje attributten [NotifyPropertyChangedFor(nameof(FullName))] over hver property:

    ```csharp
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        private string firstName;
    ```

&nbsp;

5. Omskrivning af SyncUICommand med `[RelayCommand]`
Først ændres metoden `GreetUserCommand`. Husk at den nu blot skal hedde `GreetUser`:

    ```csharp
        [RelayCommand]
        private void SyncUser()
        {
            FirstName = "John";
            LastName = "Doe";
        }
    ```

&nbsp;

6. Omskrivning af GreetUserCommand med `[RelayCommand]`
Her tilføjes en parameter `CanExecute`, som returenerer en bool:
    ```csharp
    [RelayCommand(CanExecute = nameof(CanGreetUser))]
    private void GreetUser()
    {
        Shell.Current.DisplayAlert("Welcome!", $"Hello, {FullName}", "Ok");
    }

    private bool CanGreetUser()
    {
        return FirstName?.Length > 0 & LastName?.Length > 0;
    }
    ```

&nbsp;

7. Synkronisering af CanExecute
Selv om der er indtastet korrekte værdier, bliver CanExecute ikke opdateret. 
Det kan løses ved at tilføje attributten `[NotifyCanExecuteChangedFor(nameof(GreetUserCommand))]` ved
hver af de properties, der indgår:

    ```csharp
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyCanExecuteChangedFor(nameof(GreetUserCommand))]
    private string firstName;
    ```

&nbsp;

8. Property Changing Events   
Har man brug for at lave validering inden en property tilskrives eller udføre en handling efter, findes der events:

    ```charp
    partial void OnFirstNameChanging(string value)
    {
        Debug.WriteLine($"The firstName is about to change to {value}");
    }

    partial void OnFirstNameChanged(string value)
    {
        Debug.WriteLine($"The lastName just changed to {value}");
    }
    ```


    
