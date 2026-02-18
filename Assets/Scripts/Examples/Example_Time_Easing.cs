using System;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

public class Example_Time_Easing : MonoBehaviour
{
    TimeUntil _timeUntil;
    
    public EasingTypes  _easingType;

    public Transform In;
    public Transform Out;
    public Transform InOut;

    public TextMesh InText;
    public TextMesh OutText;
    public TextMesh InOutText;

    public TextMesh EasingText;

    public float magnitude = 4.0f;

    private bool goBack = false;

    private float length = 3.0f;
    
    
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
    
    private void Start()
    {
        _timeUntil = length;
        EasingText.text = _easingType.ToString();
    }
    
    private void Update()
    {
        if (_timeUntil.TimeUp)
        {
            _timeUntil = length;
            goBack = !goBack;
        }

        
        
        
        var inPos = In.localPosition;
        if (!goBack)
            inPos.y = GetIn() * magnitude;
        else
            inPos.y = (1 - GetIn()) * magnitude;
        In.localPosition = inPos;
        
        var outPos = Out.localPosition;
        if (!goBack)
            outPos.y = GetOut() * magnitude;
        else
            outPos.y = (1 - GetOut()) * magnitude;
        Out.localPosition = outPos;
        
        var inOutPos =  InOut.localPosition;
        if (!goBack)
            inOutPos.y = GetInOut() * magnitude;
        else
            inOutPos.y = (1 - GetInOut()) * magnitude;
        InOut.localPosition = inOutPos;
        
        InText.text = $"In\n{GetIn():0.00} ";
        OutText.text = $"Out\n{GetOut():0.00} ";
        InOutText.text = $"In Out\n{GetInOut():0.00} ";

        

    }
}
