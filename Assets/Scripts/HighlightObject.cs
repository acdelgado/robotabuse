using UnityEngine;
using System.Collections.Generic;

public class HighlightObject
{
    private Renderer OutlinedObject;
    public Color highlightColor;
    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    public HighlightObject(Color color)
    {
        highlightColor = color;
    }

    public void UpdateHighlights(GameObject hitObject)
    {
        // Temp reference to the renderer of the hit object
        Renderer hitRenderer = hitObject.GetComponent<Renderer>();
        if (hitRenderer == null) return;

        // If we're not highlighting anything, cache the original materials
        if (OutlinedObject == null)
        {
            CacheOriginalMaterials(hitObject);
        }
        else if (OutlinedObject != hitRenderer)
        {
            // Restore the original materials of the current outlined object
            RestoreOriginalMaterial();
            CacheOriginalMaterials(hitObject);
        }

        // Keep reference for the object we're highlighting and highlight it
        OutlinedObject = hitRenderer;
        ApplyHighlight();
    }

    public void RemoveHighlights()
    {
        RestoreOriginalMaterial();
        OutlinedObject = null;
        originalMaterials.Clear();
    }

    private void ApplyHighlight()
    {
        if (OutlinedObject == null)
            return;

        ////set the material colors of this mesh renderer and any child renderers to the highlight color
        ApplyHighlightToRenderer(OutlinedObject);
        foreach (Renderer childRenderer in OutlinedObject.GetComponentsInChildren<Renderer>())
        {
            ApplyHighlightToRenderer(childRenderer);
        }
    }

    private void ApplyHighlightToRenderer(Renderer renderer)
    {
        if (renderer == null) return;

        //clone the material so we don't affect the shared material
        //This is a safer way of instantiating materials, which I now know!
        Material highlightMaterial = new Material(renderer.sharedMaterial)
        {
            color = highlightColor
        };
        renderer.material = highlightMaterial;
    }

    //A function to cache the original materials in a dictionary.
    //This lets us use temp clone materials for the mesh renderers we're highlighting.
    private void CacheOriginalMaterials(GameObject gameObject)
    {
        originalMaterials.Clear();

        foreach (Renderer renderer in gameObject.GetComponentsInChildren<Renderer>())
        {
            if (renderer != null && !originalMaterials.ContainsKey(renderer))
            {
                originalMaterials[renderer] = renderer.sharedMaterial;
            }
        }
    }

    //A function to restore all the materials we cached when we're done highlighting
    private void RestoreOriginalMaterial()
    {
        foreach (KeyValuePair<Renderer, Material> entry in originalMaterials)
        {
            if (entry.Key != null)
            {
                entry.Key.material = entry.Value;
            }
        }
    }

    public bool isDifferentObject(GameObject go)
    {
        return OutlinedObject == null || go != OutlinedObject.gameObject;
    }
}
