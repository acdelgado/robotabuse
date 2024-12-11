using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	HighlightObject highlightObject;
    [SerializeField] Color highlightColor;

    private void Start()
    {
        highlightObject = new HighlightObject(highlightColor);
    }

    // Update is called once per frame
    void Update()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		bool hitSelectable = Physics.Raycast(ray, out var hit) && hit.transform.CompareTag("Selectable");

		if(hitSelectable && highlightObject.isDifferentObject(hit.transform.gameObject))
        {
            highlightObject.UpdateHighlights(hit.transform.gameObject);
        }

        else if(!hitSelectable)
        {
            highlightObject.RemoveHighlights();
        }
	}
}
