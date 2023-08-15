using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [Header("Point")]
    [SerializeField] GameObject goPoint;
    [SerializeField] float delta = 5f;
    [SerializeField] GameObject goSetting;
    float delayTime = 0.3f;
    float m_delay = 0;
    bool click;
    // Start is called before the first frame update
    void Start()
    {
        click = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goSetting.activeSelf) return;
        this.Click();
        if (click)
        {
            if (m_delay > 0)
                m_delay -= Time.deltaTime;
            else
            {
                Vector3 index = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 offset = Vector3.zero;
                if (goPoint.transform.position.x < index.x)
                    offset += Vector3.right * delta;
                else if (goPoint.transform.position.x > index.x)
                    offset += Vector3.left * delta;

                if (goPoint.transform.position.y < index.y)
                    offset += Vector3.up * delta;
                else if (goPoint.transform.position.y > index.y)
                    offset += Vector3.down * delta;

                goPoint.transform.position = goPoint.transform.position + offset;
               m_delay = delayTime/4;
            }
        }
    }
    void Click()
    {
        if(Input.GetMouseButtonDown(0))
        {
            click = true;
            m_delay = delayTime;
        }
        if(Input.GetMouseButtonUp(0)) {
            click = false;
        }
    }
}
