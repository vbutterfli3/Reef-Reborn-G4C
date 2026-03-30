using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxSlots = 15;
    public int totalCollected = 0;
    private int currentSlots = 0;

    public int supporterCount = 0;
    public bool TalkedToActivist = false;
    public bool TalkedToMayor = false;

    public SpriteRenderer ESprite;
    public TextMeshProUGUI trashtext;
    public GameObject lvl1; 
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject lvl4;
    

    public GameObject wall1;
    public GameObject wall3;

    public GameObject afterLvl1Fade;
    public GameObject afterLvl2Fade;
    public GameObject afterLvl3Fade;

    bool threwTrashOneOut = false;
    bool triggerLevel2 = false;



    public void Start()
    {
        trashtext.text = "0/" + maxSlots;
    }
    public bool TryAddTrash(int trashSize)
    {
        if (currentSlots + trashSize <= maxSlots)
        {
           
            currentSlots += trashSize;
            trashtext.text = currentSlots + "/" + maxSlots;
            return true;
        }
        else
        {
            return false; //full inventory
        }
    }

    public void ThrowOutTrash()
    {
        totalCollected += currentSlots;
        currentSlots = 0;
        trashtext.text = currentSlots + "/" + maxSlots;
        if (totalCollected >= 20 && !threwTrashOneOut)
        {
            afterLvl1Fade.SetActive(true);
            lvl2.SetActive(true);
            wall1.SetActive(false);
            lvl1.SetActive(false);
            Debug.Log("SHOULD UNLOCK LEVEL 2");
            threwTrashOneOut = true; 
            SFXFactory.Instance.PlayLevelUp();
        }
    }
       

    public void Level()
    {
       
        Debug.Log("Activist: " + TalkedToActivist + " | Mayor: " + TalkedToMayor);
        if (TalkedToActivist && TalkedToMayor && !triggerLevel2)
        {
            afterLvl2Fade.SetActive(true);
            lvl3.SetActive(true);
            lvl2.SetActive(false);
            wall3.SetActive(true);
            Debug.Log("SHOULD UNLOCK LEVEL 3");
            triggerLevel2 = true;
            SFXFactory.Instance.PlayLevelUp();

        }
        
        if ( supporterCount >= 5)
        {
            Debug.Log("SHOULD UNLOCK LEVEL 4");
            afterLvl3Fade.SetActive(true);
            wall3.SetActive(true);
            lvl4.SetActive(true);
            lvl3.SetActive(false);
            SFXFactory.Instance.PlayLevelUp();
        }
    }

    public void ChangeSprite(bool spritestate)
    {
        ESprite.enabled = spritestate;
    }


}


