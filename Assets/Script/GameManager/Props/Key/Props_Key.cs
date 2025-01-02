using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Props_Key : MonoBehaviour
{
    // EVENT & DELEGATE
    public delegate void KeyHandler(GameObject go_Probes);
    public delegate void KeyUsed();
    
    public event KeyHandler KeyCanBeRetrieve;
    public event KeyHandler KeyCanNotBeRetrieve;
    public event KeyUsed keyUsed;
    // END EVENT & DELEGATE

    [SerializeField] protected GameObject go_DoorLinked;                  // Retrieve the GameObject of the door linked to this door

    // Encapsulation Function
    public GameObject GetDoorLinked() => go_DoorLinked;
    // End Encapsulation Function

    // Check the collider of the Sphere to trigger that the character is close enough to the Key
    void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEffect(other);
    }

    // Check
    void OnTriggerExit(Collider other)
    {
        OnTriggerExitEffect(other);
    }

    protected abstract void OnTriggerEnterEffect(Collider other);

    protected abstract void OnTriggerExitEffect(Collider other);

    protected void InvokeKeyCanBeRetrieve(GameObject go_Obj) => KeyCanBeRetrieve?.Invoke(go_Obj);
    protected void InvokeKeyCanNotBeRetrieve(GameObject go_Obj) => KeyCanNotBeRetrieve?.Invoke(go_Obj);
    protected void InvokeKeyUsed() => keyUsed?.Invoke();

    public abstract void PropsKeyUsed();
}


