using System;
using System.Collections;
using UnityEngine;


public static class Extensions
{
    /// <summary>
    /// Allows action to be called after a delay.
    /// Different to the base invoke as now an action can be called, meaning it is not limited to the name of a function
    /// </summary>
    /// <param name="mb">Component</param>
    /// <param name="f">Function</param>
    /// <param name="delay">Invoke After</param>
    public static void Invoke(this MonoBehaviour mb, Action f, float delay)
    {
        mb.StartCoroutine(InvokeRoutine(f, delay));
    }

    private static IEnumerator InvokeRoutine(Action f, float delay)
    {
        yield return new WaitForSeconds(delay);
        f();
    }
}