using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPopup : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
