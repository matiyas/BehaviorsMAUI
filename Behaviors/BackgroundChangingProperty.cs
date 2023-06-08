namespace BehaviorsMAUI.Behaviors;

internal static class BackgroundChangingProperty
{
    public static Color GetColor(BindableObject bindable)
    {
        return (Color)bindable.GetValue(ColorProperty);
    }

    public static void SetColor(BindableObject bindable, Color value)
    {
        bindable.SetValue(ColorProperty, value);
    }

    public static readonly BindableProperty ColorProperty =
        BindableProperty.CreateAttached(
            propertyName: "Color",
            returnType: typeof(Color),
            declaringType: typeof(BackgroundChangingProperty),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            validateValue: null,
            propertyChanged: ColorChanged);

    private static void ColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var color = (Color)newValue;
        var brush = new SolidColorBrush(color);
        if (bindable is VisualElement visualElement) visualElement.Background = brush;
    }
}
