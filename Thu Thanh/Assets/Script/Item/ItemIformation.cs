using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item parent", fileName = "New parent")]
public class ItemIformation : ScriptableObject
{
    [SerializeField] protected string _id = "0";
    [SerializeField] protected string _name = "12";
    [TextArea(1, 5)]
    [SerializeField] protected string _information = "12";
    [SerializeField] protected Sprite _sprite;
    [SerializeField] protected string price;
    [SerializeField] protected string pricePass;
    public string Id
    {
        get { return _id;}
        set { _id = value;} 
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Information
    {
        get { return _information; }
        set { _information = value; }
    }
    public Sprite sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
    }
    public int Price()
    {
        string[] s = this.price.Split(" ");
        return int.Parse(s[0]);
    }
    public string IdPrice()
    {
        string[] s = this.price.Split(" ");
        return s[1];
    }
    public int PricePass() {
        string[] s = this.pricePass.Split(" ");
        return int.Parse(s[0]);
    }
    public string IdPricePass()
    {
        string[] s = this.pricePass.Split(" ");
        return s[1];
    }
}
