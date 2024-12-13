using Unity.VisualScripting;
using UnityEngine;

// WARNING ON THE CODE, THIS IS NOT OPTIMISE BECAUSE IF WE CHANGE THE ORDER OF THE SCENE GAMEOBJECT THIS WILL NOT WORK ANYMORE
// WE ARE LOOKING FOR GAMEOBJECT DOORS IN THE ENVIRONMENT
// AND WE CONSIDERE THE FIRST GAMEOBJECT DOOR IN DOORS AS THE ENDDOOR OF THE LEVEL

public class LevelProperty : MonoBehaviour
{
    // VARIABLE CREATION
    [SerializeField] GameObject go_SpawnPosition;
    // END VARIABLE CREATION

    // ENCAPSULATION
    public GameObject GetSpawnPosition() { return go_SpawnPosition; }
    // END ENCAPSULATION

    void Reset()
    {
        go_SpawnPosition = transform.GetChild(transform.childCount - 1).gameObject;
    }
    
    void OnEnable()
    {
        // Initialize the listen of the event End of Door to launch the LevelManger.ChangeNextLevel
        transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<DoorActivation_Box>().PassingThroughEndDoorAble += TriggerEndDoorAction;

        InitializeCharacter();
    }

    /// <summary>
    /// 
    /// </summary>
    void TriggerEndDoorAction()
    {
        LevelManager.Instance.NextLevel();
    }

    /// <summary>
    /// 
    /// </summary>
    void InitializeCharacter()
    {
        InitializeMirrorGrid();

        InitializeInventory();

        InitializeSubscriptionCharacter();

        InitializeUnsubscriptionCharacter();
    }

    /// <summary>
    /// 
    /// </summary>
    void InitializeMirrorGrid()
    {
        // Call the CharacterInput function to update the linked to the Mirror_grid of this level
        Character_LinkedGO.Instance.SetGameObjectMirrorGrid(transform.GetChild(3).gameObject);
    }

    /// <summary>
    /// TODO Initialize to avoid keeping thing between level (Item, key and Torch)
    /// </summary>
    void InitializeInventory()
    {
        // Call the CharacterInventory function to update the linked to the Go_ProbesKey of this level
        Character_LinkedGO.Instance.SetGameObjectProbesKey(transform.GetChild(1).GetChild(0).gameObject);

        InitializeInventoryItem();

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
    void InitializeInventoryItem()
    {
        if (transform.GetChild(1).childCount > 1)
        {
            if (transform.GetChild(1).GetChild(1).name == "Item" && transform.GetChild(1).GetChild(1).childCount > 0)
            {
                for (int i = 0; i < transform.GetChild(1).GetChild(1).childCount; i++)
                {
                    if (transform.GetChild(1).GetChild(1).GetChild(i).tag.Equals("Torch"))
                        Character_LinkedGO.Instance.SetGameObjectProbesTorch(transform.GetChild(1).GetChild(1).GetChild(i).gameObject);
                }
            }
        }
    }
}
