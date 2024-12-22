using System.Collections.Generic;
using UnityEngine;

public class RoomProperty : MonoBehaviour
{
    // VARIABLE CREATION
    [SerializeField] int i_FloorOfTheRoom;
    [SerializeField] List<GameObject> go_LinkedToTheRooms = new();
    [SerializeField] GameObject go_Light;
    // END VARIABLE CREATION 

    // ENCAPSULATION
    public int GetFloor() => i_FloorOfTheRoom;
    public List<GameObject> GetLinkedObject() => go_LinkedToTheRooms;
    public GameObject GetLights() => go_Light;
    // END ENCAPSULATION


    /// <summary>
    /// Methode to update all linked GameObject to the Room
    /// </summary>
    /// <param name="go_ToCheck">GameObject of the Room to check</param>
    /// <param name="i_Layer">Integer of the current floor where the character is</param>
    public void UpdateOnDisplay_LinkedObject(int i_Layer)
    {
        foreach (GameObject go_child in go_LinkedToTheRooms)
        {
            UniversalMethod.Instance.UpdateLayer(go_child, i_Layer);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="b_ToHide"></param>
    public void UpdateOnDisplay_Lights(bool b_ToHide)
    {
        foreach (Transform go_child in go_Light.transform)
        {
            go_child.GetComponent<Light>().enabled = !b_ToHide;
        }
    }
}
