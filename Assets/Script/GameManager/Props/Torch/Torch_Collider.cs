using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Collider : MonoBehaviour
{
    // EVENT & DELEGATE
    public delegate void MirrorLightUp(bool b_MirrorLightUp);
    public event MirrorLightUp mirrorLightUp;
    // END EVENT & DELEGATE

    /// <summary>
    /// Check the collider of the Torch
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        // We want to activate the event when the Torch is lightinning up a Mirror
        if (UniversalMethod.Instance.CheckColliderRayCast(gameObject, other, "Mirror"))
        {            
            // Trigger the event mirrorLightUp that will trigger the bool on the TorchManager script.     
            mirrorLightUp?.Invoke(true);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (UniversalMethod.Instance.CheckColliderRayCast(gameObject, other, "Mirror"))
        {
            // Trigger the event mirrorLightUp that will trigger the bool on the TorchManager script.     
            mirrorLightUp?.Invoke(false);
        }
    }   
}
