using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_move : MonoBehaviour
{
    private Rigidbody wind_rigidbody;
    public Vector3 destination;
    private float wind_speed = 0.03f;

    bool triggerStart = false;

    // Start is called before the first frame update
    void OnEnable() // 오브젝트 활성화시
    {
        wind_rigidbody = GetComponent<Rigidbody>(); // 현재 오브젝트의 Rigidbody
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        destination = wind_rigidbody.transform.position; // 현재의 위치값을 destination에 저장
    }

    void OnDisable() // 오브젝트 비활성화시
    {
        wind_rigidbody.transform.position = destination; // 현재 오브젝트의 위치값을 초기 활성화 시의 위치 값으로 변경
    }
    // Update is called once per frame
    void Update()
    {
        wind_rigidbody.transform.position = wind_rigidbody.transform.position + new Vector3(-wind_speed,0,0); // X 축으로 이동

    }
}
