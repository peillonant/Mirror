using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   // INSTANCIATION
    public static LevelManager Instance;				//can access it from anywhere without needing to find a reference to it
    
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

   // VARIABLE
	int i_CurrentLevel = 0; 	// We start at 0 to linked it with the GameObject list of LevelDesign
	// END OF VARIABLE

   // ENCAPSULATION
   public int GetCurrentLevel() => i_CurrentLevel;
   // END ENCAPSULATION

   /// <summary>
   /// 
   /// </summary>
   public void NextLevel()
   {
      // Activation of the next level
      ActivationOrDeactivationLevel(i_CurrentLevel+1, true);

      // Function that manage the switch to the next level
      ChangeLevel();


      // Deactivation of the level finished
      ActivationOrDeactivationLevel(i_CurrentLevel, false);

      i_CurrentLevel++;
   }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="i_LevelToActivate"></param>
   /// <param name="b_ActionToPerform"></param>
	void ActivationOrDeactivationLevel(int i_LevelToActivate, bool b_ActionToPerform)
	{
      transform.GetChild(i_LevelToActivate).gameObject.SetActive(b_ActionToPerform);
	}

   /// <summary>
   /// 
   /// </summary>
   void ChangeLevel()
   {
      // Update the position of the Character to be on the nextLevel
      GetComponent<LevelManager_Character>().CharacterGoNextLevel();

      // Reinitialize the inventory of the Character
      GetComponent<LevelManager_Character>().CharacterReinitialization();
   }
}
