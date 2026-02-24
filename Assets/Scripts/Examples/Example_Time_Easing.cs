using System;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;
using EasingMode = Utils.EasingMode;

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


    public bool shouldLoop = true;
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
            if (shouldLoop)
                goBack = !goBack;
        }

        var inPos = In.localPosition;
        inPos.y = InValue * magnitude;
        In.localPosition = inPos;
        
        var outPos = Out.localPosition; 
        outPos.y = OutValue * magnitude;
        Out.localPosition = outPos;
        
        var inOutPos =  InOut.localPosition;
        inOutPos.y = InOutValue * magnitude;
        InOut.localPosition = inOutPos;
        
        InText.text = $"In\n{InValue:0.00} ";
        OutText.text = $"Out\n{OutValue:0.00} ";
        InOutText.text = $"In Out\n{InOutValue:0.00} ";

    }
}
