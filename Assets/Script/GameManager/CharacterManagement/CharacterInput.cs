using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
	//[SerializeField] PauseMenu pauseMenu;					        //Reference to the pause menu

	void Update ()
	{
		//If there is a pause menu and the player presses the Cancel input axis, pause the game
		// if (pauseMenu != null && Input.GetButtonDown("Cancel"))
		// 	pauseMenu.Pause();

		//Handle inputs for movement
		HandleMoveInput();

		//Handle inputs for Activate Mirror_grid
		HandleActivationGrid();

		//Handle inputs for Activate Retrieve Key
		HandleRetrieveItem();
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
	/// Function to check when the player click on the button to Interact with the Mirror 
	/// </summary>
	void HandleActivationGrid()
	{
		
		if (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().IsGridTriggarable() && Input.GetButtonDown("Interact"))
		{
			GetComponent<CharacterTeleport>().TeleportCharacterTo();
		}	
	}

	/// <summary>
	/// Function to check when the player click on the button to Interact with a Key
	/// </summary>
	void HandleRetrieveItem()
	{
		if (GetComponent<CharacterInventory>().CanGrabItem() && Input.GetButtonDown("Interact"))
		{
			GetComponent<CharacterInventory>().RetrieveItem();
		}
	}
}