using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_Initiation : MonoBehaviour
{
    // INSTANCIATION
    public static LevelManager_Initiation Instance;				//can access it from anywhere without needing to find a reference to it
    
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

    /// <summary>
    /// 
    /// </summary>
    public void InitializeCharacter(GameObject go_LevelToInitialize)
    {
        InitializeMirrorGrid(go_LevelToInitialize);

        InitializeInventory(go_LevelToInitialize);

        InitializeSubscriptionCharacter();

        InitializeUnsubscriptionCharacter();
    }

    /// <summary>
    /// 
    /// </summary>
    void InitializeMirrorGrid(GameObject go_LevelToInitialize)
    {
        // Call the CharacterInput function to update the linked to the Mirror_grid of this level
        Character_LinkedGO.Instance.SetGameObjectMirrorGrid(go_LevelToInitialize.transform.GetChild(3).gameObject);
    }

    /// <summary>
    /// TODO Initialize to avoid keeping thing between level (Item, key and Torch)
    /// </summary>
    void InitializeInventory(GameObject go_LevelToInitialize)
    {
        // Call the CharacterInventory function to update the linked to the Go_ProbesKey of this level
        Character_LinkedGO.Instance.SetGameObjectProbesKey(go_LevelToInitialize.transform.GetChild(1).GetChild(0).gameObject);

        InitializeInventoryItem(go_LevelToInitialize);

    }

    /// <summary>
    /// 
    /// </summary>
    void InitializeSubscriptionCharacter()
    {
        Character_SubscriptionEvent.Instance.SubscriptionMirrorGrid();
        Character_SubscriptionEvent.Instance.SubscriptionKeyHandler();
        Character_SubscriptionEvent.Instance.SubscriptionTorch();
    }

    /// <summary>
    /// 
    /// </summary>
    void InitializeUnsubscriptionCharacter()
    {
        Character_SubscriptionEvent.Instance.UnSubscriptionMirrorGrid();
        Character_SubscriptionEvent.Instance.UnSubscriptionKeyHandler();
        Character_SubscriptionEvent.Instance.UnSubscriptionTorch();
    }

    /// <summary>
    /// 
    /// </summary>
    void InitializeInventoryItem(GameObject go_LevelToInitialize)
    {
        if (go_LevelToInitialize.transform.GetChild(1).childCount > 1)
        {
            if (go_LevelToInitialize.transform.GetChild(1).GetChild(1).name == "Item" && go_LevelToInitialize.transform.GetChild(1).GetChild(1).childCount > 0)
            {
                for (int i = 0; i < go_LevelToInitialize.transform.GetChild(1).GetChild(1).childCount; i++)
                {
                    if (go_LevelToInitialize.transform.GetChild(1).GetChild(1).GetChild(i).tag.Equals("Torch"))
                        Character_LinkedGO.Instance.SetGameObjectProbesTorch(go_LevelToInitialize.transform.GetChild(1).GetChild(1).GetChild(i).gameObject);
                }
            }
        }
    }
}
