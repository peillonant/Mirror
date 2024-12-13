using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorActivation_Box : MonoBehaviour
{
    public delegate void ActivationPassingThrough(GameObject go_CurrentMirror, bool b_isActivated);
    public event ActivationPassingThrough PassingThroughAble;

    // Check when the character enter on the collider of the Box to trigger the check if the Character can use the functionnality of Passing through Mirror
    void OnTriggerEnter(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Capsule Collider. We want to activate the Mirror just for Character
        if (other.gameObject.CompareTag("Character"))
        {
            // Now, we are checking if the Grid has more than 1 Mirror activated
            if (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetGridMirrorsList().Count > 1)
            {
                // Trigger the event that inform the Observer that the functionnality can be activated
                PassingThroughAble?.Invoke(transform.parent.gameObject, true);
            }
        }
    }

    // Check when the character exit the collider of the Box to trigger the stop of using the functionnalityu of Passing through Mirror
    void OnTriggerExit(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Capsule Collider. We want to activate the Mirror just for Character
        if (other.gameObject.CompareTag("Character"))
        {
            // Now, we are checking if the Grid has more than 1 Mirror activated like that we are sure that the visualization has been activated
            if (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetGridMirrorsList().Count > 1)
            {
                // Trigger the event of to stop display the PassingThrough View
                PassingThroughAble?.Invoke(null, false);
            }
        }
    }
}
