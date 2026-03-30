using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterNPC : MonoBehaviour
{
    public PlayerInventory playerinv;
    public GameObject TalkIcon;
    bool supported = false;
    public float interactDistance = 3f;
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerinv.transform.position);

        if (distance < interactDistance && Input.GetKeyDown(KeyCode.E) && !supported)
        {
            playerinv.supporterCount++;
            supported = true;
            GetComponent<CircleCollider2D>().enabled = false;
            TalkIcon.SetActive(false);
            playerinv.Level();
            SFXFactory.Instance.PlaySupporterWrite();
        }

    }
   
}
