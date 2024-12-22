using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RoomManager : MonoBehaviour
{
    int i_CurrentFloor;                 // Variable that save the currentFloor of the Character


    /// <summary>
    /// Methode that check all room from the Level to see if each room are need to be modified or not
    /// </summary>
    /// <param name="i_CurrentFloor"></param>
    public void CheckRoomDisplayed(int i_newCurrentFloor)
    {
        i_CurrentFloor = i_newCurrentFloor;

        for (int i = 0; i < transform.childCount; i++) 
        {
            UpdateOnDisplay(transform.GetChild(i).gameObject, CheckToBeDisplayed(transform.GetChild(i).gameObject));
        }
    }

    /// <summary>
    /// Methode to Display or Not on the Camera the GameObject linked to the Room
    /// First, we modify the GameObject Room and child
    /// Second, we update all GameObject Linked to the Room
    /// Third, we modify the Lights
    /// </summary>
    void UpdateOnDisplay(GameObject go_LinkedToTheRoom, bool b_ToHide)
    {
        if (!b_ToHide)
        {
            UniversalMethod.Instance.UpdateLayer(go_LinkedToTheRoom, 0);
            go_LinkedToTheRoom.GetComponent<RoomProperty>().UpdateOnDisplay_LinkedObject(0);
        }
        else
        {
            UniversalMethod.Instance.UpdateLayer(go_LinkedToTheRoom, 10);
            go_LinkedToTheRoom.GetComponent<RoomProperty>().UpdateOnDisplay_LinkedObject(10);
        }

        go_LinkedToTheRoom.GetComponent<RoomProperty>().UpdateOnDisplay_Lights(b_ToHide);
    }

    /// <summary>
    /// Methode to perform the check on the condition to see if the Room is on a floor above or not of the Character
    /// </summary>
    /// <param name="go_ToCheck">GameObject of the Room to check</param>
    /// <param name="i_CurrentFloor">Integer of the current floor where the character is</param>
    /// <returns></returns>
    bool CheckToBeDisplayed(GameObject go_ToCheck)
    {
        return go_ToCheck.GetComponent<RoomProperty>().GetFloor() > i_CurrentFloor;
    }
}
