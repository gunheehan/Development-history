using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_move : MonoBehaviour
{
    private Rigidbody rain_rigidbody;
    public Vector3 destination;
    private float rain_speed = 0.1f;

    // Start is called before the first frame update
    void OnEnable() // 오브젝트 활성화시
    {
        rain_rigidbody = GetComponent<Rigidbody>(); // 현재 오브젝트의 Rigidbody
        destination = rain_rigidbody.transform.position; // 현재의 위치값을 destination에 저장
    }

    void OnDisable() // 오브젝트 비활성화시
    {
        rain_rigidbody.transform.position = destination; // 현재 오브젝트의 위치값을 초기 활성화 시의 위치 값으로 변경
    }
    void Update()
    {
        rain_rigidbody.transform.position = rain_rigidbody.transform.position + new Vector3(0, -rain_speed, 0); // Y 축으로 이동
    }

    private void OnCollisionStay(Collision collision) // 충돌이 발생하였을 때
    {
        if (collision.other.tag != "Player") // Player가 아닌 경우 바람 비활성화
        {
            rain_rigidbody.transform.position = destination; // Player가 아닌 물체와 충돌할 경우 다시 내리기
        }

        else if(collision.other.gameObject.tag == "Map")
        {
            rain_rigidbody.transform.position = destination; // 현재 오브젝트의 위치값을 초기 활성화 시의 위치 값으로 변경
        }
    }
}
