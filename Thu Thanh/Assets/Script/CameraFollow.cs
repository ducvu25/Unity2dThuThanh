using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform point;
    Vector3 offset;
    [SerializeField] float delay;
    [SerializeField]    Vector4 lineMap; // x1, y1 - x2, y2
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - point.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPlayer = point.position + offset; // lấy tọa độ mới của cam khi theo nhân vật
        // vt ban dau, vt di chuyen, delay
        transform.position = Vector3.Lerp(transform.position, cameraPlayer, delay * Time.deltaTime);  // caajo nhật vị trí
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if(transform.position.x < lineMap.x) //x1
            transform.position = new Vector3(lineMap.x, transform.position.y, transform.position.z);
        if(transform.position.y > lineMap.y) // y1
            transform.position = new Vector3(transform.position.x, lineMap.y, transform.position.z);

        if(transform.position.x > lineMap.z) // x2
            transform.position = new Vector3(lineMap.z, transform.position.y, transform.position.z);
        if (transform.position.y < lineMap.w) // y2
            transform.position = new Vector3(transform.position.x, lineMap.w, transform.position.z);

    }
}
