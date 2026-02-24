using Utils;

public partial class Example_Time_Easing
{
    
    private float Percentage => goBack ? 1 - _timeUntil.Percentage : _timeUntil.Percentage;

    private float InValue => Easing.GetValue(_easingType, EasingMode.In, Percentage);

    private float OutValue => Easing.GetValue(_easingType, EasingMode.Out, Percentage);
    
    private float InOutValue => Easing.GetValue(_easingType, EasingMode.InOut, Percentage);
    
    
}