using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Coin", fileName = "New coin")]
public class CoinSO : ItemIformation
{
    [SerializeField] int rarity;
    
    public int GetRarity()
    {
        return rarity;
    }
}
