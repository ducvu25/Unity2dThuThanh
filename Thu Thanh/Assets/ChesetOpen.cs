using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChesetOpen : MonoBehaviour
{
    [SerializeField] Sprite[] hubs;
    Vector2 type = Vector2.zero;
    // Start is called before the first frame update
    public void SetType(Vector2 type)
    {
        this.type = type;
        transform.GetChild(1).gameObject.GetComponent<Image>().sprite = hubs[(int)type.y];
    }

}
