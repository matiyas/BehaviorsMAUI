using System.ComponentModel;
using System.Windows.Input;

namespace BehaviorsMAUI;

internal class RelayCommand : ICommand
{
    private readonly INotifyPropertyChanged viewModel;
    private bool previousCanExecuteValue;

    readonly Action<object> execute;
    readonly Predicate<object> canExecute;

    public RelayCommand(
        INotifyPropertyChanged viewModel,
        Action<object> execute, 
        Predicate<object> canExecute = null)
    {
        this.viewModel = viewModel;
        this.viewModel.PropertyChanged += ViewModel_PropertyChanged;
        this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        this.canExecute = canExecute;

        previousCanExecuteValue = CanExecute(null);
    }

    public event EventHandler CanExecuteChanged;
    private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        bool canExecuteValue = CanExecute(null);
        if (CanExecuteChanged != null && previousCanExecuteValue != canExecuteValue)
            CanExecuteChanged(viewModel, EventArgs.Empty);
        previousCanExecuteValue = canExecuteValue;
    }

    public bool CanExecute(object parameter) => (canExecute == null) || canExecute(parameter);

    public void Execute(object parameter) => execute(parameter);
}
