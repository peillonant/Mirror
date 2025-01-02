using UnityEngine;

/// <summary>
/// NEED TO BE CHECK WHEN WE WILL HAVE SEVERAL DOOR AND KEY TO BE MANAGED
/// </summary>

public class DoorManager : MonoBehaviour
{
    
    // Call the methode to subscribe all Door Child to the correct event when the GameObject Level_X is active
    void OnEnable() => DoorsChildSubscription();

    void OnDisable() => DoorsChildUnsubscription();

    /// <summary>
    /// 
    /// </summary>
    void DoorsChildSubscription()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<DoorProperty>().DoorsSubscription();
        }
    }

    void DoorsChildUnsubscription()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<DoorProperty>().DoorsUnsubscription();
        }
    }
}
