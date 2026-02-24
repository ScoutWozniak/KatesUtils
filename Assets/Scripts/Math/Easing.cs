// SOURCED FROM https://gist.github.com/Kryzarel/bba64622057f21a1d6d44879f9cd7bd4

using System;
using System.Reflection;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Utils
{
	public enum EasingTypes
	{
		Quad,
		Cubic,
		Quart,
		Quint,
		Sine,
		Exponential,
		Circ,
		Elastic,
		Back,
		Bounce
	}
	
	public enum EasingMode
	{
		In,
		Out,
		InOut,
	}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class EasingMethodAttribute : Attribute
	{
		public EasingTypes eType;
		public EasingMode eMode;
		public EasingMethodAttribute(EasingTypes easingType, EasingMode mode)
		{
			eType = easingType;
			eMode = mode;
		}
	}
	
	
	/// <summary>
	/// Math functions for easing
	/// </summary>
    public class Easing
    {
		
	    public static float GetValue(EasingTypes easingType, EasingMode mode, float value)
	    {
		    var methods = typeof(Easing).GetRuntimeMethods();
		    foreach (var method in methods)
		    {
			    if (method.HasAttribute<EasingMethodAttribute>())
			    {
				    var attrib = method.GetAttribute<EasingMethodAttribute>();
				    if (attrib.eType == easingType && attrib.eMode == mode)
				    {
					    return (float)method.Invoke(null, new object[] { value });
				    }
			    }
		    }  
		    
		    return 0;
	    }
	    
	    [EasingMethod(EasingTypes.Quad, EasingMode.In)]
		public static float InQuad(float t) => t * t;
		
		[EasingMethod(EasingTypes.Quad, EasingMode.Out)]
		public static float OutQuad(float t) => 1 - InQuad(1 - t);
		
		[EasingMethod(EasingTypes.Quad, EasingMode.InOut)]
		public static float InOutQuad(float t)
		{
			if (t < 0.5) return InQuad(t * 2) / 2;
			return 1 - InQuad((1 - t) * 2) / 2;
		}
		
		[EasingMethod(EasingTypes.Cubic, EasingMode.In)]
		public static float InCubic(float t) => t * t * t;
		[EasingMethod(EasingTypes.Cubic, EasingMode.Out)]
		public static float OutCubic(float t) => 1 - InCubic(1 - t);
		[EasingMethod(EasingTypes.Cubic, EasingMode.InOut)]
		public static float InOutCubic(float t)
		{
			if (t < 0.5) return InCubic(t * 2) / 2;
			return 1 - InCubic((1 - t) * 2) / 2;
		}
		
		[EasingMethod(EasingTypes.Quart, EasingMode.In)]
		public static float InQuart(float t) => t * t * t * t;
		[EasingMethod(EasingTypes.Quart, EasingMode.Out)]
		public static float OutQuart(float t) => 1 - InQuart(1 - t);
		[EasingMethod(EasingTypes.Quart, EasingMode.InOut)]
		public static float InOutQuart(float t)
		{
			if (t < 0.5) return InQuart(t * 2) / 2;
			return 1 - InQuart((1 - t) * 2) / 2;
		}

		[EasingMethod(EasingTypes.Quint, EasingMode.In)]
		public static float InQuint(float t) => t * t * t * t * t;
		
		[EasingMethod(EasingTypes.Quint, EasingMode.Out)]
		public static float OutQuint(float t) => 1 - InQuint(1 - t);
		
		[EasingMethod(EasingTypes.Quint, EasingMode.InOut)]
		public static float InOutQuint(float t)
		{
			if (t < 0.5) return InQuint(t * 2) / 2;
			return 1 - InQuint((1 - t) * 2) / 2;
		}
		
		[EasingMethod(EasingTypes.Sine, EasingMode.In)]
		public static float InSine(float t) => 1 - (float)Math.Cos(t * Math.PI / 2);
		[EasingMethod(EasingTypes.Sine, EasingMode.Out)]
		public static float OutSine(float t) => (float)Math.Sin(t * Math.PI / 2);
		[EasingMethod(EasingTypes.Sine, EasingMode.InOut)]
		public static float InOutSine(float t) => (float)(Math.Cos(t * Math.PI) - 1) / -2;

		[EasingMethod(EasingTypes.Exponential, EasingMode.In)]
		public static float InExpo(float t) => (float)Math.Pow(2, 10 * (t - 1));
		
		[EasingMethod(EasingTypes.Exponential, EasingMode.Out)]
		public static float OutExpo(float t) => 1 - InExpo(1 - t);
		
		[EasingMethod(EasingTypes.Exponential, EasingMode.InOut)]
		public static float InOutExpo(float t)
		{
			if (t < 0.5) return InExpo(t * 2) / 2;
			return 1 - InExpo((1 - t) * 2) / 2;
		}

		[EasingMethod(EasingTypes.Circ, EasingMode.In)]
		public static float InCirc(float t) => -((float)Math.Sqrt(1 - t * t) - 1);
		[EasingMethod(EasingTypes.Circ, EasingMode.Out)]
		public static float OutCirc(float t) => 1 - InCirc(1 - t);
		[EasingMethod(EasingTypes.Circ, EasingMode.InOut)]
		public static float InOutCirc(float t)
		{
			if (t < 0.5) return InCirc(t * 2) / 2;
			return 1 - InCirc((1 - t) * 2) / 2;
		}

		[EasingMethod(EasingTypes.Elastic, EasingMode.In)]
		public static float InElastic(float t) => 1 - OutElastic(1 - t);
		[EasingMethod(EasingTypes.Elastic, EasingMode.Out)]
		public static float OutElastic(float t)
		{
			float p = 0.3f;
			return (float)Math.Pow(2, -10 * t) * (float)Math.Sin((t - p / 4) * (2 * Math.PI) / p) + 1;
		}
		[EasingMethod(EasingTypes.Elastic, EasingMode.InOut)]
		public static float InOutElastic(float t)
		{
			if (t < 0.5) return InElastic(t * 2) / 2;
			return 1 - InElastic((1 - t) * 2) / 2;
		}
		
		[EasingMethod(EasingTypes.Back, EasingMode.In)]
		public static float InBack(float t)
		{
			float s = 1.70158f;
			return t * t * ((s + 1) * t - s);
		}
		
		[EasingMethod(EasingTypes.Back, EasingMode.Out)]
		public static float OutBack(float t) => 1 - InBack(1 - t);
		
		[EasingMethod(EasingTypes.Back, EasingMode.InOut)]
		public static float InOutBack(float t)
		{
			if (t < 0.5) return InBack(t * 2) / 2;
			return 1 - InBack((1 - t) * 2) / 2;
		}

		
		[EasingMethod(EasingTypes.Bounce, EasingMode.In)]
		public static float InBounce(float t) => 1 - OutBounce(1 - t);
		[EasingMethod(EasingTypes.Bounce, EasingMode.Out)]
		public static float OutBounce(float t)
		{
			float div = 2.75f;
			float mult = 7.5625f;

			if (t < 1 / div)
			{
				return mult * t * t;
			}
			else if (t < 2 / div)
			{
				t -= 1.5f / div;
				return mult * t * t + 0.75f;
			}
			else if (t < 2.5 / div)
			{
				t -= 2.25f / div;
				return mult * t * t + 0.9375f;
			}
			else
			{
				t -= 2.625f / div;
				return mult * t * t + 0.984375f;
			}
		}
		
		[EasingMethod(EasingTypes.Bounce, EasingMode.InOut)]
		public static float InOutBounce(float t)
		{
			if (t < 0.5) return InBounce(t * 2) / 2;
			return 1 - InBounce((1 - t) * 2) / 2;
		}
    }
}