using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
	Renderer OutlinedObject;
	public Color highlightColor;
	Color oldColor;

	void Update()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		bool hitSelectable = Physics.Raycast(ray, out var hit) && hit.transform.CompareTag("Selectable");
		
		//if we hit a selectable object that was not hit last update 
		if(hitSelectable && isDifferentObject(hit.transform.gameObject))
        {
			//temp reference to the renderer of the hit object
			Renderer hitRenderer = hit.transform.GetComponent<Renderer>();

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
		
		else if(!hitSelectable)
		{
			if(OutlinedObject != null)
            {
				Highlight(oldColor);
            }
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

	bool isDifferentObject(GameObject go)
    {
		return OutlinedObject == null || go != OutlinedObject.gameObject;
    }

}
