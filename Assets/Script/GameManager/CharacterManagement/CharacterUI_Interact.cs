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
        if (!b_GridAvailable)
        {
            DeactivateUIDisplay();
        }
        else
        {
            UpdateUIDisplay_Interact();
            ActivateUIDisplay();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="b_KeyAvailable"></param>
    public void UI_ItemInteraction(bool b_ItemAvailable)
    {
        if (!b_ItemAvailable)
        {
            DeactivateUIDisplay();
        }
        else
        {
            UpdateUIDisplay_Retrieve();
            ActivateUIDisplay();
        }
    }

    /// <summary>
    /// Function to Activate the display regarding the button to interact with above the character
    /// </summary>
    void ActivateUIDisplay()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    /// <summary>
    /// Function to Deactivate the display regarding the button to interact with above the character
    /// </summary>
    void DeactivateUIDisplay()
    {
        transform.GetChild(1).gameObject.SetActive(false);
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
    void UpdateUIDisplay_Retrieve()
    {
        if(!CheckUIDisplayText("Recuperer"))
            UpdateUIText("Recuperer");
        
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
