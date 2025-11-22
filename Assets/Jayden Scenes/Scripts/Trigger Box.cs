using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public string newtext;
    public GameObject textbox;
    public TextMeshProUGUI textboxtext;

    float timer = 2;
    float currenttime = 2;

    // Update is called once per frame
    void Update()
    {
        currenttime-=Time.deltaTime;
        if (currenttime < 0)
        {
            currenttime= timer;
            textbox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            textbox.SetActive(true);
            textboxtext.text = newtext;
        }
    }
}
