using UnityEngine;

/// <summary>
/// Script managing everything regarding the input linked to a movement of the character
/// </summary>

public class CharacterInput_Movement : MonoBehaviour
{
	//[SerializeField] PauseMenu pauseMenu;					        //Reference to the pause menu

	void Update ()
	{
		//If there is a pause menu and the player presses the Cancel input axis, pause the game
		// if (pauseMenu != null && Input.GetButtonDown("Cancel"))
		// 	pauseMenu.Pause();

		//Handle inputs for movement
		HandleMoveInput();

		//Handle inputs for Torch rotation
		HandleTorchMoveInput();

	}

	/// <summary>
	/// Function to handle the mouvement of the character regarding the mouvement of the Left Joystick
	/// </summary>
	void HandleMoveInput()
	{
		//Get the raw Horizontal and Vertical inputs (raw inputs have no smoothing applied)
		float f_Horizontal = Input.GetAxisRaw("Horizontal");
		float f_Vertical = Input.GetAxisRaw("Vertical");

		//Tell the movement script to move on the X and Z axes with no Y axis movement
		GetComponent<CharacterMovement>().v3_MoveDirection = new Vector3(f_Horizontal, 0f, f_Vertical);

		//When the joystick is not touch, we reset the value of the Vector3 CharactLookAt
		if (f_Horizontal == 0 && f_Vertical == 0)
			GetComponent<CharacterMovement>().CharactLookAt();
	}

	/// <summary>
	/// 
	/// </summary>
	void HandleTorchMoveInput()
	{
		if(!GetComponent<CharacterInventory>().HasTorch() || !transform.GetChild(0).GetComponent<TorchManager>().IsTurnOn())
			return;
	    
		// Get the raw Horizontal Inputs (Joystick right on the controller)
		float f_Vertical = Input.GetAxisRaw("Vertical_Rotation");

		transform.GetChild(0).GetComponent<TorchManager>().v3_RotationDirection = new Vector3(f_Vertical, 0f, 0f);
	}
}