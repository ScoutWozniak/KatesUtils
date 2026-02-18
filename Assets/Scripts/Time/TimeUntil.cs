using UnityEngine;

/// <summary>
/// Provides a simple solution to counting down time.
/// Use TimeUp to determine if the timer is complete and do logic after
/// </summary>
public struct TimeUntil
{
    private readonly float _startTime;
    private readonly float _length;

    public float TimeElapsed => Time.realtimeSinceStartup - _startTime;
    public float TimeLeft => _length - TimeElapsed;

    /// <summary>
    /// Determines if the timer is complete
    /// </summary>
    public readonly bool TimeUp => (_startTime + _length < Time.realtimeSinceStartup);
    
    /// <summary>
    /// Useful for easing calculations
    /// Returns from a scale of 0 -1
    /// </summary>
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