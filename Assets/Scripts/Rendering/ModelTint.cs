using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// No editor preview, might just be unperformant
/// </summary>
public class ModelTint : MonoBehaviour
{
    
    public Color tint = Color.white;
    
    [SerializeField] private List<Renderer> additionalRenderers = new();

    private Color _curTint = Color.clear;
    
    
    private void Update()
    {
        if (tint == _curTint)
            return;
        
        UpdateColor();
    }

    private void UpdateColor()
    {
        List<Renderer> renderers = new();
        GetComponents<Renderer>().ToList().ForEach(renderers.Add);
        foreach (var renderer in renderers)
            TintRenderer(renderer);
        foreach (var renderer in additionalRenderers)
            TintRenderer(renderer);
        _curTint = tint;
    }

    
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    private void TintRenderer(Renderer rend)
    {
        if (!rend) return;
        if (rend.materials == null) return;

        foreach (var mat in rend.materials)
        {
            if (!mat) break;
            mat.color = tint;

            if (mat.IsKeywordEnabled("_EMISSION"))
                mat.SetColor(EmissionColor, tint * 2);
        }
    }
}