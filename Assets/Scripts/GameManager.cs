using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HighlightObject highlightObject;
    [SerializeField] Color highlightColor;

    GameObject currentObject;
    bool isObjectBeingHeld;
    Vector3 offset;
    static GameManager instance;

    public static GameManager Instance 
    {
        get { return instance; }
    }

    //setting up singleton instance and initial values
    private void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        highlightObject = new HighlightObject(highlightColor);
        isObjectBeingHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        //is mouse currently dragging an object?
        if(isObjectBeingHeld)
        {
            //if so, execute the drag function
            DragAction.Drag(currentObject, offset);
            return;
        }

        //if not, raycast to see if mouse is hovering over a selectable object
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hitSelectable = Physics.Raycast(ray, out var hit) && hit.transform.CompareTag("Selectable");

        //if the mouse is hovering over a selectable object that is not already being highlighted,
        //then highlight this new object
        if (hitSelectable && highlightObject.isDifferentObject(hit.transform.gameObject))
        {
            currentObject = hit.transform.gameObject;
            highlightObject.UpdateHighlights(hit.transform.gameObject);
        }

        //if the mouse isn't hovering over an object anymore, nullify highlights and references to the one previously being highlighted
        else if (!hitSelectable && currentObject != null)
        {
            highlightObject.RemoveHighlights();
            currentObject = null;
        }
    }

    public void SetObjectHeld(bool value) 
    {
        //if there's no object currently being hovered over, we don't need to worry about
        //whether or not one is being held
        if (currentObject == null)
            return;

        //set the value
        isObjectBeingHeld = value; 

        //if we have begun to hold an object, determine its offset from the mouse's world position to drag it
        //along with the mouse
        if(value)
        {
            offset = currentObject.transform.position - DragAction.MouseWorldPos(currentObject);
        }

        //otherwise, we are releasing the mouse and might want to check any attachment point changes
        else
        {
            Debug.Log("POOP ASS");
            currentObject.GetComponentInChildren<AttachmentPoint>()?.SnapPartToPoint();
        }
    }
}
