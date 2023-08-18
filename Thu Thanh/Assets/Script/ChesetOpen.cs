using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ChesetOpen : MonoBehaviour
{
    [SerializeField] Sprite[] hubs;
    GameObject shopController;
    Vector2 type = Vector2.zero;
    // Start is called before the first frame update
    private void Start()
    {
        shopController = GameObject.FindWithTag("Database");
    }
    public void SetType(Vector2 type)
    {
        this.type = type;
        transform.GetChild(1).gameObject.GetComponent<Image>().sprite = hubs[(int)type.y];
    }
    
    void OpenChests()
    {
        transform.GetChild(1).gameObject.GetComponent<Image>().sprite = hubs[(int)type.y + 2];
    }
    int[] ratios = {5, 30};
    void CreateIteam()
    {
        ItemIformation itemIformation;
        bool check = false;
        if (type.y == 1)
        {
            int x = (int)Random.Range(0, 9); // 0.9 * 2/3 = 0.6
            int y = (int)Random.Range(0, 2);
            if (x <= 8 && y <= 1)
                check = true;
        }
        else
        {
            int x = (int)Random.Range(0, 9); // 1/10 * 1/2 = 0
            int y = (int)Random.Range(0, 1);
            if (x == 5 && y == 1)
                check = true;
        }
        if(check)
        {
            if(type.x == 0) {
                HeroSO hero = shopController.GetComponent<DatabaseController>().RandomHero();
                itemIformation = hero;
                //transform.GetChild(transform.childCount - 1).gameObject.GetComponent<Image>().sprite = hero.sprite;
                transform.GetChild(transform.childCount - 1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "";
                //showInformation.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = hero.Name;
                //showInformation.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = hero.Information;
            }
            else
            {
                EquipmentSO itemSO = shopController.GetComponent<DatabaseController>().RandomItem();
                itemIformation = itemSO;
                //transform.GetChild(transform.childCount - 1).gameObject.GetComponent<Image>().sprite = itemSO.sprite;
                //showInformation.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = itemSO.sprite;
                transform.GetChild(transform.childCount - 1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "";
                //showInformation.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = itemSO.Name;
                //showInformation.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = itemSO.Information;
            }
        }
        else
        {
            
            int[] convert = { 1, 0, 2 };
            int[] convert2 = { 1, 10, 50 };
            CoinSO coin = shopController.GetComponent<DatabaseController>().RandomCoin((int)(type.y + 1));
            itemIformation = coin;
            //transform.GetChild(transform.childCount - 1).gameObject.GetComponent<Image>().sprite = coin.sprite;
            //showInformation.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = coin.sprite;
            //showInformation.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = coin.Name;
            //showInformation.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = coin.Information;
            // 20 => 5 => 1
            int x = (int)Random.Range(60, 200)* ((int)type.y + 1) / convert2[coin.GetRarity()];
            shopController.GetComponent<ShopController>().AddCrital(convert[coin.GetRarity()], x);
            transform.GetChild(transform.childCount - 1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "x" + x.ToString();
        }
        transform.GetChild(transform.childCount - 1).gameObject.GetComponent<Image>().sprite = itemIformation.sprite;
        shopController.GetComponent<ShopController>().SetInformation(itemIformation);
    }
    public void ShowInformation()
    {
        shopController.GetComponent<ShopController>().ShowInformation();
    }
    public void HideInformation()
    {
        shopController.GetComponent<ShopController>().HideInformation();
    }   
}
