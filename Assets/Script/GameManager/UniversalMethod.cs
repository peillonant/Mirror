using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalMethod : MonoBehaviour
{
    // INSTANCIATION
    public static UniversalMethod Instance;				//can access it from anywhere without needing to find a reference to it

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

    // Methode to check if the GameObject hit by the rayCast of the Collider has the expected Tag
    public bool CheckColliderRayCast(GameObject go_Origin, Collider c_other, string s_TagName)
    {
        // Raycast Direction from the Mirror to the Character
        Vector3 v3_direction = c_other.transform.position - go_Origin.transform.position;

        // Create the raycast from the mirror in the direction of the character
        if (Physics.Raycast(go_Origin.transform.position, v3_direction, out RaycastHit hit))
        {
            // Vérifier si l'objet touché est bien l'objet cible
            if (hit.collider.gameObject.CompareTag(s_TagName))
                return true;         
            
            else
                return false;

        }
        else
            return false;
    }
}
