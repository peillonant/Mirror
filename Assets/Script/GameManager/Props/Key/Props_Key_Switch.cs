using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props_Key_Switch : Props_Key
{
    // Start is called before the first frame update
    protected override void OnTriggerEnterEffect(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Sphere Collider
        if (other.gameObject.CompareTag("Character"))
        {
            // Trigger the event IsActivated that will trigger the bool on the MirrorProperty script.     
            InvokeKeyCanBeRetrieve(gameObject);
        }
        
        else
            return;
    }

    protected override void OnTriggerExitEffect(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            // Trigger the event IsActivated that will trigger the bool on the MirrorProperty script.     
            InvokeKeyCanNotBeRetrieve(gameObject);
        }
        
        else
            return;
    }

    /// <summary>
    /// 
    /// </summary>
    public override void PropsKeyUsed()
    {
        // Trigger the event that unlock the door and launch the timer before closing it.
        Debug.Log("Switch ON");

        InvokeKeyUsed();                  // Retrieve the GameObject of the door linked to this door        
    }
}
