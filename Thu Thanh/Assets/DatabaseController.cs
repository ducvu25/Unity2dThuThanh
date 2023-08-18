using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour
{
    List<EquipmentSO> items;
    List<CoinSO> coins;
    List<HeroSO> heros;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<EquipmentSO>();
        coins = new List<CoinSO>();
        heros = new List<HeroSO>();
        EquipmentSO[] loadedIteams = Resources.LoadAll<EquipmentSO>("Database/Equipment");
        foreach (EquipmentSO item in loadedIteams)
        {
            items.Add(item);
        }
        CoinSO[] loadedCoins = Resources.LoadAll<CoinSO>("Database/Coin");
        foreach (CoinSO coin in loadedCoins)
        {
            coins.Add(coin);
           // Debug.Log(coin.Name);
        }
        HeroSO[] loadHeros = Resources.LoadAll<HeroSO>("Database/Hero");
        foreach (HeroSO hero in loadHeros)
        {
            heros.Add(hero);
        }
    }
    public EquipmentSO RandomItem()
    {
        return items[(int)Random.Range(0, items.Count)];
    }
    public CoinSO RandomCoin(int value = 1)
    {
        int x = (int)Random.Range(0, 100);
        if (x < 10*value)
            return coins[2];
        if(x < 30*value)
            return coins[1];
        return coins[0];
    }
    public HeroSO RandomHero()
    {
        return heros[(int)Random.Range(0, heros.Count)];
    }
}
