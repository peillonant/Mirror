using UnityEngine;

/// <summary>
/// Script that manage the teleportation of the Character when the user select the Mirror
/// </summary>

public class CharacterTeleport : MonoBehaviour
{
    // VARIABLE CREATION
    float f_SizeCharacter = 1.75f;          // Need to put this as constant to reposition the character after a teleportation
    // END VARIABLE CREATION

    public void TeleportCharacterTo()
    {

        if (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetOtherMirror().transform.eulerAngles.y == 0)
        {
            UpdatePositionCharacter(0, 0, -1);
        }
        else if (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetOtherMirror().transform.eulerAngles.y == 90)
        {
            UpdatePositionCharacter(-1, 0, 0);
        }
        else if (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetOtherMirror().transform.eulerAngles.y == 180)
        {
            UpdatePositionCharacter(0, 0, 1);
        }
        else if (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetOtherMirror().transform.eulerAngles.y == 270)
        {
            UpdatePositionCharacter(1, 0, 0);
        }
        else
        {
            UpdatePositionCharacter(0, 0, 0);
        }
        
    }

    /// <summary>
    /// Function to Retrieve the position Y of the Mirror and apply a modification to have a character not floating when teleported.
    /// We added 1.75f for the sizeY of the character.
    /// </summary>
    /// <returns></returns>
    float RetrievePositionYMirror()
    {
        return Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetOtherMirror().transform.position.y - (Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetOtherMirror().transform.lossyScale.y/2) + f_SizeCharacter;
    }

    /// <summary>
    /// Function to generate the new position for the character after the teleportation regarding the Mirror targetted
    /// </summary>
    /// <param name="go_MirrorTargeting">GameObject of the targetted object</param>
    /// <param name="i_ModifierX">Modifier on X regarding the angle of the Targetted object</param>
    /// <param name="i_ModifierY">Modifier on Y regarding the angle of the Targetted object</param>
    /// <param name="i_ModifierZ">Modifier on Z regarding the angle of the Targetted object</param>
    void UpdatePositionCharacter(int i_ModifierX, int i_ModifierY, int i_ModifierZ)
    {
        float f_newPositionX = Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetOtherMirror().transform.position.x+i_ModifierX;
        float f_newPositionY = RetrievePositionYMirror()+i_ModifierY;
        float f_newPositionZ = Character_LinkedGO.Instance.GetMirrorGrid().GetComponent<Mirror_Grid>().GetOtherMirror().transform.position.z+i_ModifierZ;
        
        gameObject.transform.position = new(f_newPositionX, f_newPositionY, f_newPositionZ);
    }

}
