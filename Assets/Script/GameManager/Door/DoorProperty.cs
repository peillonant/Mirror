using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorProperty : MonoBehaviour
{
    // VARIABLE CREATION
    [SerializeField] GameObject go_KeyToOpen;
    [SerializeField] private bool b_IsEndDoor;
    [SerializeField]private bool b_IsOpen;
    // END VARIABLE CREATION

    // ENCAPSULATION
    public GameObject GetKeyToOpen() => go_KeyToOpen;
    public bool GetIsEndDoor() => b_IsOpen;
    public bool GetIsOpen() => b_IsOpen;
    public void SetIsOpen(bool b_newIsOpen) => b_IsOpen = b_newIsOpen;
    // END ENCAPSULATION


    /// <summary>
    /// Function to activate the box Collider of the Door
    /// </summary>
    public void ActivateDoor()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
