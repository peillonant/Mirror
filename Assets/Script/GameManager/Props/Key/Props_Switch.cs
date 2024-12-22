using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props_Switch : MonoBehaviour
{
    // EVENT & DELEGATE
    public delegate void SwitchHandler(GameObject go_Probes);
    public event SwitchHandler SwitchCanBeTrigger;
    public event SwitchHandler SwitchCanNotBeTrigger;
    // END EVENT & DELEGATE

    [SerializeField] private GameObject go_DoorLinked;                  // Retrieve the GameObject of the door linked to this door

    // Encapsulation Function
    public GameObject GetDoorLinked() => go_DoorLinked;
    // End Encapsulation Function

    // Check the collider of the Sphere to trigger that the character is close enough to the Key
    void OnTriggerEnter(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Sphere Collider
        if (other.gameObject.CompareTag("Character"))
        {
            // Trigger the event IsActivated that will trigger the bool on the MirrorProperty script.     
            SwitchCanBeTrigger?.Invoke(gameObject);
        }
        
        else
            return;
    }

    // Check
    void OnTriggerExit(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Sphere Collider
        if (other.gameObject.CompareTag("Character"))
        {
            // Trigger the event IsActivated that will trigger the bool on the MirrorProperty script.     
            SwitchCanNotBeTrigger?.Invoke(gameObject);
        }
        
        else
            return;
    }
}
