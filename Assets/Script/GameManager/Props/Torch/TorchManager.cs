using UnityEngine;

public class TorchManager : MonoBehaviour
{
    // VARIABLE CREATION
    [HideInInspector] public Vector3 v3_RotationDirection = Vector3.zero;				//The direction the player should move	
    float f_TurnSmoothTime = 0.5f;													//Variable to smooth the movement of the rotation
    float f_TurnSmoothVelocity;
    bool b_TurnOn = true;
    public bool b_MirrorLighUp;                                                            // Variable triggered when the Torch is lightenning up a Mirror
    // END VARIABLE CREATION

    // ENCAPSULATION
    public bool IsTurnOn() => b_TurnOn;
    public bool IsMirrorLighUp() => b_MirrorLighUp;
    void MirrorIsLightUp(bool b_newMirrorLighUp) => b_MirrorLighUp = b_newMirrorLighUp;
    // END ENCAPSULATION

    void Start()
    {
        // Subscription to the event regarding the Mirror lighted up by the torch
        transform.GetChild(0).GetComponent<Torch_Collider>().mirrorLightUp += MirrorIsLightUp;

        // Subscription to the event from the CharacterInput when activate the torch
        transform.parent.GetComponent<CharacterInput_Interaction>().useTorch += UseTorch;
    }


	//Move with physics so the movement code goes in FixedUpdate()
	void FixedUpdate ()
	{
		//If the player cannot move, leave
		if (!GameManager.Instance.CanMove())
			return;
		
		UpdateRotationTorch();
    }

	// Function that manage the movement of the Torch rotation regarding the input from the player
	void UpdateRotationTorch()
	{
		// Check if an input for the movement has been performed or not
	    if (v3_RotationDirection.magnitude >= 0.1f) 
		{
            // Divide by 3 to have a Max and a Min regarding the angle of the rotation equal to 30° or -30°
			float f_TargetAngle = Mathf.Atan2(v3_RotationDirection.x, v3_RotationDirection.z) * Mathf.Rad2Deg / 3;

			float f_Angle = Mathf.SmoothDampAngle(transform.eulerAngles.x, f_TargetAngle, ref f_TurnSmoothVelocity, f_TurnSmoothTime);

            transform.localRotation = Quaternion.Euler(f_Angle, 0f, 0f);
		}
	}

    /// <summary>
    /// 
    /// </summary>
    public void UseTorch()
    {
        // Update the GameObject of the Torch
        gameObject.SetActive(!b_TurnOn);

        // Update the variable
        b_TurnOn = !b_TurnOn;
    }
}
