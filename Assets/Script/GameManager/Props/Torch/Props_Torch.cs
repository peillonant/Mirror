using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props_Torch : MonoBehaviour
{

     // EVENT & DELEGATE
    public delegate void RetrieveTorch(GameObject go_Probes);
    public event RetrieveTorch TorchCanBeRetrieve;
    public event RetrieveTorch TorchCanNotBeRetrieve;
    // END EVENT & DELEGATE

    // Check the collider of the Sphere to trigger that the character is close enough to the Key
    void OnTriggerEnter(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Sphere Collider
        if (other.gameObject.CompareTag("Character"))
        {
            TorchCanBeRetrieve?.Invoke(gameObject);
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
            TorchCanNotBeRetrieve?.Invoke(gameObject);
        }
        
        else
            return;
    }

    // Function to deactivate the Key when added on the Inventory
    public void DeactivateTorch_Pobs()
    {
        gameObject.SetActive(false);
    }
}
