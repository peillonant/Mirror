using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI_Interact : MonoBehaviour
{
    void Start()
    {
        Character_SubscriptionEvent.Instance.SubscriptionMirrorGrid();
        Character_SubscriptionEvent.Instance.SubscriptionItemInteraction();
    }

    /// <summary>
    /// Function to Display or not the button to click to interact with the Grid above the character
    /// </summary>
    /// <param name="b_GridAvailable">Boolean to see if we have to activate the Display or Deactivate it</param>
    public void UI_GridInteraction(bool b_GridAvailable)
    {
        if (b_GridAvailable)
        {
            UpdateUIDisplay_Interact();
        }

        ActivateUIDisplay(b_GridAvailable);
    }

    /// <summary>
    /// Display above the Character, we are launching regarding the item near the character the correct word to use the Interact Button
    /// </summary>
    /// <param name="b_KeyAvailable"></param>
    public void UI_ItemInteraction(bool b_ItemAvailable, GameObject go_ProbesClosed)
    {
        if (b_ItemAvailable)
        {
            UpdateUIDisplay_Retrieve(go_ProbesClosed);
        }

        ActivateUIDisplay(b_ItemAvailable);
    }

    /// <summary>
    /// Function to Activate the display regarding the button to interact with above the character
    /// </summary>
    void ActivateUIDisplay(bool b_ToActivate)
    {
        transform.GetChild(1).gameObject.SetActive(b_ToActivate);
    }

    /// <summary>
    /// Function to check the UI above the character before display it.<\br>
    /// If not the display correct one update it
    /// </summary>
    void UpdateUIDisplay_Interact()
    {
        if(!CheckUIDisplayText("Interargir"))
            UpdateUIText("Interargir");
        
        if(!CheckUIDisplayIcone("Button_A"))
            UpdateUIIcone("Button_A");
    }

    /// <summary>
    /// 
    /// </summary>
    void UpdateUIDisplay_Retrieve(GameObject go_ProbesClosed)
    {
        if (go_ProbesClosed.tag.Equals("Opener"))
        {
            if(!CheckUIDisplayText("Recuperer"))
                UpdateUIText("Recuperer");
        }
        else if (go_ProbesClosed.tag.Equals("Switch"))
        {
            if(!CheckUIDisplayText("Interargir"))
                UpdateUIText("Interargir");
        }
        
        if(!CheckUIDisplayIcone("Button_A"))
            UpdateUIIcone("Button_A");
    }

    /// <summary>
    /// Function to check if the current text available to display is the same as the one we want
    /// </summary>
    /// <param name="s_TextUI">string to compare</param>
    /// <returns></returns>
    bool CheckUIDisplayText(string s_TextUI)
    {
        return s_TextUI.Equals(transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text);
    }

    /// <summary>
    /// Function to check if the current icone available to display is the same as the one we want
    /// </summary>
    /// <param name="s_IconeUI">string to compare</param>
    /// <returns></returns>
    bool CheckUIDisplayIcone(string s_IconeUI)
    {
        return s_IconeUI.Equals(transform.GetChild(1).GetChild(0).GetComponent<RawImage>().texture.name);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s_TexttUI"></param>
    void UpdateUIText(string s_TexttUI)
    {
        transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().SetText(s_TexttUI);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s_IconeUI"></param>
    void UpdateUIIcone(string s_IconeUI)
    {
        transform.GetChild(1).GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture>("/Icon/+"+s_IconeUI);
    }
}
