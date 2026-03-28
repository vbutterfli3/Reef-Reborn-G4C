using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HW3NPC : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    private GameObject _talkIcon;

    private void Start()
    {
        _talkIcon = transform.Find(HW3Structs.GameObjects.talkIcon).gameObject;
        _talkIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == HW3Structs.Tags.playerTag)
        {
            bool hastalked = true;
            if(GetComponent<ActivistNPC>()){
                hastalked = !GetComponent<ActivistNPC>().AlreadyTalked;
            }
            if (GetComponent<MayorNPC>())
            {
                hastalked = !GetComponent<MayorNPC>().AlreadyTalked;
            }


            if (hastalked)
            {
                _talkIcon.SetActive(true);
                collision.GetComponent<PlayerDialogue>().CopyDialogue(dialogue);
                collision.GetComponent<PlayerDialogue>().SetCanSpeak(true);
            }
        }
    }

    public bool canTalkCheck()
    {
        bool hastalked = true;
        if (GetComponent<ActivistNPC>())
        {
            hastalked = !GetComponent<ActivistNPC>().AlreadyTalked;
        }
        if (GetComponent<MayorNPC>())
        {
            hastalked = !GetComponent<MayorNPC>().AlreadyTalked;
        }
        return hastalked;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == HW3Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(false);
            collision.GetComponent<PlayerDialogue>().SetCanSpeak(false);
        }
    }

}
