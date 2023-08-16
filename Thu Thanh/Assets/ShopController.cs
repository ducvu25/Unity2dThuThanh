using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using static UnityEngine.Rendering.VolumeComponent;

public class ShopController : MonoBehaviour
{
    [Header("Section 1")]
    [SerializeField] GameObject[] goSection = new GameObject[2];

    [Header("cristal")]
    [SerializeField] TextMeshProUGUI[] txtCritals = new TextMeshProUGUI[5];
    int[] numCritals = new int[5];

    [Header("Content")]
    [SerializeField] GameObject goContent;
    GameObject[,] matrixConten;
    int[,] value = { { 5, 10, 15, 25, 50 }, { 50, 100, 150, 250, 500 }, { 1, 3, 7, 9, 11 } };

    [Header("Cheset Open")]
    [SerializeField] GameObject goChesteOpen;
    ChesetOpen chestOpen;
    int functionSection1, functionSection2;
    // Start is called before the first frame update
    void Start()
    {
        string[] sCritals = PlayerPrefs.GetString("Critals", "0 0 0 2 3").Split(" ");
        for(int i = 0; i < sCritals.Length; i++)
        {
            numCritals[i] = int.Parse(sCritals[i]);
            txtCritals[i].text = sCritals[i];
        }
        chestOpen = goChesteOpen.GetComponent<ChesetOpen>();
        SetConten();
        functionSection1 = 0;
        functionSection2 = 0;
        SetSection(functionSection1, functionSection2);
        goChesteOpen.SetActive(false);
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
        /*if(functionSection2 == 0)
        {

        }else if(functionSection2 == 1)
        {

        }*/
    }
    public void ChestsOff()
    {
        goChesteOpen.SetActive(false);
        for (int j = 0; j < matrixConten[1, functionSection2].transform.GetChild(0).GetChild(0).childCount; j++)
        {
            ParticleSystem particleSystem = matrixConten[1, functionSection2].transform.GetChild(0).GetChild(0).GetChild(j).GetChild(0).gameObject.GetComponent<ParticleSystem>();
            particleSystem.Play();
        }
    }
}
