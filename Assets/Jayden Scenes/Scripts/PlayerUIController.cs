using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
 {
  public Image pizzaImage;
    public TextMeshProUGUI coinText;

// Start is called before the first frame update
   public void UIStart()
   {
      pizzaImage = GameObject.Find("PizzaUI").GetComponent<Image>();
        if (GameObject.Find("CoinText") != null)
        {
            coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        }
      
   }

// Update is called once per frame
  public void UpdateHealth(float currentHealth, float maxHealth)
  {
        if(pizzaImage != null)
        {
            pizzaImage.fillAmount = currentHealth / maxHealth;
        }
 
  }

    public void UpdateCoin(string newText)
    {
        coinText.text = newText;
    }
}
