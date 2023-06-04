namespace BehaviorsMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void CounterButton_Clicked(object sender, EventArgs e)
    {
		if (counterButtonBehavior.Counter >= 10) 
			counterButton.Behaviors.Remove(counterButtonBehavior);
    }
}

