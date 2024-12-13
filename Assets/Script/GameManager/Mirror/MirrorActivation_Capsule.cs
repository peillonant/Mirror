using UnityEngine;

public class MirrorActivation_Capsule : MonoBehaviour
{
    public delegate void ActivationTriggered();
    public event ActivationTriggered IsActivated;

    [SerializeField] CapsuleCollider capsuleCollider;

    void Reset()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Check the collider of the Capsule to trigger the check of the raycast to see if the player is visible or not by the Mirror
    void OnTriggerStay(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Capsule Collider. We want to activate the Mirror just for Character
        if (other.gameObject.CompareTag("Character"))
        {
            // Now, we are checking if the Mirror is deactivate to avoid useless call && if the Mirror "see" the Character
            if (!this.transform.parent.GetComponent<MirrorProperty>().GetIsActive() && CheckVisibility(other))
            {
                // Trigger the event IsActivated that will trigger the bool on the MirrorProperty script.     
                IsActivated?.Invoke();
                // Then launch the function to deactivate the Collider component to stop having the OnTriggerStay active.
                DisableCollider();
            }
            else
                return;
        }
        
        else
            return;
    }

    // Methode to check if the character is seen by the Mirror or not
    bool CheckVisibility(Collider other)
    {
        // Raycast Direction from the Mirror to the Character
        Vector3 v3_direction = other.transform.position - transform.position;

        // Create the raycast from the mirror in the direction of the character
        if (Physics.Raycast(transform.position, v3_direction, out RaycastHit hit))
        {
            // Vérifier si l'objet touché est bien l'objet cible
            if (hit.collider.gameObject.CompareTag("Character"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
            return false;
    }

    // When the Mirror has been activated, we deactivate the component to stop checking every frame
    void DisableCollider()
    {
        capsuleCollider.enabled = false;
    }
}
