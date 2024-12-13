using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probs_PressurePlate_Lvl2 : Props_PressurePlateBase
{
    // Start is called before the first frame update
    protected override void OnTriggerEnterEffect(Collider other)
    {
        // Avoid to check the collider when an enemy enter in the Sphere Collider
        if (other.gameObject.CompareTag("Character"))
        {
            go_Impacted[0].SetActive(true);
            
        }
    }
}
