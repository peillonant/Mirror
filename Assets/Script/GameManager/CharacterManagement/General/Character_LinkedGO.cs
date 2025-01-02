using UnityEngine;

/// <summary>
/// Script that contain all the linked to all GameObject in the GameObject Level_X
/// </summary>

public class Character_LinkedGO : MonoBehaviour
{
    // INSTANCIATION
    public static Character_LinkedGO Instance;				//can access it from anywhere without needing to find a reference to it
    
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

	// VARIABLE CREATION
    [SerializeField] CharacterController characterMovement;			// Reference to the character's movement script
    GameObject go_MirrorGrid;										// Variable that allow to check when the Character is closed to a Mirror and the Mirror_Grid is activated
	GameObject go_MirrorGrid_previous;             					// Variable that allow to keep the Grid from the previous level to be sure to unsubscribs everything when passing on the next level
    GameObject go_Probes_Key;                      					// Variable to retrieve the component Props_Key of the GameObject child of Props/Key
	GameObject go_Probes_Key_previous;								// Variable that allow to keep the Key GameObject from the previous level to be sure to unsubscribs everything when passing on the next level
	GameObject go_Probes_Torch;					// Variable that retrieve the component Props_Torch of the GameObject child of Props/Torch
	GameObject go_Probes_Torch_previous;			// Variable that allow to keep the Torch GameObject from the previous level to be sure to unsubscribs everything when passing on the next level
	// END VARIABLE CREATION

    //ENCAPSULATION
    public CharacterController GetCharacterMovement() => characterMovement;
    public GameObject GetMirrorGrid() => go_MirrorGrid;
    public GameObject GetProbesKey() => go_Probes_Key;
	public GameObject GetProbesTorch() => go_Probes_Torch;
	public GameObject GetMirrorGridPrevious() => go_MirrorGrid_previous;
	public GameObject GetProbesKey_previous() => go_Probes_Key_previous;
	public GameObject GetProbesTorch_previous() => go_Probes_Torch_previous;
	//END ENCAPSULATION

	/// <summary>
	/// Method to add the GameObject that contain all Mirror to help other script to catch easily the mirror from the current level
	/// </summary>
	/// <param name="go_newMirrorGrid"></param>
	public void SetGameObjectMirrorGrid (GameObject go_newMirrorGrid)
	{
		go_MirrorGrid_previous = go_MirrorGrid;
		go_MirrorGrid = go_newMirrorGrid;
	}

	/// <summary>
	/// Method to add the GameObject that contain all keys to help other script to catch easily the mirror from the current level
	/// </summary>
	/// <param name="go_newProbesKey"></param>
    public void SetGameObjectProbesKey(GameObject go_newProbesKey)
	{
		go_Probes_Key_previous = go_Probes_Key;
		go_Probes_Key = go_newProbesKey;
	}

	/// <summary>
	/// Method to add the GameObject that contain the Torch to help other script to catch easily the mirror from the current level
	/// [WARNING] To modify due to the fact that after the level 2 we are not loosing the torch anymore [WARNING]
	/// </summary>
	/// <param name="go_newProbesTorch"></param>
	public void SetGameObjectProbesTorch(GameObject go_newProbesTorch)
	{
		go_Probes_Torch_previous = go_Probes_Torch;
		go_Probes_Torch = go_newProbesTorch;
	}
}
