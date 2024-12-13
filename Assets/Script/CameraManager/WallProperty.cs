using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for all wall, to have a check every frame if the wall is between the Charact and the Cam
/// If so, we change the Layer to not display it anymore
/// </summary>
public class WallProperty : MonoBehaviour
{
    [SerializeField] GameObject go_MainCamera;
    [SerializeField] GameObject go_Character;

    void Reset()
    {
        go_MainCamera = GameObject.Find("Main Camera");

        go_Character = GameObject.FindGameObjectWithTag("Character");
    }

    // Update is called once per frame
    void Update()
    {
        // Function to check if the wall is between the Cam and the Character
        CheckObstacleView();
    }

    /// <summary>
    /// Function to check every frame if the current wall is between the Camera and the Character
    /// If yes, then you update the Layer to "Wall_NotDisplayed" (if not already on this position)
    /// Else, back to the Layer "Wall"
    /// </summary>
    void CheckObstacleView()
    {
        Vector3 v3_direction = go_Character.transform.position - go_MainCamera.transform.position;

        // Create the raycast from the mirror in the direction of the character
        if (Physics.Raycast(go_MainCamera.transform.position, v3_direction, out RaycastHit hit))
        {
            if (hit.collider == gameObject.GetComponent<Collider>())
            {
                if (gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                if (!gameObject.GetComponent<MeshRenderer>().enabled)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
    }
}
