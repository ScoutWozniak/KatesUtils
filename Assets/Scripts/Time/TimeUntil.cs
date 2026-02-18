using UnityEngine;

public struct TimeUntil
{
    private readonly float _startTime;
    private readonly float _length;

    public float TimeElapsed => Time.realtimeSinceStartup - _startTime;
    public float TimeLeft => _length - TimeElapsed;

    public readonly bool TimeUp => (_startTime + _length < Time.realtimeSinceStartup);
    
    public float Percentage => (TimeElapsed / _length);
    
    private TimeUntil(float length)
    {
        _startTime = Time.realtimeSinceStartup;
        _length = length;
    }

    public static implicit operator TimeUntil(float length)
    {
        return new TimeUntil(length);
    }
}