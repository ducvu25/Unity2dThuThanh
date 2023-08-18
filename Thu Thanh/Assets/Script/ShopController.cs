using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using static UnityEngine.Rendering.VolumeComponent;
using static UnityEditor.Progress;
using UnityEditorInternal.VersionControl;
using System.Reflection;

public class ShopController : MonoBehaviour
{
    [Header("-----Section-----")]
    [SerializeField] GameObject[] goSection = new GameObject[2];
    [SerializeField] GameObject showInformation;

    [Header("-----cristal-----")]
    [SerializeField] TextMeshProUGUI[] txtCritals = new TextMeshProUGUI[5];
    int[] numCritals = new int[5];

    [Header("-----Content-----")]
    [SerializeField] GameObject goContent;
    GameObject[,] matrixConten;
    int[,] value = { { 5, 10, 15, 25, 50 }, { 50, 100, 150, 250, 500 }, { 1, 3, 7, 9, 11 } };

    [Header("-----Cheset Open-----")]
    [SerializeField] GameObject goChesteOpen;
    ChesetOpen chestOpen;
    int functionSection1, functionSection2;

    [Header("-----Shop----")]
    [SerializeField]
    Sprite[] hubCoin;
    [SerializeField] GameObject btnShop;
    [SerializeField] List<ItemIformation> listItem;

    [Header("-----Error")]
    [SerializeField] GameObject goError;
    // Start is called before the first frame update
    void Start()
    {
        string[] sCritals = PlayerPrefs.GetString("Critals", "0 0 0 10 5").Split(" ");
        for(int i = 0; i < sCritals.Length; i++)
        {
            numCritals[i] = int.Parse(sCritals[i]);
            txtCritals[i].text = sCritals[i];
        }
        chestOpen = goChesteOpen.GetComponent<ChesetOpen>();
        functionSection1 = 0;
        functionSection2 = 0;
        SetConten();
        SetSection(functionSection1, functionSection2);
        goChesteOpen.SetActive(false);
        showInformation.SetActive(false);
        goError.SetActive(false);
        CreateShop();
    }

    void SetSection(int index1, int index2)
    {
        matrixConten[functionSection1, functionSection2].SetActive(false);
        functionSection1 = index1;
        functionSection2 = index2;
        for (int i=0; i < goSection[1].transform.childCount; i++)
        {
            goSection[1].transform.GetChild(i).gameObject.SetActive(false);
        }
        goSection[1].transform.GetChild(index1).gameObject.SetActive(true);
        matrixConten[functionSection1, functionSection2].SetActive(true);
        if (index1 == 1)
            for (int j = 0; j < matrixConten[1, index2].transform.GetChild(0).GetChild(0).childCount; j++)
            {
                ParticleSystem particleSystem = matrixConten[1, index2].transform.GetChild(0).GetChild(0).GetChild(j).GetChild(0).gameObject.GetComponent<ParticleSystem>();
                particleSystem.Play();
            }
    }
    public void SetSection1(int index)
    {
        SetSection(index, 0);
    }
    public void SetSection2(int index)
    {
        SetSection(functionSection1, index);
    }
    void SetConten()
    {
        matrixConten = new GameObject[goSection[0].transform.childCount, goSection[1].transform.childCount];
        int count = 0;
        for(int i=0; i < goSection[0].transform.childCount; i++)
            for(int j=0; j < goSection[1].transform.childCount; j++)
            {
                matrixConten[i, j] = goContent.transform.GetChild(count++).gameObject;
                matrixConten[i, j].SetActive(false);
            }
        for(int i=0; i<3; i++)
            for(int j=0; j< matrixConten[0, i].transform.GetChild(0).GetChild(0).childCount; j++)
            {
                TextMeshProUGUI textMeshProUGUI = matrixConten[0, i].transform.GetChild(0).GetChild(0).GetChild(j).GetChild(1).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = value[i,j].ToString();
            }
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < matrixConten[1, i].transform.GetChild(0).GetChild(0).childCount; j++)
            {
                TextMeshProUGUI textMeshProUGUI = matrixConten[1, i].transform.GetChild(0).GetChild(0).GetChild(j).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = numCritals[3 + j].ToString() + "/1";
            }
    }
    // 1 1
    void SetCristal(int index, int index2)
    {
        numCritals[index] += value[index, index2];
        txtCritals[index].text = numCritals[index].ToString();
    }
    public void BuyCristalBlue(int index)
    {
        SetCristal(0, index);
    }
    public void BuyCristalOrange(int index)
    {
        SetCristal(1, index);
    }
    public void BuyCristalRed(int index)
    {
        SetCristal(2, index);
    }

    // 2 1
    public void ChestsOn(int index)
    {
        if(numCritals[3 + index] <= 0)
        {
            goError.SetActive(true);
            goError.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Không đủ chìa khóa";
            return;
        }
        numCritals[3 + index]--;
        txtCritals[3 + index].text = numCritals[3 + index].ToString();
        for (int i = 0; i < 3; i++)
           // for (int j = 0; j < matrixConten[1, i].transform.GetChild(0).GetChild(0).childCount; j++)
            {
                TextMeshProUGUI textMeshProUGUI = matrixConten[1, i].transform.GetChild(0).GetChild(0).GetChild(index).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = numCritals[3 + index].ToString() + "/1";
            }
        chestOpen.SetType(new Vector2(functionSection2, index));
        goChesteOpen.SetActive(true);
        for (int j = 0; j < matrixConten[1, functionSection2].transform.GetChild(0).GetChild(0).childCount; j++)
        {
            ParticleSystem particleSystem = matrixConten[1, functionSection2].transform.GetChild(0).GetChild(0).GetChild(j).GetChild(0).gameObject.GetComponent<ParticleSystem>();
            particleSystem.Stop();
        }
    }
    public void ChestsOff()
    {
        ChesetOpen chesetOpen = goChesteOpen.GetComponent<ChesetOpen>();
        chesetOpen.HideInformation();
        goChesteOpen.SetActive(false);
        for (int j = 0; j < matrixConten[1, functionSection2].transform.GetChild(0).GetChild(0).childCount; j++)
        {
            ParticleSystem particleSystem = matrixConten[1, functionSection2].transform.GetChild(0).GetChild(0).GetChild(j).GetChild(0).gameObject.GetComponent<ParticleSystem>();
            particleSystem.Play();
        }
    }
    public void AddCrital(int index, int value)
    {
        numCritals[index] += value;
        txtCritals[index].text = numCritals[index].ToString();
    }
    // 3
    void CreateShop()
    {
        //matrixConten[6]
        for(int i=0; i<listItem.Count; i++)
        {
            GameObject gameObject = Instantiate(btnShop, Vector3.zero, Quaternion.identity);
            ButtonShopController buttonShopController = gameObject.GetComponent<ButtonShopController>();
            buttonShopController.Set(listItem[i].sprite, hubCoin[listItem[i].IdPrice()[1] - 48], listItem[i].Price(), i);
            gameObject.transform.SetParent(matrixConten[2, 0].transform.GetChild(0).GetChild(0).transform);
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.localScale = Vector3.one;
        }
    }
    public bool BuyItem(int id)
    {
        int[] convert = { 1, 0, 2 };
        //Dictionary<string, int> map = new Dictionary<string, int>();
        int type = convert[listItem[id].IdPrice()[1] - 48];
        if (listItem[id].Price() > numCritals[type])
        {
            goError.SetActive(true);
            goError.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Không đủ pha lê";
            return false;
        }

        numCritals[type] -= listItem[id].Price();
        txtCritals[type].text = numCritals[type].ToString();
        return true;
    }
    public void SetInformation(ItemIformation itemIformation)
    {
        showInformation.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = itemIformation.sprite;
        showInformation.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = itemIformation.Name;
        showInformation.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = itemIformation.Information;
        if(itemIformation is HeroSO)
        {
            HeroSO hero = (HeroSO)itemIformation;
            showInformation.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = hero.sprite;
            showInformation.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "LV: " + hero.Lv.ToString();
            showInformation.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }else if(itemIformation is EquipmentSO)
        {
            EquipmentSO equipmentSO = (EquipmentSO)itemIformation;
            showInformation.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "LV: " + equipmentSO.Lv.ToString();
            showInformation.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = equipmentSO.ShowInformation();
        }
        else
        {
            string[] rarity = { "Thường", "Hiếm", "Siêu hiếm" };
            CoinSO coinSO = (CoinSO)itemIformation;
            showInformation.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = rarity[coinSO.GetRarity()];
            showInformation.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
    }
    public void SetInformation(int id)
    {
        ShowInformation();
        SetInformation(listItem[id]);
    }
    public void ShowInformation()
    {
        showInformation.SetActive(true);
    }
    public void HideInformation()
    {
        showInformation.SetActive(false);
    }
}
