# master

## Fra gammeldags MVVM til CommunityToolkitMVVM

1. Installer NuGet-pakken `CommunityToolkit.Mvvm`
&nbsp;

2. Fjern `BaseViewModel` og nedarv fra `ObservableObject`. G�r ViewModel klassen `partial`

3. Omskriv properties til private fields og s�t attributten `[ObservableProperty]` p� properties.
`FullName` �ndres til `public string FullName => $"{FirstName} {LastName}";`:

    ```csharp
    [ObservableProperty]
    private string firstName;

    [ObservableProperty]
    private string lastName;

    public string FullName => $"{FirstName} {LastName}";
    ```
    
>Test at funktionen "Sync UI with backend" virker.

&nbsp;

4. Opdat�r FullName

    FullName property kan synkroniseres ved at tilf�je attributten [NotifyPropertyChangedFor(nameof(FullName))] over hver property:

    ```csharp
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        private string firstName;
    ```

&nbsp;

5. Omskrivning af SyncUICommand med `[RelayCommand]`
F�rst �ndres metoden `GreetUserCommand`. Husk at den nu blot skal hedde `GreetUser`:

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
Her tilf�jes en parameter `CanExecute`, som returenerer en bool:
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
Selv om der er indtastet korrekte v�rdier, bliver CanExecute ikke opdateret. 
Det kan l�ses ved at tilf�je attributten `[NotifyCanExecuteChangedFor(nameof(GreetUserCommand))]` ved
hver af de properties, der indg�r:

    ```csharp
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyCanExecuteChangedFor(nameof(GreetUserCommand))]
    private string firstName;
    ```

&nbsp;

8. Property Changing Events   
Har man brug for at lave validering inden en property tilskrives eller udf�re en handling efter, findes der events:

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


    
