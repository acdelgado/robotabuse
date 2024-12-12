using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentPoint : MonoBehaviour
{
    //two types of attachment points:
    //an Anchor point for an object that other parts can be parented onto
    //a Hook point for an object to latch onto another anchor object
    public enum PointType
    {
        Anchor,
        Hook
    }

    //The type of this point
    [SerializeField] public PointType type;

    //The position that the hook will be set to 
    [SerializeField] private GameObject attachmentPart;

    //A reference to another attachment point that this point is bonded to
    [SerializeField] AttachmentPoint bond;

    //This script assumes a trigger component will be on this monobehaviour's gameobject
    private void OnTriggerEnter(Collider other)
    {
        //switch case based on what type of point we have
        //currently only needs a case for the hook type, can be expanded for anchor logic
        switch (type)
        {
            //for hooks, check if the collision is with an anchor and form a bond if unbonded
            case (PointType.Hook):
                AttachmentPoint anchor = other.GetComponent<AttachmentPoint>();
                if (anchor != null && anchor.type == PointType.Anchor && bond == null && anchor.bond == null)
                {
                    bond = anchor;
                    anchor.bond = this;
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //making another switch case in the case that the anchor requires different logic in the future
        switch(type)
        {
            //if hook is pulling away from a bonded point, break the bond and unparent from the bond part
            case (PointType.Hook):
                if (other.GetComponent<AttachmentPoint>() != null && other.GetComponent<AttachmentPoint>() == bond)
                {
                    bond = null;
                    attachmentPart.transform.parent = null;
                }
                break;
            //if anchor, break bond with hook that is pulling away
            case (PointType.Anchor):
                if (other.GetComponent<AttachmentPoint>() != null && other.GetComponent<AttachmentPoint>() == bond)
                {
                    bond = null;
                }
                break;
            default:
                break;
        }
    }

    //function to snap a hook's object onto an anchor's object
    public void SnapPartToPoint()
    {
        //if this point is a hook and it is detecting a bond to an anchor point
        if (bond != null && type == PointType.Hook)
        {
            //
            attachmentPart.transform.parent = bond.attachmentPart.transform;
            attachmentPart.transform.position = bond.transform.position;
        }
    }
}
