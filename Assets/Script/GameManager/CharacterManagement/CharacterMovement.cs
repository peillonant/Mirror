using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This script handles moving the player.
/// </summary>
public class CharacterMovement : MonoBehaviour
{
	[HideInInspector] public Vector3 v3_MoveDirection = Vector3.zero;				//The direction the player should move
	
	[SerializeField] private float f_CharactLookAtY;

	float f_Speed = 8f;                                                     		//The speed that the player moves (Above 10 on speed, the character can pass through walls)
    float f_TurnSmoothTime = 0.1f;													//Variable to smooth the movement of the rotation
	float f_TurnSmoothVelocity;
	float f_DownwardVelocity;

	public bool canMove = true;															//Can the player move?


	//Move with physics so the movement code goes in FixedUpdate()
	void FixedUpdate ()
	{
		//If the player cannot move, leave
		if (!canMove)
			return;

		// Condition to manage the Gravity to add later 
		if(!Character_LinkedGO.Instance.GetCharacterMovement().isGrounded)
		{
			f_DownwardVelocity += Physics.gravity.y * Time.deltaTime;
			v3_MoveDirection.y = f_DownwardVelocity;
			Character_LinkedGO.Instance.GetCharacterMovement().Move(v3_MoveDirection * Time.deltaTime);
		}
		
		UpdatePositionAndRotation();
    }

	// Function that manage the movement of the character position regarding the input from the player
	void UpdatePositionAndRotation()
	{
		// Check if an input for the movement has been performed or not
	    if (v3_MoveDirection.magnitude >= 0.1f) 
		{
			// Rotation computation
			float f_TargetAngle = Mathf.Atan2(v3_MoveDirection.x, v3_MoveDirection.z) * Mathf.Rad2Deg;
			float f_Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, f_TargetAngle + f_CharactLookAtY, ref f_TurnSmoothVelocity, f_TurnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, f_Angle, 0f);


			// Position computation
			Quaternion quat_Rotation = Quaternion.Euler(0, f_CharactLookAtY, 0);
			Vector3 v3_dir = quat_Rotation * v3_MoveDirection;
			Character_LinkedGO.Instance.GetCharacterMovement().Move(f_Speed * Time.deltaTime * v3_dir);
		}
	}

	/// <summary>
	/// Function to update the vector3 v3_CharactLookAt to have the rotation angle to apply on the Position and Rotation function
	/// </summary>
	public void CharactLookAt()
	{
		// If the current rotation of the charact is the same as the previous frame we do not update it
		if (transform.rotation.y != f_CharactLookAtY)
		{
			f_CharactLookAtY = transform.eulerAngles.y;
		}
		else
			return;
	}

	/// <summary>
	/// Function to update the capacity to move or not of the character
	/// </summary>
	public void UpdateCanMove()
	{
		canMove = !canMove;
	}

}