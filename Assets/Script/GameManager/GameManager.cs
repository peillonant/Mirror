using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// INSTANCIATION
    public static GameManager Instance;				//can access it from anywhere without needing to find a reference to it
    
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
	bool canMove = true;															//Can the player move?

	// END VARIABLE CREATION

	// ENCAPSULATION
	public void SetCanMove() => canMove = !canMove;
	public bool CanMove() => canMove;
	// END ENCAPSULATION


}
