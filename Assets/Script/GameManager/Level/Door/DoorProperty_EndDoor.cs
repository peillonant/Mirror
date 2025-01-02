using UnityEngine;

public class DoorProperty_EndDoor : DoorProperty
{
    void OnEnable()
    {
        b_IsEndDoor = true;
    }

    public override void DoorsSubscription()
    {
        //Add the subscription to the CharacterInventory when a Key has been added
        CharacterInventory.Instance.itemAddedInventory_Key += CheckToOpenDoor;
    }

    public override void DoorsUnsubscription()
    {
        CharacterInventory.Instance.itemAddedInventory_Key -= CheckToOpenDoor;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="go_KeyToCheck"></param>
    void CheckToOpenDoor(GameObject go_KeyToCheck)
    {
        if (go_KeyToOpen == go_KeyToCheck)
        {
            b_IsOpen = true;
            ActivateDoor();
        }
    }
}
