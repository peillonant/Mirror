using UnityEngine;

public abstract class DoorProperty : MonoBehaviour
{
    // VARIABLE CREATION
    [SerializeField] protected GameObject go_KeyToOpen;
    [SerializeField] protected bool b_IsEndDoor;
    [SerializeField] protected bool b_IsOpen;
    // END VARIABLE CREATION

    // ENCAPSULATION
    public GameObject GetKeyToOpen() => go_KeyToOpen;
    public bool GetIsEndDoor() => b_IsEndDoor;
    public bool GetIsOpen() => b_IsOpen;
    public void SetIsOpen(bool b_newIsOpen) => b_IsOpen = b_newIsOpen;
    // END ENCAPSULATION


    /// <summary>
    /// Function to activate the box Collider of the Door
    /// </summary>
    public void ActivateDoor() => transform.GetChild(0).gameObject.SetActive(true);

    public abstract void DoorsSubscription();
    public abstract void DoorsUnsubscription();
}
