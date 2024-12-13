using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Props_PressurePlateBase : MonoBehaviour
{
    //VARIABLE CREATION
    [SerializeField] protected List <GameObject> go_Impacted; 
    //END VARIABLE CREATION

    // Check the collider of the Sphere to trigger that the character is close enough to the Key
    void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEffect(other);   
    }

    protected abstract void OnTriggerEnterEffect(Collider other);
}
