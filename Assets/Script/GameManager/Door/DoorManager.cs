using UnityEngine;

/// <summary>
/// NEED TO BE CHECK WHEN WE WILL HAVE SEVERAL DOOR AND KEY TO BE MANAGED
/// </summary>

public class DoorManager : MonoBehaviour
{
    [SerializeField] private CharacterInventory go_CharacterInventory;

    void Reset()
    {
        // Retrieve the GameObject of the Character of the scene linked to the level
        go_CharacterInventory = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterInventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Add the subscription to the CharacterInventory when a Key has been added
        go_CharacterInventory.itemAddedInventory_Key += CheckToOpenDoor;
    }

    void CheckToOpenDoor(GameObject go_KeyToCheck)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (KeyLinkedToDoor(transform.GetChild(i).gameObject, go_KeyToCheck))
            {
                transform.GetChild(i).GetComponent<DoorProperty>().SetIsOpen(true);
                transform.GetChild(i).GetComponent<DoorProperty>().ActivateDoor();
                return;
            }
        }
    }


    bool KeyLinkedToDoor(GameObject go_DoorToCheck, GameObject go_KeyInInventory)
    {   
        if (go_DoorToCheck.GetComponent<DoorProperty>().GetKeyToOpen().Equals(go_KeyInInventory))
        {
            return true;
        }
        else
            return false;
    }
}
