using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Grid : MonoBehaviour
{
    // EVENT & DELEGATE DECLERATION
    public delegate void GridActivation(bool b_isActivated);
    public event GridActivation gridActivation;
    // END EVENT & DELEGATE DECLERATION


    // VARIABLE CREATION
    [SerializeField] List <GameObject> go_GridMirrors = new();              // GameObject List to retrieve all activated Mirror
    [SerializeField] List <MirrorActivation_Box>  mirrorActivation_box;     // GameObject List to retrieve all mirrorActivation_Box linked to Activated Mirror
    [SerializeField] GameObject go_MirrorFacingCharacter;                   // GameObject that retrieve the GameObject of the Mirror facing the Character
    [SerializeField] bool b_GridAvailable;                                  // Bool that give the information of Grid Available or not and update by event from MirrorActivation_Capsule.
    [SerializeField] bool b_GridTriggarable;                                // Bool that give the information of Grid is Triggarable by the user

    // END VARIABLE CREATION

    // ENCAPSULATION METHODE
    public List<GameObject> GetGridMirrorsList() => go_GridMirrors; 
    public GameObject GetGridMirrorsIndex (int index) => go_GridMirrors[index];
    public bool IsGridAvailable() => b_GridAvailable;
    public bool IsGridTriggarable() => b_GridTriggarable;
    // END ENCAPSULATION METHODE
    

    void Update()
    {
        CheckGridAvailable();
    }

    // To optimize here, I'm sure we can have an event listener instead of having an update 
    /// <summary>
    ///     Function to check every frame if the grid that contain all active mirors has more than 1 Mirrors activated.<br/>
    ///     If more than 1 mirror then the Grid is available to be used by the player
    /// </summary>
    void CheckGridAvailable()
    {
        if (go_GridMirrors.Count > 1)
            b_GridAvailable = true;
        else
            b_GridAvailable = false;
    }

    /// <summary>
    ///     Function called by the MirrorProperty [ActivationMirror()] when the player is passing in front of the Activation Box.<br/>
    ///     1°/ Add the Mirror on the object go_GridMirrors, that list all activated Mirror.<br/>
    ///     2°/ Add the BoxCollider linked to the Mirror to be able to position the player on the correct Mirror when used the grid.<br/>
    ///     3°/ Add to the event PassingThroughAble the subscription of the function UpdateGridTriggarable.<br/>
    /// </summary>
    /// <param name="go_NewMirror">GameObject of the Mirror that has been activated by the player</param>
    public void AddActivatedMirror(GameObject go_NewMirror) 
    { 
        go_GridMirrors.Add(go_NewMirror);
        mirrorActivation_box.Add(go_NewMirror.GetComponentInChildren<MirrorActivation_Box>());

        mirrorActivation_box[^1].PassingThroughAble += UpdateGridTriggarable;
    }

    /// <summary>
    ///     Functiton called by the MirrorProperty [DeactivateMirror()] to remove the mirror from the list of ActivatedMirror.<br/>
    ///     Check if the Mirror is on the GameObject GridMirrors, if so :<br/>
    ///     1°/ Remove it.<br/>
    ///     2°/ Remove the subscription from the event PassingThroughAble to the function UpdateGridTriggarable.<br/>
    ///     3°/ Remove the BoxCollider linked to the Mirror to the grid.<br/>     
    /// </summary>
    /// <param name="go_MirrorToRemove">GameObject of the Mirror that has to be deactivated</param>
    public void RemoveActivatedMirror(GameObject go_MirrorToRemove)
    {
        if (go_GridMirrors.Contains(go_MirrorToRemove))
        {
            int i_index = go_GridMirrors.IndexOf(go_MirrorToRemove);

            go_GridMirrors.Remove(go_MirrorToRemove);

            mirrorActivation_box[i_index].PassingThroughAble -= UpdateGridTriggarable;

            mirrorActivation_box.Remove(go_MirrorToRemove.GetComponentInChildren<MirrorActivation_Box>());
        }
        else
            return;
    }

    // Function that observe the behavior of the MirrorActivation_Box when the grid is On and the character is closed to a Mirror
    void UpdateGridTriggarable(GameObject go_CurrentMirror, bool b_isActivated)
    {
        go_MirrorFacingCharacter = go_CurrentMirror;

        // If the activation is true, We display the UI that inform the user with button to press
        if (b_isActivated)
        {
            b_GridTriggarable = true;
        }
        else    // Else, we stop displaying the UI
        {
            b_GridTriggarable = false;
        }
        gridActivation?.Invoke(b_GridTriggarable);
    }

    // Function to modify later when we will have several Mirror on the level
    public GameObject GetOtherMirror() 
    { 
        int i_index = go_GridMirrors.IndexOf(go_MirrorFacingCharacter);

        if (i_index == 0)
        {
            return go_GridMirrors[1];
        }
            
        else
        {
            return go_GridMirrors[0];
        }
    }
}
