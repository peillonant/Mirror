using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterInventory : MonoBehaviour
{
    // INSTANCIATION
    public static CharacterInventory Instance;				//can access it from anywhere without needing to find a reference to it
    
   	void Awake()
	{
		//This is a common approach to handling a class with a reference to itself.
		//If instance variable doesn't exist, assign this object to it
		if (Instance == null)
			Instance = this;
		//Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
		//This is useful so that we cannot have more than one GameManager object in a scene at a time.
		else if (Instance != this)
			Destroy(this);
	}
	// END OF INSTANCIATION

    // DELEGATE & EVENT
    public delegate void ItemAddedInventory(GameObject go_ItemAdded);
    public delegate void ItemToBeAdded(bool b_ItemCanBeGrab, GameObject go_ItemToBeAdded);
    
    public event ItemAddedInventory itemAddedInventory_Key;
    public event ItemAddedInventory itemAddedInventory_Torch;
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
    public void AddInventoryObject(GameObject go_ObjAdded) => go_InventoryObjects.Add(go_ObjAdded);
    public void RemoveInventoryObject(GameObject go_ObjRemove) => go_InventoryObjects.Remove(go_ObjRemove);
    // End Encapsulation


    void Start()
    {
        //Subscribes to the keyHandler
        Character_SubscriptionEvent.Instance.SubscriptionKeyHandler();

        //Subscribes to the Inpute to Retrieve item
        GetComponent<CharacterInput_Interaction>().retrieveItem += RetrieveItem;
    }

    

    /// <summary>
    /// Function called by the subscription of the event that add the key on the variable ProbesClosed to be able to added to the inventory
    /// </summary>
    /// <param name="go_Probs"></param>
    public void RetrieveItemAvailable(GameObject go_Probs)
    {
        b_CanGrabItem = true;

        go_ProbesClosed = go_Probs;
        
        itemToBeAdded?.Invoke(b_CanGrabItem, go_ProbesClosed);
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
        
        itemToBeAdded?.Invoke(b_CanGrabItem, go_ProbesClosed);
    }

    /// <summary>
    /// 
    /// </summary>
    public void RetrieveItem()
    {
        if (go_ProbesClosed.tag.Equals("Opener") || go_ProbesClosed.tag.Equals("Switch"))
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
        itemToBeAdded?.Invoke(b_CanGrabItem, go_ProbesClosed);

        // Remove the key from the variable closer to the charact
        go_ProbesClosed = null;  

    }

    /// <summary>
    /// 
    /// </summary>
    void RetrieveKey()
    {
        // Trigger the Event regarding the Key added on the Inventory
        itemAddedInventory_Key?.Invoke(go_ProbesClosed);

        // Trigger the function to deactivate the key from the scene
        go_ProbesClosed.GetComponent<Props_Key>().PropsKeyUsed();    
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
        go_ProbesClosed.GetComponent<Props_Torch>().DeactivateTorch_Pobs(); 

        // Activate the GameObject Torch linked to the Character
        transform.GetChild(0).gameObject.SetActive(true);

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
