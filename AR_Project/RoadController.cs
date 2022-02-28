using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public float speed;
    public float length;
    public float dis;
    bool isActive = false;
    MeshRenderer mesh;

    public Transform rider;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1) 기준점과 road 위치의 거리를 계산
        distance = Vector3.Distance(rider.position, transform.position);

        // 2) road를 이동
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.World);

        // 3) 기준점과 road 위치의 거리에 따라 road의 위치 초기화 판별
        if(distance<dis) // 이동가능
        {
            mesh.enabled = true;
            isActive = true;
        }
        else // 거리를 초기화하여 length만큼 앞으로 이동
        {
            mesh.enabled = false;
            if(isActive)
            {
                isActive = false;
                transform.position -= new Vector3(0, 0, length);
            }
        }
    }
}
