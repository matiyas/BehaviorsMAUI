namespace BehaviorsMAUI.Behaviors;

internal class ButtonWithCounter : Behavior<Button>
{
    public int Counter { get; set; } = 0;

    protected override void OnAttachedTo(Button button)
    {
        base.OnAttachedTo(button);

        if (button == null) return;

        button.Clicked += Button_Clicked;
        button.Text = Counter.ToString();
    }

    protected override void OnDetachingFrom(Button button)
    {
        base.OnDetachingFrom(button);

        if (button == null) return;

        button.Clicked -= Button_Clicked;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Counter++;
        var button = (Button)sender;
        button.Text = Counter.ToString();
    }
}
