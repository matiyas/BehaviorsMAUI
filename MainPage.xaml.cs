using System.Windows.Input;

namespace BehaviorsMAUI;

public partial class MainPage : ContentPage
{
	private ICommand changeTitle = null;

	public MainPage()
	{
		InitializeComponent();
	}

    private void CounterButton_Clicked(object sender, EventArgs e)
    {
		if (counterButtonBehavior.Counter >= 10) 
			counterButton.Behaviors.Remove(counterButtonBehavior);
    }

	public ICommand ChangeTitle => 
		changeTitle ??= new RelayCommand(this, (object parameter) => Title = parameter.ToString());
}

