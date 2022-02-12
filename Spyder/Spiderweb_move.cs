using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderweb_move : MonoBehaviour
{
    
    private Rigidbody web_rigidbody;
    public Vector3 destination;
    private float web_speed = 15f;
    bool drop;

    // Start is called before the first frame update
    void OnEnable() // 오브젝트 활성화시
    {
        //web_rigidbody = GetComponent<Rigidbody>(); // 현재 오브젝트의 Rigidbody
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        destination = gameObject.transform.position; // 현재의 위치값을 destination에 저장
        drop = true;
    }

    void OnDisable() // 오브젝트 비활성화시
    {
        gameObject.transform.position = destination; // 현재 오브젝트의 위치값을 초기 활성화 시의 위치 값으로 변경
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    void Update()
    {
        if(drop)
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, Time.deltaTime*-web_speed, 0); // Y 축으로 이동
    }

    private void OnCollisionEnter(Collision collision) // 충돌이 발생하였을 때
    {
        if (collision.other.tag == "Plane") // Player가 아닌 경우 바람 비활성화
        {
            //web_rigidbody.transform.position = destination; // Player가 아닌 물체와 충돌할 경우 다시 내리기
            drop = false;
            gameObject.SetActive(false);
        }

        /*else if(collision.other.gameObject.tag == "Map")
        {
            web_rigidbody.transform.position = destination; // 현재 오브젝트의 위치값을 초기 활성화 시의 위치 값으로 변경
        }*/
    }
}
