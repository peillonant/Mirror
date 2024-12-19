using UnityEngine;

public class MirrorActivation_Capsule : MonoBehaviour
{
    // EVENT & DELEGATE
    public delegate void ActivationTriggered();
    public event ActivationTriggered IsActivated;
    // END EVENT & DELEGATE

    CapsuleCollider capsuleCollider;

    void Start()
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
            if (!transform.parent.GetComponent<MirrorProperty>().GetIsActive() && CheckEnlightened(other) && UniversalMethod.Instance.CheckColliderRayCast(gameObject, other, "Character"))
            {
                // Trigger the event IsActivated that will trigger the bool on the MirrorProperty script.     
                IsActivated?.Invoke();
                // Then launch the function to deactivate the Collider component to stop having the OnTriggerStay active.
                DisableCollider();
            }
            else
                return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    bool CheckEnlightened(Collider other)
    {
        if (transform.parent.GetComponent<MirrorProperty>().GetIsEnlightened())
            return true;
        else
        {
            if (!other.gameObject.transform.GetChild(0).gameObject.activeSelf)
                return false;
            else
                return other.gameObject.transform.GetChild(0).GetComponent<TorchManager>().IsMirrorLighUp();
        }
    }


    // When the Mirror has been activated, we deactivate the component to stop checking every frame
    void DisableCollider()
    {
        capsuleCollider.enabled = false;
    }
}
