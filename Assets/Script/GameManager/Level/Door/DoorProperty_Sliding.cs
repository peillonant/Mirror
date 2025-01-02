using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorProperty_Sliding : DoorProperty
{
    [SerializeField] private Vector3 v3_PositionDoorOpen;
    [SerializeField] private Vector3 v3_PositionDoorClosed;

    private bool b_CoroutineIsLaunched; 

    public override void DoorsSubscription()
    {
        //Add the subscription to the CharacterInventory when a Key has been added
        go_KeyToOpen.GetComponent<Props_Key>().keyUsed += DoorOpen;
    }

    public override void DoorsUnsubscription()
    {
        go_KeyToOpen.GetComponent<Props_Key>().keyUsed -= DoorOpen;
    }

    /// <summary>
    /// Launch all methode linked to Open the door
    /// </summary>
    void DoorOpen()
    {
        MoveDoorToOpen();

        if (b_CoroutineIsLaunched)
        {
            StopCoroutine(CloseTheDoor());
            StartCoroutine(CloseTheDoor());
        }
        else
            StartCoroutine(CloseTheDoor());
    }

    /// <summary>
    /// Change the Local position of the door to the position open
    /// </summary>
    void MoveDoorToOpen() => transform.localPosition = v3_PositionDoorOpen;

    /// <summary>
    /// Change the Local position of the door to the position closed
    /// </summary>
    void MoveDoorToClose() => transform.localPosition = v3_PositionDoorClosed;

    /// <summary>
    /// Coroutine to close the door after 5 secondes 
    /// </summary>
    /// <returns></returns>
    IEnumerator CloseTheDoor()
    {
        b_CoroutineIsLaunched = true;

        yield return new WaitForSeconds(5);

        MoveDoorToClose();
        b_CoroutineIsLaunched = false;
    }
    
}
