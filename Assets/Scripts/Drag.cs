using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DragAction
{
    //Update a GameObject's position to be an offset distance from the mouse's world space position
    public static void Drag(GameObject go, Vector3 offsetFromMouse)
    {
        go.transform.position = MouseWorldPos(go) + offsetFromMouse;
    }

    //get the world position of the mouse using the GameObject of interest as a depth reference
    public static Vector3 MouseWorldPos(GameObject go)
    {
        Vector3 mousePos = Input.mousePosition;
        float z = Camera.main.WorldToScreenPoint(go.transform.position).z;
        return Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, z));
    }
}
