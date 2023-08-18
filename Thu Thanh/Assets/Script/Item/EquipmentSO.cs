using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(menuName = "Equipment", fileName = "New Equipment")]
public class EquipmentSO : ItemIformation
{
    [SerializeField] private int _quality = 1;
    [SerializeField] private int _lv = 1;
    [SerializeField] private int _exp = 0;
    [SerializeField] private int _expMax = 10;
    [SerializeField] private int _hp = 0;
    [SerializeField] private int _dame = 0;
    [SerializeField] private int _speed = 0;
    [SerializeField] private float _distance = 0;
    [SerializeField] private float _time_spawn = 0;
    
    public int Quality
    {
        get { return _quality; }
        set { _quality = value;}
    }
    public int Lv
    {
        get { return _lv; }
        set { _lv = value; }
    }
    public int Exp
    {
        get { return _exp; }
        set { _exp = value; }
    }
    public int ExpMax
    {
        get { return _expMax; }
        set { _expMax = value; }
    }
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    public int Dame
    {
        get { return _dame; }
        set { _dame = value; }
    }
    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public float Distance
    {
        get { return _distance; }
        set { _distance = value; }
    }
    public float TimeSpawn
    {
        get { return _time_spawn; }
        set { _time_spawn = value; }
    }
    public string ShowInformation()
    {
        string s = "";
        if(_hp != 0)
        {
            if (_hp > 0)
                s += " + " + _hp.ToString() + " hp\n";
            else
                s += " - " + Mathf.Abs(_hp).ToString() + " hp\n";
        }
        if (_dame != 0)
        {
            if (_dame > 0)
                s += " + " + _dame.ToString() + " sát thương\n";
            else
                s += " - " + Mathf.Abs(_dame).ToString() + " sát thương\n";
        }
        if (_speed != 0)
        {
            if (_speed > 0)
                s += " + " + _speed.ToString() + " tốc độ di chuyển\n";
            else
                s += " - " + Mathf.Abs(_speed).ToString() + " tốc độ di chuyển\n";
        }
        if (_distance != 0)
        {
            if (_distance > 0)
                s += " + " + _distance.ToString() + " phạm vi tấn công\n";
            else
                s += " - " + Mathf.Abs(_distance).ToString() + " phạm vi tấn công\n";
        }
        if (_time_spawn != 0)
        {
            if (_time_spawn > 0)
                s += " + " + _time_spawn.ToString() + " thời gian hồi sinh\n";
            else
                s += " - " + Mathf.Abs(_time_spawn).ToString() + " thời gian hồi sinh\n";
        }
        return s;
    }
}
