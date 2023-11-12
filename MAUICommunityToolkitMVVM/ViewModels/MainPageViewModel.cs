using System.Windows.Input;

namespace MAUICommunityToolkitMVVM.ViewModels;
public class MainPageViewModel : BaseViewModel
{
    #region PROPERTIES
    string _firstName;
    public string FirstName
    {
        get { return _firstName; }
        set
        {
            SetProperty(ref _firstName, value);
            FullName = $"{FirstName} {LastName}";
            (GreetUserCommand as Command)?.ChangeCanExecute();
        }
    }

    string _lastName;
    public string LastName
    {
        get { return _lastName; }
        set
        {
            SetProperty(ref _lastName, value);
            FullName = $"{FirstName} {LastName}";
            (GreetUserCommand as Command)?.ChangeCanExecute();
        }
    }

    string _fullName;
    public string FullName
    {
        get { return _fullName; }
        set
        {
            SetProperty(ref _fullName, value);
        }
    }
    #endregion

    #region COMMANDS
    // 1. Command with explicit Execute
    private Command syncUICommand;
    public ICommand SyncUICommand => syncUICommand ??= new Command(ExecuteSyncUICommand);

    private void ExecuteSyncUICommand(object obj)
    {
        FirstName = "John";
        LastName = "Doe";
    }

    // 2. Command with explicit Execute and CanExecute methods
    private Command greetUserCommand;
    public ICommand GreetUserCommand => greetUserCommand ??= new Command(ExecuteGreetUserCommand, CanExecuteGreetUserCommand);

    private void ExecuteGreetUserCommand(object obj)
    {
        Shell.Current.DisplayAlert("Welcome!", $"Hello, {FullName}", "Ok");
    }

    private bool CanExecuteGreetUserCommand(object arg)
    {
        return FirstName?.Length > 0 & LastName?.Length > 0;
    }
    #endregion
}
