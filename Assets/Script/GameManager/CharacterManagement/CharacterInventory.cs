using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    // DELEGATE & EVENT
    public delegate void ItemAddedInventory_Key(GameObject go_ItemAdded);
    public event ItemAddedInventory_Key itemAddedInventory_Key;

    public delegate void ItemAddedInventory_Torch(GameObject go_ItemAddedTorch);
    public event ItemAddedInventory_Torch itemAddedInventory_Torch;

    public delegate void ItemToBeAdded(bool b_ItemCanBeGrab);
    public event ItemToBeAdded itemToBeAdded;
    // END DELEGATE & EVENT

    // VARIABLE CREATION
    [SerializeField] bool b_CanGrabItem;
    [SerializeField] GameObject go_ProbesClosed;                                                // Variable to retrieve the probes closed to added on the Inventory
    [SerializeField] List<GameObject> go_InventoryObjects = new();                              // Variable that contain the list of All Item retrieved by the Character
    [SerializeField] bool b_HasTorch;
    // END VARIABLE CREATION

    // Encapsulation
    public bool CanGrabItem() => b_CanGrabItem;
    public bool HasTorch() => b_HasTorch;
    public List<GameObject> GetInventoryObjects() => go_InventoryObjects;
    // End Encapsulation


    void Start()
    {
        //Subscribes to the keyHandler
        Character_SubscriptionEvent.Instance.SubscriptionKeyHandler();
    }

    

    /// <summary>
    /// Function called by the subscription of the event that add the key on the variable ProbesClosed to be able to added to the inventory
    /// </summary>
    /// <param name="go_Probs"></param>
    public void RetrieveItemAvailable(GameObject go_Probs)
    {
        b_CanGrabItem = true;

        go_ProbesClosed = go_Probs;
        
        itemToBeAdded?.Invoke(b_CanGrabItem);
    }

    /// <summary>
    /// Function called by the subscription of the event that the key on the variable ProbesClosed can not be added to the inventory
    /// </summary>
    /// <param name="go_Probs"></param>
    public void RetrieveItemNotAvailable(GameObject go_Probs)
    {
        b_CanGrabItem = false;

        if (go_ProbesClosed == go_Probs)
            go_ProbesClosed = null;
        
        itemToBeAdded?.Invoke(b_CanGrabItem);
    }

    /// <summary>
    /// 
    /// </summary>
    public void RetrieveItem()
    {
        if (go_ProbesClosed.tag.Equals("Key"))
        {
            RetrieveKey();
        }
        else if (go_ProbesClosed.tag.Equals("Torch"))
        {
            RetrieveTorch();
        }
        else
            return;

        // Trigger the Event regarding the UI Display to retrive the key
        b_CanGrabItem = false;
        itemToBeAdded?.Invoke(b_CanGrabItem);

        // Remove the key from the variable closer to the charact
        go_ProbesClosed = null;  

    }

    /// <summary>
    /// 
    /// </summary>
    void RetrieveKey()
    {
        // Add the key to the Inventory
        go_InventoryObjects.Add(go_ProbesClosed);

        // Trigger the Event regarding the Key added on the Inventory
        itemAddedInventory_Key?.Invoke(go_ProbesClosed);

        // Trigger the function to deactivate the key from the scene
        go_ProbesClosed.GetComponent<Props_Key>().DeactivateKey();    
    }

    /// <summary>
    /// 
    /// </summary>
    void RetrieveTorch()
    {
        b_HasTorch = true;

        // Trigger the Event regarding the Torch added on the Inventory
        itemAddedInventory_Torch?.Invoke(go_ProbesClosed);

        // Trigger the function to deactivate the key from the scene
        go_ProbesClosed.GetComponent<Props_Torch>().DeactivateTorch(); 

    }


    /// <summary>
    /// Function to remove the Item from the list
    /// </summary>
    /// <param name="go_ItemToRemove">Item to Remove from the inventory</param>
    public void RemoveItem(GameObject go_ItemToRemove)
    {
        go_InventoryObjects.Remove(go_ItemToRemove);
    }

    /// <summary>
    /// 
    /// </summary>
    public void RemoveTorch()
    {
        b_HasTorch = false;
    }

}
