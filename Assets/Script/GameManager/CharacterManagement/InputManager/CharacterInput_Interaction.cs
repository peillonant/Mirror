using UnityEngine;
using static Mirror_Grid;

/// <summary>
/// Script managing everything regarding the input linked to an Interaction with a GameObject of the Scene
/// </summary>

public class CharacterInput_Interaction : MonoBehaviour
{
    // EVENT & DELEGATE DECLERATION
    public delegate void Interaction();

    public event Interaction activationGrid;
	public event Interaction retrieveItem;
	public event Interaction useTorch;
    // END EVENT & DELEGATE DECLERATION

    //[SerializeField] PauseMenu pauseMenu;					        //Reference to the pause menu

    void Update ()
	{
		//If there is a pause menu and the player presses the Cancel input axis, pause the game
		// if (pauseMenu != null && Input.GetButtonDown("Cancel"))
		// 	pauseMenu.Pause();

		//Handle inputs to Activate Mirror_grid
		HandleActivationGrid();

		//Handle inputs to Activate Retrieve Key
		HandleRetrieveItem();

		//Handle inputs to Use the Torch
		HandleUseTorch();
	}

	/// <summary>
	/// Function to check when the player click on the button to Interact with the Mirror 
	/// </summary>
	void HandleActivationGrid()
	{
		if (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().IsGridTriggarable() && Input.GetButtonDown("Interact"))
		{
			activationGrid?.Invoke();
        }	
	}

	/// <summary>
	/// Function to check when the player click on the button to Interact with a Key
	/// </summary>
	void HandleRetrieveItem()
	{
		if (GetComponent<CharacterInventory>().CanGrabItem() && Input.GetButtonDown("Interact"))
		{
			retrieveItem?.Invoke();
		}
	}

	/// <summary>
	/// Function to activate or not the Torch by pressing the button "X" of the Xbox controller
	/// </summary>
	void HandleUseTorch()
	{	
		if (GetComponent<CharacterInventory>().HasTorch() && Input.GetButtonDown("Torch_Button"))
		{
			useTorch?.Invoke();
		}
	}
}
