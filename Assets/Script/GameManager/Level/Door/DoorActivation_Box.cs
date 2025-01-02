using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation_Box : MonoBehaviour
{
    public delegate void PassingThroughDoor();
    public event PassingThroughDoor PassingThroughDoorAble;
    public event PassingThroughDoor PassingThroughEndDoorAble;

    // Check when the character enter on the collider of the Box to trigger the check if the Character can use the functionnality of Passing through Mirror
    void OnTriggerEnter(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Capsule Collider. We want to activate the Mirror just for Character
        if (other.gameObject.CompareTag("Character"))
        {
            if (transform.GetComponentInParent<DoorProperty>().GetIsEndDoor())
            {
                PassingThroughEndDoorAble?.Invoke();
            }
            else
            {
                // Trigger the event that inform the Observer that the functionnality can be activated
                PassingThroughDoorAble?.Invoke();
            }            
        }
    }
}
