using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hero", fileName = "New Hero")]
public class HeroSO : ItemIformation
{
    [SerializeField] private int _lv = 1;
    [SerializeField] private int _exp = 0;
    [SerializeField] private int _expMax = 10;
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _dame = 10;
    [SerializeField] private int _speed = 5;
    [SerializeField] private float _distance = 10;
    [SerializeField] private float _time_spawn = 5f;
    [SerializeField] private GameObject _character = null;

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
    public GameObject Character
    {
        get { return _character; }
        set { _character = value; }
    }
}