using System.Collections.Generic;
using UnityEngine;

public class MirrorProperty : MonoBehaviour
{
    // VARIABLE CREATION
    [SerializeField] bool b_isActivated;
    [SerializeField] bool b_isEnlightened;
    [SerializeField] private List <Material> m_materials;                               // List of Material changed when the Mirror is activated or not
    MirrorActivation_Capsule mirrorActivation_Capsule;                 // Variable to retrieve the component CapsuleCollider of the GameObject child of the Mirror
    // END VARIABLE CREATION

    // ENCAPSULATION
    public bool GetIsActive() => b_isActivated;
    public bool GetIsEnlightened() => b_isEnlightened;
    public void SetIsEnlightened(bool b_newIsEnlightened) => b_isEnlightened = b_newIsEnlightened; 
    // END ENCAPSULATION

    // Manage the subscription of Event at the start of the Scene
    void Start()
    {
        // Retrieve the Script MirrorActivation_Capsule from the child of the Mirror "CapsuleCollider"
        mirrorActivation_Capsule = transform.GetChild(0).GetComponent<MirrorActivation_Capsule>();

        // Subscribes to the IsActivated event
        mirrorActivation_Capsule.IsActivated += ActivationMirror;
        
    }

    // Update the bool isActivated of the Mirror.
    // This will also, add the Mirror into the grid for future usage by the user
    void ActivationMirror()
    {
        b_isActivated = true;

        GetComponent<MeshRenderer>().material = m_materials[1];
        Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().AddActivatedMirror(gameObject);

    }

    // When Mirror is deactivated
    void DeactivateMirror()
    {
        b_isActivated = false;
        GetComponent<MeshRenderer>().material = m_materials[0];
        Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().RemoveActivatedMirror(gameObject);
    }

    // Method to prevent memory leaks
    void OnDestroy()
    {
        mirrorActivation_Capsule.IsActivated -= ActivationMirror;
    }
}
