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
    public GameObject GetKeyToOpen() { return go_KeyToOpen; }
    public bool GetIsEndDoor() { return b_IsOpen; }
    public bool GetIsOpen() { return b_IsOpen; }
    public void SetIsOpen(bool b_newIsOpen) { b_IsOpen = b_newIsOpen;}
    // END ENCAPSULATION

    /// <summary>
    /// Function to retrieve automatically the setting of the door regarding the setting of the level
    /// </summary>
    void Reset()
    {
        RetrieveKeyToOpen();

        CheckIsEndDoor();
    }

    void Start()
    {
        if(b_IsOpen)
            transform.GetChild(0).gameObject.SetActive(true);
    }

    /// <summary>
    /// Function to retrieve automatically when you import the door on the scene the key linked to this door
    /// </summary>
    void RetrieveKeyToOpen()
    {
        if (transform.parent.parent.parent.GetChild(1).GetChild(0).childCount > 0)
            go_KeyToOpen = transform.parent.parent.parent.GetChild(1).GetChild(0).GetChild(gameObject.transform.GetSiblingIndex()).gameObject;
    }

    /// <summary>
    /// Function to update automatically the setting of IsEndDoor when you import the door on the scene
    /// </summary>
    void CheckIsEndDoor()
    {
        if (gameObject.transform.GetSiblingIndex() == 0)
            b_IsEndDoor = true;
    }

    /// <summary>
    /// Function to activate the box Collider of the Door
    /// </summary>
    public void ActivateDoor()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
