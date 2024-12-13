using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that manage the subscription and unsubscription for all script on the Character GameObject
/// Script will be call when we update the link GameObject
/// </summary>

public class Character_SubscriptionEvent : MonoBehaviour
{
    // INSTANCIATION
    public static Character_SubscriptionEvent Instance;				//can access it from anywhere without needing to find a reference to it
    
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
    /// Function to handle the subscription of the Character to all the Key available on the level
    /// Call by: CharacterInventory
    /// </summary>
    public void SubscriptionKeyHandler()
    {
        for(int i = 0; i < Character_LinkedGO.Instance.GetProbesKey().transform.childCount; i++)
        {
            Character_LinkedGO.Instance.GetProbesKey().transform.GetChild(i).GetComponent<Props_Key>().KeyCanBeRetrieve += GetComponent<CharacterInventory>().RetrieveItemAvailable;
            Character_LinkedGO.Instance.GetProbesKey().transform.GetChild(i).GetComponent<Props_Key>().KeyCanNotBeRetrieve += GetComponent<CharacterInventory>().RetrieveItemNotAvailable;
        }
    }

    /// <summary>
    /// Function to handle the unsubscription of the Character to all the Key available on the level
    /// Call by: 
    /// </summary>
    public void UnSubscriptionKeyHandler()
    {
        if (Character_LinkedGO.Instance.GetProbesKey_previous() != null)
        {
            for(int i = 0; i < Character_LinkedGO.Instance.GetProbesKey_previous().transform.childCount; i++)
            {
                Character_LinkedGO.Instance.GetProbesKey_previous().transform.GetChild(i).GetComponent<Props_Key>().KeyCanBeRetrieve -= GetComponent<CharacterInventory>().RetrieveItemAvailable;
                Character_LinkedGO.Instance.GetProbesKey_previous().transform.GetChild(i).GetComponent<Props_Key>().KeyCanNotBeRetrieve -= GetComponent<CharacterInventory>().RetrieveItemNotAvailable;
            }
        }
    }

    /// <summary>
    /// Function to handle the subscription of the Character to Key Interaction on the level
    /// Call by: CharacterUI_Interact
    /// </summary>
    public void SubscriptionItemInteraction()
    {
        // Listen the event of the charact closed to a key
        GetComponent<CharacterInventory>().itemToBeAdded += GetComponent<CharacterUI_Interact>().UI_ItemInteraction;
    }

    /// <summary>
    /// Function to handle the subscription of the Character to MirrorGrid Interaction on the level
    /// Call by: CharacterUI_Interact
    /// </summary>
    public void SubscriptionMirrorGrid()
    {
        // Listen the event of activation of the grid when the charact is closed to a mirror and more than 1 is activated
        Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().gridActivation += GetComponent<CharacterUI_Interact>().UI_GridInteraction;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void UnSubscriptionMirrorGrid()
    {
        if (Character_LinkedGO.Instance.GetMirrorGridPrevious() != null)
        {
            // Listen the event of activation of the grid when the charact is closed to a mirror and more than 1 is activated
            Character_LinkedGO.Instance.GetMirrorGridPrevious().GetComponent<Mirror_Grid>().gridActivation -= GetComponent<CharacterUI_Interact>().UI_GridInteraction;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SubscriptionTorch()
    {
        if (Character_LinkedGO.Instance.GetProbesTorch() != null)
        {
            Character_LinkedGO.Instance.GetProbesTorch().GetComponent<Props_Torch>().TorchCanBeRetrieve += GetComponent<CharacterInventory>().RetrieveItemAvailable;
            Character_LinkedGO.Instance.GetProbesTorch().GetComponent<Props_Torch>().TorchCanNotBeRetrieve += GetComponent<CharacterInventory>().RetrieveItemNotAvailable;
        }    
    }

    /// <summary>
    /// 
    /// </summary>
    public void UnSubscriptionTorch()
    {
        if (Character_LinkedGO.Instance.GetProbesTorch_previous() != null)
        {
            Character_LinkedGO.Instance.GetProbesTorch_previous().GetComponent<Props_Torch>().TorchCanBeRetrieve -= GetComponent<CharacterInventory>().RetrieveItemAvailable;
            Character_LinkedGO.Instance.GetProbesTorch_previous().GetComponent<Props_Torch>().TorchCanNotBeRetrieve -= GetComponent<CharacterInventory>().RetrieveItemNotAvailable;
        }    
    }
    
}
