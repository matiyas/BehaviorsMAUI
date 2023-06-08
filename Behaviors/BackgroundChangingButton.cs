using System.Windows.Input;

namespace BehaviorsMAUI.Behaviors;

class BackgroundChangingButton : Behavior<VisualElement> // : BindableObject
{
    // controls (ex. button), containers (ex. Grid), etc.
    // visual object to which the behavior was attached
    public VisualElement VisualElement { get; private set; } = null;

    protected override void OnAttachedTo(VisualElement bindable)
    {
        base.OnAttachedTo(bindable);
        this.VisualElement = bindable;
    }


    // Register Button property as BindableProperty to be able to assign a control to it
    public static readonly BindableProperty ButtonProperty =
        BindableProperty.Create(
            propertyName: nameof(Button),
            returnType: typeof(Button),
            declaringType: typeof(BackgroundChangingButton),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            validateValue: null,
            propertyChanged: ButtonChanged
        );

    // GetValue and SetValue methods are coming from the BindableObject class
    // that is the base class of Behavior
    public Button Button
    {
        get => (Button)GetValue(ButtonProperty);
        set => SetValue(ButtonProperty, value);
    }

    public Color Color { get; set; } = Colors.Gray;

    private static void ButtonChanged (BindableObject b, object oldValue, object newValue)
    {
        void Button_Click(object sender, EventArgs e)
        {
            var _b = b as BackgroundChangingButton;
            if (_b != null) _b.VisualElement.Background = _b.Color;

            ICommand command = _b.Command;
            object commandParameter = _b.CommandParameter;

            if (command != null && command.CanExecute(commandParameter))
                command.Execute(commandParameter);
        }

        if (oldValue != null) ((Button)oldValue).Clicked += Button_Click;
        if (newValue != null) ((Button)newValue).Clicked += Button_Click;
    }

    #region Command
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(BackgroundChangingButton),
            null);

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(BackgroundChangingButton),
            null);

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
    #endregion
}
