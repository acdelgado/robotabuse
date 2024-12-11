using System.Collections.Generic;
using UnityEngine;

public class HighlightObject
{
	Renderer OutlinedObject;
	public Color highlightColor;
	Color oldColor;

	public HighlightObject(Color color)
    {
		highlightColor = color;
    }

	public void UpdateHighlights(GameObject hitObject)
    {
		//temp reference to the renderer of the hit object
		Renderer hitRenderer = hitObject.GetComponent<Renderer>();

		//if we aren't highlighting anything, save the color of this renderer's material
		if (OutlinedObject == null)
		{
			oldColor = hitRenderer.material.color;
		}

		//otherwise, if this is a different selectable object
		else
		{
			//restore the old color to the current outlined object
			Highlight(oldColor);

			//update the color we're storing
			oldColor = hitRenderer.material.color;
		}

		//keep reference for the object we're highlighting and highlight it
		OutlinedObject = hitRenderer;
		Highlight(highlightColor);
	}

	public void RemoveHighlights()
    {
		if (OutlinedObject != null)
		{
			Highlight(oldColor);
			OutlinedObject = null;
		}
	}

	void Highlight(Color color)
	{
		//Renderer[] renderers = OutlinedObject.GetComponentsInChildren<Renderer>();

		Material m = OutlinedObject.material;
		m.color = color;

		MeshRenderer[] renderers = OutlinedObject.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer r in renderers)
        {
			m = r.material;
			m.color = color;				
        }
	}

	public bool isDifferentObject(GameObject go)
    {
		return OutlinedObject == null || go != OutlinedObject.gameObject;
    }

}
