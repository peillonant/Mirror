using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_Character : MonoBehaviour
{
    // VARIABLE CREATION
    [SerializeField] GameObject go_Character;
    // END VARIABLE CREATION
    
    /// <summary>
    /// 
    /// </summary>
    public void CharacterGoNextLevel()
    {     
        go_Character.transform.SetParent(transform.GetChild(LevelManager.Instance.GetCurrentLevel()+1));
    }

    /// <summary>
    /// 
    /// </summary>
    public void CharacterReinitialization()
    {
        // Reset position with the SpawnPoint of the Level
        ResetPosition();

        // Reset KeyInventory
        ResetKeyInventory();

    }

    /// <summary>
    /// 
    /// </summary>
    void ResetPosition()
    {
        GameManager.Instance.SetCanMove();

        go_Character.transform.position = transform.GetChild(LevelManager.Instance.GetCurrentLevel()+1).GetComponent<LevelProperty>().GetSpawnPosition().transform.position;

        go_Character.GetComponent<CharacterMovement>().v3_MoveDirection = go_Character.transform.position;

        StartCoroutine(AbleToMoveAgain());
    }

    /// <summary>
    /// 
    /// </summary>
    void ResetKeyInventory()
    {
        for (int i = 0; i < go_Character.GetComponent<CharacterInventory>().GetInventoryObjects().Count; i++)
        {
            if(CheckItemFromInventoryIsKey(go_Character.GetComponent<CharacterInventory>().GetInventoryObjects()[i]))
            {
                go_Character.GetComponent<CharacterInventory>().RemoveItem(go_Character.GetComponent<CharacterInventory>().GetInventoryObjects()[i]);
            }
        }
    }

    /// <summary>
    /// TO CHECK TO OPTIMIZE LATER ?
    /// </summary>
    /// <param name="go_ItemToCheck"></param>
    /// <returns></returns>
    bool CheckItemFromInventoryIsKey(GameObject go_ItemToCheck)
    {
        return go_ItemToCheck.tag.Equals("Opener") || go_ItemToCheck.tag.Equals("Switch");
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator AbleToMoveAgain()
    {
        yield return new WaitForSeconds(0.5f);

        GameManager.Instance.SetCanMove();
    }
}
