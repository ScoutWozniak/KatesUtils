using System;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

public partial class Example_Time_Easing : MonoBehaviour
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
