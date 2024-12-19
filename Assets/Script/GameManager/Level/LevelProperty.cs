using Unity.VisualScripting;
using UnityEngine;

// WARNING ON THE CODE, THIS IS NOT OPTIMISE BECAUSE IF WE CHANGE THE ORDER OF THE SCENE GAMEOBJECT THIS WILL NOT WORK ANYMORE
// WE ARE LOOKING FOR GAMEOBJECT DOORS IN THE ENVIRONMENT
// AND WE CONSIDERE THE FIRST GAMEOBJECT DOOR IN DOORS AS THE ENDDOOR OF THE LEVEL

public class LevelProperty : MonoBehaviour
{
    // VARIABLE CREATION
    [SerializeField] GameObject go_SpawnPosition;               //
    [SerializeField] GameObject go_EndDoor;                     //

    [SerializeField] int i_NumberOfLevel;                       // Integer to indicate the number of floor level. > 0 if you have at least 2 Floor levels
    [SerializeField] bool b_HasSeveralFloor;                    // Boolean to indicate if the level has several floor level
    
    // END VARIABLE CREATION

    // ENCAPSULATION
    public GameObject GetSpawnPosition() => go_SpawnPosition;
    public bool HasSeveralFloor() => b_HasSeveralFloor;
    public int GetNumberOfLevel() => i_NumberOfLevel;
    // END ENCAPSULATION

    /// <summary>
    /// Automatize the retrieve of the SpawnPosition for the level
    /// </summary>
    void Reset()
    {
        go_SpawnPosition = transform.GetChild(transform.childCount - 1).gameObject;
    }
    
    /// <summary>
    /// 
    /// </summary>
    void OnEnable()
    {
        // Initialize all the link between the Character and the new current Level
        LevelManager_Initiation.Instance.InitializeCharacter(gameObject);

        // Initialize the listen of the event End of Door to launch the LevelManger.ChangeNextLevel
        go_EndDoor.transform.GetChild(0).GetComponent<DoorActivation_Box>().PassingThroughEndDoorAble += TriggerEndDoorAction;      
    }

    /// <summary>
    /// Function that trigger the next level method when the character is passing the BoxCollider of the EndDoor
    /// </summary>
    void TriggerEndDoorAction()
    {
        LevelManager.Instance.NextLevel();
    }

    
}
