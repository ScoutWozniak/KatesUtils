using Utils;

public partial class Example_Time_Easing
{
    public enum EasingTypes
    {
        Linear,
        Quad,
        Cubic,
        Quart,
        Quint,
        Sine,
        Expo,
        Circ,
        Elastic,
        Back,
        Bounce
    }

    private float GetIn()
    {
        return _easingType switch
        {
            EasingTypes.Linear => Easing.Linear(_timeUntil.Percentage),
            EasingTypes.Quad => Easing.InQuad(_timeUntil.Percentage),
            EasingTypes.Cubic => Easing.InCubic(_timeUntil.Percentage),
            EasingTypes.Quart => Easing.InQuart(_timeUntil.Percentage),
            EasingTypes.Quint => Easing.InQuint(_timeUntil.Percentage),
            EasingTypes.Sine => Easing.InSine(_timeUntil.Percentage),
            EasingTypes.Expo => Easing.InExpo(_timeUntil.Percentage),
            EasingTypes.Circ => Easing.InCirc(_timeUntil.Percentage),
            EasingTypes.Elastic => Easing.InElastic(_timeUntil.Percentage),
            EasingTypes.Back => Easing.InBack(_timeUntil.Percentage),
            EasingTypes.Bounce => Easing.InBounce(_timeUntil.Percentage),
            _ => 0
        };
    }

    private float GetOut()
    {
        return _easingType switch
        {
            EasingTypes.Linear => Easing.Linear(_timeUntil.Percentage),
            EasingTypes.Quad => Easing.OutQuad(_timeUntil.Percentage),
            EasingTypes.Cubic => Easing.OutCubic(_timeUntil.Percentage),
            EasingTypes.Quart => Easing.OutQuart(_timeUntil.Percentage),
            EasingTypes.Quint => Easing.OutQuint(_timeUntil.Percentage),
            EasingTypes.Sine => Easing.OutSine(_timeUntil.Percentage),
            EasingTypes.Expo => Easing.OutExpo(_timeUntil.Percentage),
            EasingTypes.Circ => Easing.OutCirc(_timeUntil.Percentage),
            EasingTypes.Elastic => Easing.OutElastic(_timeUntil.Percentage),
            EasingTypes.Back => Easing.OutBack(_timeUntil.Percentage),
            EasingTypes.Bounce => Easing.OutBounce(_timeUntil.Percentage),
            _ => 0
        };
    }

    private float GetInOut()
    {
        return _easingType switch
        {
            EasingTypes.Linear => Easing.Linear(_timeUntil.Percentage),
            EasingTypes.Quad => Easing.InOutQuad(_timeUntil.Percentage),
            EasingTypes.Cubic => Easing.InOutCubic(_timeUntil.Percentage),
            EasingTypes.Quart => Easing.InOutQuart(_timeUntil.Percentage),
            EasingTypes.Quint => Easing.InOutQuint(_timeUntil.Percentage),
            EasingTypes.Sine => Easing.InOutSine(_timeUntil.Percentage),
            EasingTypes.Expo => Easing.InOutExpo(_timeUntil.Percentage),
            EasingTypes.Circ => Easing.InOutCirc(_timeUntil.Percentage),
            EasingTypes.Elastic => Easing.InOutElastic(_timeUntil.Percentage),
            EasingTypes.Back => Easing.InOutBack(_timeUntil.Percentage),
            EasingTypes.Bounce => Easing.InOutBounce(_timeUntil.Percentage),
            _ => 0
        };
    }
}