using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_Character : MonoBehaviour
{
    [SerializeField] GameObject go_Character;

    
    public void CharacterGoNextLevel()
    {     
        go_Character.transform.SetParent(transform.GetChild(LevelManager.Instance.GetCurrentLevel()+1));
    }

    public void CharacterReinitialization()
    {
        // Reset position with the SpawnPoint of the Level
        ResetPosition();

        // Reset KeyInventory
        ResetKeyInventory();

    }

    void ResetPosition()
    {
        GameManager.Instance.SetCanMove();

        go_Character.transform.position = transform.GetChild(LevelManager.Instance.GetCurrentLevel()+1).GetComponent<LevelProperty>().GetSpawnPosition().transform.position;

        go_Character.GetComponent<CharacterMovement>().v3_MoveDirection = go_Character.transform.position;

        StartCoroutine(AbleToMoveAgain());
    }


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

    bool CheckItemFromInventoryIsKey(GameObject go_ItemToCheck)
    {
        return go_ItemToCheck.tag.Equals("Key");
        
    }

    IEnumerator AbleToMoveAgain()
    {
        yield return new WaitForSeconds(0.5f);

        GameManager.Instance.SetCanMove();
    }
}
