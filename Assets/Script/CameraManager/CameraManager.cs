using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject go_Character;
    Vector3 v3_offset = new Vector3 (0f, 8f, -25f);	                            //The offset of the camera from the player (how far back and above the player the camera should be)

    
    public void SetCharacterFollowing(GameObject go_NewCharacter) { go_Character = go_NewCharacter; }

    void FixedUpdate()
    {
        // If the Character has not been instantiate do nothing
        if (go_Character == null) return;

        //If there is a pause menu and the player presses the Cancel input axis, pause the game
		// if (pauseMenu != null && Input.GetButtonDown("Cancel"))
		// 	pauseMenu.Pause();


        FollowingCharact();
    }

    /// <summary>
    /// Function that change the position and the rotation of the Main camera to follow the Character
    /// </summary>
    public void FollowingCharact()
 {
     // compute position
    transform.position = go_Character.transform.TransformPoint(v3_offset);
    
     // compute rotation
     transform.LookAt(go_Character.transform);
 }
}