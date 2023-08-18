using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ButtonShopController : MonoBehaviour
{
    int id;

    public void Set(Sprite sprite, Sprite spritePrice, int prite, int id)
    {
        this.id = id;
        transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = prite.ToString();
        transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = spritePrice;
        transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = sprite;
    } 
    public void Buy()
    {
        ShopController shopController = GameObject.FindWithTag("Database").gameObject.GetComponent<ShopController>();
        if (shopController.BuyItem(id))
        {
            Destroy(gameObject);
        }
    }
    public void ShowInformation()
    {
        ShopController shopController = GameObject.FindWithTag("Database").gameObject.GetComponent<ShopController>();
        shopController.SetInformation(id);
    }
}
