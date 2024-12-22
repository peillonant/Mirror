using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props_Key : MonoBehaviour
{
    // EVENT & DELEGATE
    public delegate void KeyHandler(GameObject go_Probes);
    public event KeyHandler KeyCanBeRetrieve;
    public event KeyHandler KeyCanNotBeRetrieve;
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
            KeyCanBeRetrieve?.Invoke(gameObject);
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
            KeyCanNotBeRetrieve?.Invoke(gameObject);
        }
        
        else
            return;
    }

    // Function to deactivate the Key when added on the Inventory
    public void DeactivateKey()
    {
        gameObject.SetActive(false);
    }
}
